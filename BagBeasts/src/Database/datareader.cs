using BagBeasts.src.Beast;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
        public static List<BagBeast> GetBagBeasts()
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    var typesDict = context.Types.ToDictionary(t => t.Id);

                    List<Bagbeasts> query = context.Bagbeasts.ToList();

                    List<BagBeast> retval = new();
                    foreach (var beast in query)
                    {
                        // Type1 aus dem Dictionary mit Name holen
                        Type typ1 = typesDict[beast.Type1];

                        if (beast.Type2 != null && typesDict.TryGetValue(beast.Type2.Value, out var typ2))
                        {
                            retval.Add(new BagBeast(beast.Name, beast.Hp, beast.Atk, beast.Spa, beast.Def, beast.Spd, beast.Initiative, typ1, typ2, beast.Id));
                        }
                        else
                        {
                            retval.Add(new BagBeast(beast.Name, beast.Hp, beast.Atk, beast.Spa, beast.Def, beast.Spd, beast.Initiative, typ1, id: beast.Id));
                        }
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
        /// Holt sich alle Abilities von der Datenbank
        /// </summary>
        /// <returns>Liste der Abilities</returns>
        public static List<Ability> GetAblities()
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    List<Ability> retval = new();
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
        public static List<Move> GetMoves()
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    List<Move> retval = new();
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
        /// Holt sich alle Moves zu einem Vieh von der Datenbank
        /// </summary>
        /// <param name="referenz">BeagBeast</param>
        /// <returns>Liste der Moves</returns>
        public static List<Move> GetMovesRef(BagBeast referenz)
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    List<Move> retval = new();
                    foreach (Move moves in context.Bagbeasts.Where(x => x.Id == referenz.ID).First().Moves)
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
        /// Holt alle Items von der Datenbank
        /// </summary>
        /// <returns>Liste der Items</returns>
        public static List<Item> GetItems()
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    List<Item> retval = new();
                    foreach (Item item in context.Items)
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
