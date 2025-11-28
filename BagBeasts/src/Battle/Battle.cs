using System;
using System.Diagnostics.Eventing.Reader;
using src.Move.Base;

namespace src.Battle;
public class Battle
{
    public BagBeastObject Player1 { get; set; }

    public BagBeastObject Player2 { get; set; }


    public Battle(BagBeastObject p1, BagBeastObject p2)
    {
        Player1 = p1;
        Player2 = p2;
    }

    public void BattleInit(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {

        }
    }

    public void Select(object movenumm)
    {

    }

    private void Turn(BagBeastObject beast, EquippedMove selectedMove)
    {
        if (selectedMove != null)
        {
            //if (selectedMove == switched)


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