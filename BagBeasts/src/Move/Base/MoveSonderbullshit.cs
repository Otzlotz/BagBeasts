

namespace src.Move.Base

public class MoveSonderbullshit
{
    #region Properties

    // TODO: Unsicher ob die Properties für den Sonderbullshit hier rein kommen oder woanders, aber Execute braucht es vermutlich.

    // Wie lange man nur diesen Move nutzen kann. Null ist Dauerhaft.
    public virtual uint? LockedToThisMoveDuration {get;}

    // Wie lange dieser Move nicht genutzt werden kann
    public virtual uint LockedDuration {get;}

    // Wie lange ein Move anhält (zb. Lichtschild)
    public virtual uint MoveDuration {get;}

    #endregion // Properties
}