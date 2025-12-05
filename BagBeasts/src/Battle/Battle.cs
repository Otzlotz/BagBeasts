using System;
using System.Diagnostics.Eventing.Reader;
using src.Move.Base;

namespace src.Battle;
public class Battle
{
    public BagBeastObject Player1 { get; set; }

    public BagBeastObject Player2 { get; set; }

    public readonly List<BagBeastObject> TeamPlayer1 { get; }

    public readonly List<BagBeastObject> TeamPlayer2 { get; }

    public MoveBase SelectedPlayer1Move { get; set; }

    public MoveBase SelectedPlayer2Move { get; set; }

    public Battle(BagBeastObject p1, BagBeastObject p2)
    {
        Player1 = p1;
        Player2 = p2;
    }

    public void BattleInit(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            SelectedPlayer1Move = Select();
            SelectedPlayer2Move = Select();

            if (TurnOrder(SelectedPlayer1Move.Prio, SelectedPlayer2Move.Prio, Player1.INT, Player2.INT))
            {
                Turn(Player1, Player2, SelectedPlayer1Move, SelectedPlayer2Move, switchInBeast);

                if (Player2.StatusEffect == StatusEffect.EternalEep)
                {
                    Turn(Player2, Player1, SelectedPlayer2Move, SelectedPlayer1Move, switchInBeast);
                }
            }
            else
            {
                Turn(Player2, Player1, SelectedPlayer2Move, SelectedPlayer1Move, switchInBeast);
                
                if (Player2.StatusEffect == StatusEffect.EternalEep)
                {
                    Turn(Player1, Player2, SelectedPlayer1Move, SelectedPlayer2Move, switchInBeast);
                }
            }

            //if(Player1.)
        }
    }

    public MoveBase Select(object movenumm)
    {

    }

    private void Turn(BagBeastObject executingBeast, BagBeastObject defendingBeast, MoveBase selectedMove)
    {
        if (selectedMove != null)
        {
            //if (switchout) dann switch out
            //{
            //  Mach switch
            //  if (switchInBeast.Ability is SwitchInAbility)    
            //}
            //else mach mov

            if (executingBeast.StatusEffect = StatusEffect.Paralysis)
            {
                
            }
            else if (executingBeast.StatusEffect = StatusEffect.Eep)
            {
                
            }
            //else if (FLINCH)
            //{
            //}

            if (executingBeast.Confusion > 0)
            {
                
            }

            selectedMove.Execute(executingBeast, defendingBeast);

            //if (defendingBeast.Ability is OnHitAbility)
            //if (defendingBeast.Item is OnHitItem)

            //if (selectedMove is SwitchOutMove)
            //if (switchInBeast.Ability is SwitchInAbility) 

        }
    }

    #region BattleChecks
    /// <summary>
    /// Checks the hit condition
    /// </summary>
    /// <param name="accuracy">Accuracy after Calculation</param>
    /// <returns>Hit? y/n</returns>
    private bool IsHit(int? accuracy)
    {
        if (accuracy.HasValue)
        {
            Random rnd = new Random();
            int random = rnd.Next(1, 100);
            if (random > accuracy)
            {
                return false;
            }
            return true;
        }
        return true;
    }

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