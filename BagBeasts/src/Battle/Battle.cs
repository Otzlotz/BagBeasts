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

    public void BattleInit(CancellationToken ct)
    {
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

            if (Player1Beast.Ability is RoundEndAbilityBase ability1)
            {
                ability1.AbilityEffect(ref Player1Beast);
            }

            if (Player2Beast.Ability is RoundEndAbilityBase ability2)
            {
                ability2.AbilityEffect(ref Player2Beast);
            }

            if (Player1Beast.HeldItem is RoundEndItemBase item1)
            {
                item1.ItemEffect(Player1Beast);
            }

            if (Player2Beast.HeldItem is RoundEndItemBase item2)
            {
                item2.ItemEffect(Player2Beast);
            }
        }
    }

    // TODO: DO
    /*
    public MoveBase Select(object movenumm)
    {

    }
    */

    private void Turn(BagBeastObject executingBeast, BagBeastObject defendingBeast, MoveBase selectedMove, MoveBase defenderMove)
    {
        if (selectedMove == null)
        {
            return;
        }

        //if (switchout) dann switch out
        //{
        //  Mach switch
        //  if (switchInBeast.Ability is SwitchInAbility)    
        //}
        //else mach mov

        if ((executingBeast.StatusEffect == StatusEffectEnum.Paralysis || executingBeast.StatusEffect == StatusEffectEnum.Eep) && StatusEffectService.TriggerStatusEffect(executingBeast))
        {
            return;
        }
        //else if (FLINCH)
        //{
        // return;
        //}
        else if (StatusEffectService.TriggerConfusion(executingBeast))
        {
            return;
        }

        ExecuteResult executeResult = selectedMove.Execute(executingBeast, defendingBeast);

        // switch in Effekte bei U-Turn

        if (defendingBeast.Ability is HitTakenAbilityBase ability)
        {
            ability.AbilityEffect(ref executingBeast, ref defendingBeast, selectedMove);
        }

        if (defendingBeast.HeldItem is HitTakenItemBase item)
        {
            item.ItemEffect(executingBeast, defendingBeast, selectedMove);
        }
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