using BagBeasts.src.Beast;
using Microsoft.EntityFrameworkCore;
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
    public class Datareader
    {
        /// <summary>
        /// Holt sich alle Bagbeasts von der Datenbank
        /// </summary>
        /// <returns></returns>
        public List<BagBeast> GetBagBeasts()
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    List<BagBeast> retval = new();
                    foreach (var beast in context.Bagbeasts)
                    {
                        Type typ1 = new Type
                        {
                            Id = beast.Type1
                        };
                        if (beast.Type2 != null)
                        {
                            Type typ2 = new Type
                            {
                                Id = beast.Type2.Value
                            };
                            retval.Add(new BagBeast(beast.Name, beast.Hp, beast.Atk, beast.Spa, beast.Def, beast.Spd, beast.Initiative, typ1, typ2));
                        }
                        else
                        {
                            retval.Add(new BagBeast(beast.Name, beast.Hp, beast.Atk, beast.Spa, beast.Def, beast.Spd, beast.Initiative, typ1));
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
        public List<Ability> GetAblities()
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
        public List<Move> GetMoves()
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
        public List<Move> GetMovesRef(BagBeast referenz)
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
        public List<Item> GetItems()
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
