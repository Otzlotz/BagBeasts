using BagBeasts.src.Beast;
using BagBeasts.src.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using BagBeasts.src.Reader;
using System;
using System.Data.Common;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace BagBeasts.src.Database
{
    /// <summary>
    /// Reader der Postgres Datenbank
    /// </summary>
    public static class Datareader
    {
        /// <summary>s
        /// Holt sich alle Bagbeasts von der Datenbank
        /// </summary>
        /// <returns></returns>
        public static List<BagbeastsDB> GetBagBeasts()
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    var typesDict = context.Types.ToDictionary(t => t.Id);

                    List<BagbeastsDB> query = context.Bagbeasts.ToList();

                    return query;

                    //List<BagBeast> retval = new();
                    //foreach (var beast in query)
                    //{
                    //    // Type1 aus dem Dictionary mit Name holen
                    //    Type typ1 = typesDict[beast.Type1];

                    //    if (beast.Type2 != null && typesDict.TryGetValue(beast.Type2.Value, out var typ2))
                    //    {
                    //        retval.Add(new BagBeast(beast.Name, beast.Hp, beast.Atk, beast.Spa, beast.Def, beast.Spd, beast.Initiative, typ1, typ2, beast.Id));
                    //    }
                    //    else
                    //    {
                    //        retval.Add(new BagBeast(beast.Name, beast.Hp, beast.Atk, beast.Spa, beast.Def, beast.Spd, beast.Initiative, typ1, id: beast.Id));
                    //    }
                    //}
                    //return retval;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Holt sich ein Bagbeast von der Datenbank über die ID
        /// </summary>
        /// <param name="id">ID des BagBeasts</param>
        /// <returns>BagBeast from db</returns>
        public static BagbeastsDB GetBagBeastById(int id)
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    var typesDict = context.Types.ToDictionary(t => t.Id);
                    BagbeastsDB beast = context.Bagbeasts.Where(b => b.Id == id).FirstOrDefault();
                    return beast;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Holt sich alle Abilities von der Datenbank
        /// </summary>
        /// <returns>Liste der Abilities</returns>
        public static List<BagBeasts.AbilityDB> GetAblities()
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    List<BagBeasts.AbilityDB> retval = new();
                    foreach (var ability in context.Abilities)
                    {
                        retval.Add(ability);
                    }
                    return retval;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Holt sich alle Moves von der Datenbank
        /// </summary>
        /// <returns>Liste der Moves</returns>
        public static List<BagBeasts.MoveDB> GetMoves()
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    List<BagBeasts.MoveDB> retval = new();
                    foreach (var moves in context.Moves)
                    {
                        retval.Add(moves);
                    }
                    return retval;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Holt sich alle Moves von der Datenbank
        /// </summary>
        /// <returns>Liste der Moves</returns>
        public static List<BagBeasts.MoveDB> GetMoveById(int moveID)
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    List<BagBeasts.MoveDB> retval = new();
                    retval = context.Moves.Where(m => m.Id == moveID).ToList();
                    return retval;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Holt sich alle Moves zu einem Vieh von der Datenbank
        /// </summary>
        /// <param name="referenz">BeagBeast</param>
        /// <returns>Liste der Moves</returns>
        public static List<BagBeasts.MoveDB> GetMovesRef(BagbeastsDB referenz)
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    List<BagBeasts.MoveDB> retval = new();

                    BagbeastsDB beastfromDB = context.Bagbeasts.Include(s => s.Moves).Where(x => x.Id == referenz.Id).First();

                    if (beastfromDB != null && beastfromDB.Moves.Count > 0)
                    {
                        foreach (BagBeasts.MoveDB m in beastfromDB.Moves)
                        {
                            if (m.Id > 1 && (m.Id != 9 && m.Id != 18 && m.Id != 24 && m.Id != 43 && m.Id != 47 && m.Id != 56))
                            {
                                retval.Add(m);
                            }
                        }
                        return retval;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Holt alle Items von der Datenbank
        /// </summary>
        /// <returns>Liste der Items</returns>
        public static List<ItemDB> GetItems()
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    List<ItemDB> retval = new();
                    foreach (ItemDB item in context.Items)
                    {
                        retval.Add(item);
                    }
                    return retval;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
