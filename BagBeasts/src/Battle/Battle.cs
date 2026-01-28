using System;
using System.Diagnostics.Eventing.Reader;
using BagBeasts.src.Move.Base;
using BagBeasts.src.Ability.AbilityBase;
using BagBeasts.src.Item.ItemBase;
using BagBeasts.src.StatusEffect;

namespace BagBeasts.src.Battle;
public class Battle
{
    public BagBeastObject Player1Beast;

    public BagBeastObject Player2Beast;

    public List<BagBeastObject> TeamPlayer1 { get; }

    public List<BagBeastObject> TeamPlayer2 { get; }

    public ActionBase SelectedPlayer1Move { get; set; }

    public ActionBase SelectedPlayer2Move { get; set; }

    public bool IsSecondTurn { get; set; }

    public ExecuteResult? FirstMoveResult { get; set; }

    public Battle(BagBeastObject p1, BagBeastObject p2)
    {
        Player1Beast = p1;
        Player2Beast = p2;
    }

    private int _turnCounter;

    public void BattleInit(CancellationToken ct)
    {
        var switching1 = new Switch();
        switching1.SwitchOut(Player1Beast, TeamPlayer1);

        var switching2 = new Switch();
        switching2.SwitchOut(Player2Beast, TeamPlayer2);

        while (!ct.IsCancellationRequested)
        {
            // INFO: Dieses BattleInit ist veraltet und sollte nicht mehr verwendet werden.
            // Die Logik wurde in Einzelmethoden für die Blazor-Kompatibilität aufgeteilt.
            break;
        }
    }

    public string ProcessRoundEnd()
    {
        var logs = new List<string>();

        if (Player1Beast.Ability is RoundEndAbilityBase ability1 && Player1Beast.StatusEffect != StatusEffectEnum.EternalEep)
        {
            ability1.AbilityEffect(ref Player1Beast);
        }

        if (Player2Beast.Ability is RoundEndAbilityBase ability2 && Player2Beast.StatusEffect != StatusEffectEnum.EternalEep)
        {
            ability2.AbilityEffect(ref Player2Beast);
        }

        if (Player1Beast.HeldItem is RoundEndItemBase item1 && Player1Beast.StatusEffect != StatusEffectEnum.EternalEep)
        {
            item1.ItemEffect(Player1Beast);
        }

        if (Player2Beast.HeldItem is RoundEndItemBase item2 && Player2Beast.StatusEffect != StatusEffectEnum.EternalEep)
        {
            item2.ItemEffect(Player2Beast);
        }

        if (Player1Beast.StatusEffect != StatusEffectEnum.EternalEep)
        {
            StatusEffectService.TriggerStatusEffect(Player1Beast, out string statusMessage);
            if (!string.IsNullOrEmpty(statusMessage)) logs.Add(statusMessage);
        }

        if (Player2Beast.StatusEffect != StatusEffectEnum.EternalEep)
        {
            StatusEffectService.TriggerStatusEffect(Player2Beast, out string statusMessage);
            if (!string.IsNullOrEmpty(statusMessage)) logs.Add(statusMessage);
        }

        return string.Join("\n", logs);
    }

    // TODO: DO
    /*
    public MoveBase Select(object movenumm)
    {

    }
    */

    public string Turn(BagBeastObject executingBeast, BagBeastObject defendingBeast, ActionBase selectedMove)
    {
        var turnResult = "";

        if (selectedMove == null)
        {
            turnResult = "NullReference Exception";
            return turnResult;
        }

        if (selectedMove is Switch)
        {
            var test = new Switch();

            if (executingBeast == Player1Beast)
            {
                Player1Beast = test.SwitchOut(executingBeast, TeamPlayer1);

                if (Player1Beast.Ability is SwitchInAbilityBase ability)
                {
                    turnResult += ability.AbilityEffect(Player1Beast, Player2Beast);
                }
            }
            else
            {
                Player2Beast = test.SwitchOut(executingBeast, TeamPlayer2);

                if (Player2Beast.Ability is SwitchInAbilityBase ability)
                {
                    turnResult += ability.AbilityEffect(Player2Beast, Player1Beast);
                }
            }
        }


        if ((executingBeast.StatusEffect == StatusEffectEnum.Paralysis || executingBeast.StatusEffect == StatusEffectEnum.Eep) && StatusEffectService.TriggerStatusEffect(executingBeast, out string statusMessage))
        {
            return statusMessage;
        }
        else if (IsSecondTurn == true)
        {
            if (FirstMoveResult != null)
            {
                if (FirstMoveResult.FlinchEnemy)
                {
                    return turnResult = turnResult + "\n" + $"{executingBeast} flinched!";
                }    
            }
        }
        
        if (StatusEffectService.TriggerConfusion(executingBeast, out string confusionMessage))
        {
            if (confusionMessage != string.Empty)
            {
                turnResult = turnResult + "\n" + confusionMessage;
            }

            return turnResult;
        }

        if (confusionMessage != string.Empty)
        {
            turnResult = turnResult + "\n" + confusionMessage;
        }

        if (selectedMove is MoveBase selectedMoveBase)
        {
            var moveResult = selectedMoveBase.Execute(executingBeast, defendingBeast, out string executeMessage);
            if (moveResult.MoveHit == false)
            {
                turnResult = turnResult + "\n" + executeMessage;
                return turnResult;
            }

            if (IsSecondTurn == false)
            {
                FirstMoveResult = moveResult;
            }

            turnResult = turnResult + "\n" + executeMessage;

            if (defendingBeast.Ability is HitTakenAbilityBase ability)
            {
                turnResult = turnResult + ability.AbilityEffect(ref executingBeast, ref defendingBeast, selectedMoveBase);
            }

            if (defendingBeast.HeldItem is HitTakenItemBase item)
            {
                turnResult = turnResult + item.ItemEffect(executingBeast, defendingBeast, selectedMoveBase);
            }
        }

        return turnResult;
    }

    #region BattleChecks

    /// <summary>
    /// Checks the turnorder between two opponents
    /// </summary>
    /// <param name="prio1">Priority 1</param>
    /// <param name="prio2">Priority 2</param>
    /// <param name="init1">Initiative 1</param>
    /// <param name="init2">Initiative 2</param>
    /// <returns>1 = true | 2 = false</returns>
    public bool TurnOrder(int prio1, int prio2, int init1, int init2)
    {
        if (prio1 > prio2)
        {
            return true;
        }
        else if (prio1 < prio2)
        {
            return false;
        }
        else 
        {
            if (init1 > init2)
            {
                return true;
            }
            else if (init1 < init2)
            {
                return false;
            }

            // else Münzwurf
            Random random = new Random();
            return random.Next(1, 2) == 1 ? true : false;
        }
    }

    #endregion // BattleChecks
}