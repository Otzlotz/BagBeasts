using System;
using System.Diagnostics.Eventing.Reader;
using src.Move.Base;
using src.Ability.AbilityBase;
using src.Item.ItemBase;
using src.StatusEffect;

namespace src.Battle;
public class Battle
{
    public BagBeastObject Player1Beast;

    public BagBeastObject Player2Beast;

    public List<BagBeastObject> TeamPlayer1 { get; }

    public List<BagBeastObject> TeamPlayer2 { get; }

    public MoveBase SelectedPlayer1Move { get; set; }

    public MoveBase SelectedPlayer2Move { get; set; }

    public Battle(BagBeastObject p1, BagBeastObject p2)
    {
        Player1Beast = p1;
        Player2Beast = p2;
    }

    private int _turnCounter;

    public void BattleInit(CancellationToken ct)
    {
        var effectService = new StatusEffectService();

        while (!ct.IsCancellationRequested)
        {
            // TODO: DO
           //SelectedPlayer1Move = Select();
           //SelectedPlayer2Move = Select();

           

            if (TurnOrder(SelectedPlayer1Move.Prio, SelectedPlayer2Move.Prio, Player1Beast.INT, Player2Beast.INT))
            {
                Turn(Player1Beast, Player2Beast, SelectedPlayer1Move, SelectedPlayer2Move);

                if (Player2Beast.StatusEffect != StatusEffectEnum.EternalEep)
                {
                    Turn(Player2Beast, Player1Beast, SelectedPlayer2Move, SelectedPlayer1Move);
                }
            }
            else
            {
                Turn(Player2Beast, Player1Beast, SelectedPlayer2Move, SelectedPlayer1Move);
                
                if (Player2Beast.StatusEffect != StatusEffectEnum.EternalEep)
                {
                    Turn(Player1Beast, Player2Beast, SelectedPlayer1Move, SelectedPlayer2Move);
                }
            }

            if (Player1Beast.Ability is RoundEndAbilityBase ability1 && Player1Beast.StatusEffect != StatusEffectEnum.EternalEep)
            {
                ability1.AbilityEffect(ref Player1Beast);
            }

            if (Player2Beast.Ability is RoundEndAbilityBase ability2 && Player1Beast.StatusEffect != StatusEffectEnum.EternalEep)
            {
                ability2.AbilityEffect(ref Player2Beast);
            }

            if (Player1Beast.HeldItem is RoundEndItemBase item1 && Player1Beast.StatusEffect != StatusEffectEnum.EternalEep)
            {
                item1.ItemEffect(Player1Beast);
            }

            if (Player2Beast.HeldItem is RoundEndItemBase item2 && Player1Beast.StatusEffect != StatusEffectEnum.EternalEep)
            {
                item2.ItemEffect(Player2Beast);
            }

            if ((Player1Beast.StatusEffect == StatusEffectEnum.Burn
                || Player1Beast.StatusEffect == StatusEffectEnum.FrostBurn
                || Player1Beast.StatusEffect == StatusEffectEnum.Poison
                || Player1Beast.StatusEffect == StatusEffectEnum.Toxic)
                    && Player1Beast.StatusEffect != StatusEffectEnum.EternalEep)
            {
                effectService.TriggerStatusEffect(Player1Beast, out string statusMessage);
            }

            if ((Player2Beast.StatusEffect == StatusEffectEnum.Burn
                || Player2Beast.StatusEffect == StatusEffectEnum.FrostBurn
                || Player2Beast.StatusEffect == StatusEffectEnum.Poison
                || Player2Beast.StatusEffect == StatusEffectEnum.Toxic)
                    && Player2Beast.StatusEffect != StatusEffectEnum.EternalEep)
            {
                effectService.TriggerStatusEffect(Player2Beast, out string statusMessage);
            }
        }
    }

    // TODO: DO
    /*
    public MoveBase Select(object movenumm)
    {

    }
    */

    private string Turn(BagBeastObject executingBeast, BagBeastObject defendingBeast, ActionBase selectedMove, MoveBase defenderMove)
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
            }
            else
            {
                Player2Beast = test.SwitchOut(executingBeast, TeamPlayer2);
            }
        }

        var effectService = new StatusEffectService();

        if ((executingBeast.StatusEffect == StatusEffectEnum.Paralysis || executingBeast.StatusEffect == StatusEffectEnum.Eep) && effectService.TriggerStatusEffect(executingBeast, out string statusMessage))
        {
            return statusMessage;
        }
        //else if (FLINCH)
        //{
        // return;
        //}
        
        if (effectService.TriggerConfusion(executingBeast, out string confusionMessage))
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

        if (selectedMove.Execute(executingBeast, defendingBeast, out string executeMessage) == false)
        {
            turnResult = turnResult + executeMessage;
            return turnResult;
        }

        turnResult = turnResult + executeMessage;

        //TODO: switch in Effekte bei U-Turn

        if (defendingBeast.Ability is HitTakenAbilityBase ability)
        {
            turnResult = turnResult + ability.AbilityEffect(ref executingBeast, ref defendingBeast, selectedMove);
        }

        if (defendingBeast.HeldItem is HitTakenItemBase item)
        {
            turnResult = turnResult + item.ItemEffect(executingBeast, defendingBeast, selectedMove);
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
    private bool TurnOrder(int prio1, int prio2, int init1, int init2)
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