

using src.StatusEffect;
using src.Item.ItemBase;
namespace src.Move.Base;


public class Switch : ActionBase
{
    #region Methods

    public BagBeastObject SwitchOut(BagBeastObject? executingBeast, List<BagBeastObject> team)
    {
        if (executingBeast != null)
        {
            // TODO: Auf Robin warten um zu wissen was hier rein muss
            executingBeast.Move1.Lock = false;
            executingBeast.Move2.Lock = false;
            executingBeast.Move3.Lock = false;
            executingBeast.Move4.Lock = false;

            executingBeast.Confusion = 0;
        }

        BagBeastObject switchInBeast = executingBeast;

        int userInput = 0;
        //TODO: GetUserInput

        while (team[userInput - 1].StatusEffect == StatusEffectEnum.EternalEep || team[userInput - 1] == executingBeast)
        {
            //TODO: GetUserInput
            switchInBeast = team[userInput - 1];

            if (switchInBeast.HeldItem is AssaultVest)
            {
                if (holderBeast.Move1.Move.Category == Category.Status)
                {
                    holderBeast.Move1.Lock = true;
                }
        
                if (holderBeast.Move2.Move.Category == Category.Status)
                {
                    holderBeast.Move2.Lock = true;
                }
        
                if (holderBeast.Move3.Move.Category == Category.Status)
                {
                    holderBeast.Move3.Lock = true;
                }
        
                if (holderBeast.Move4.Move.Category == Category.Status)
                {
                    holderBeast.Move4.Lock = true;
                }
            }
        }

        return switchInBeast;
    }

    #endregion // Methods
}