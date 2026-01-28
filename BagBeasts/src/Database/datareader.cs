using BagBeasts.src.Beast;
using BagBeasts.src.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Data.Common;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Xml.Linq;
using BagBeasts.Entities;
using BagBeasts.Data;

namespace BagBeasts.Database
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
        public static List<Beast> GetBagBeasts()
        {
            try
            {
                using (BagBeastsContext context = new BagBeastsContext())
                {
                    var typesDict = context.Types.ToDictionary(t => t.Id);

                    List<Beast> query = context.Beasts.ToList();

                    return query;
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
        public static Beast GetBagBeastById(int id)
        {
            try
            {
                using (BagBeastsContext context = new BagBeastsContext())
                {
                    var typesDict = context.Types.ToDictionary(t => t.Id);
                    Beast beast = context.Beasts.Where(b => b.Id == id).FirstOrDefault();
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
        public static List<Ability> GetAblities()
        {
            try
            {
                using (BagBeastsContext context = new BagBeastsContext())
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
                using (BagBeastsContext context = new BagBeastsContext())
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
        /// Holt sich alle Moves von der Datenbank
        /// </summary>
        /// <returns>Liste der Moves</returns>
        public static List<Move> GetMoveById(int moveID)
        {
            try
            {
                using (BagBeastsContext context = new BagBeastsContext())
                {
                    List<Move> retval = new();
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
        public static List<Move> GetMovesRef(Beast referenz)
        {
            try
            {
                using (BagBeastsContext context = new BagBeastsContext())
                {
                    List<Bbmove> temp = context.Bbmoves
                        .Include(x => x.Move)
                        .Where(x => x.Bbid == referenz.Id)
                        .ToList();

                    return temp.Select(bbmove => bbmove.Move).ToList();
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
                using (BagBeastsContext context = new BagBeastsContext())
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
