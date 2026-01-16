

using src.StatusEffect;

namespace src.Move.Base;


public class Switch : ActionBase
{
    #region Methods

    public BagBeastObject SwitchOut(BagBeastObject executingBeast, List<BagBeastObject> team)
    {
        // TODO: Auf Robin warten um zu wissen was hier rein muss
        executingBeast.Move1.Lock = false;
        executingBeast.Move2.Lock = false;
        executingBeast.Move3.Lock = false;
        executingBeast.Move4.Lock = false;

        executingBeast.Confusion = 0;

        BagBeastObject switchInBeast = executingBeast;

        int userInput = 0;
        //TODO: GetUserInput

        while (team[userInput - 1].StatusEffect == StatusEffectEnum.EternalEep || team[userInput - 1] == executingBeast)
        {
            //TODO: GetUserInput
            switchInBeast = team[userInput - 1];
        }

        return switchInBeast;
    }

    #endregion // Methods
}