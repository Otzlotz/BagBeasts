using BagBeasts.src.Beast;

using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace BagBeasts.src.Database
{
    /// <summary>
    /// Reader der DuckDB Datenbank
    /// </summary>
    public class duckreader
    {
        public List<BagBeast> BagBeastsFromDb()
        {
            try
            {
                DBConnection.Open();
                DuckDBCommand command = DBConnection.CreateCommand();
                command.CommandText = new string("SELECT * FROM Bagbeasts");

                DuckDBDataReader reader = command.ExecuteReader();
                List<BagBeast> retval = new List<BagBeast>();
                while (reader.Read())
                {
                    if (reader.IsDBNull(8))
                    {
                        retval.Add(new BagBeast
                            (
                                reader.GetString(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3),
                                reader.GetInt32(4),
                                reader.GetInt32(5),
                                reader.GetInt32(6),
                                (Type)reader.GetInt32(7)
                            ));
                    }
                    else
                    {
                        retval.Add(new BagBeast
                            (
                                reader.GetString(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3),
                                reader.GetInt32(4),
                                reader.GetInt32(5),
                                reader.GetInt32(6),
                                (Type)reader.GetInt32(7),
                                (Type)reader.GetInt32(8)
                            ));
                    }
                }
                return retval;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new List<BagBeast>();
            }
        }

        /// <summary>
        /// Holt sich ein BagBeast nach ID
        /// </summary>
        /// <param name="id">BagBeastId</param>
        /// <returns>BagBeast</returns>
        public BagBeast ReadBeastId(uint id)
        {
            try
            {
                DuckDBCommand command = DBConnection.CreateCommand();
                command.CommandText = new string("SELECT * FROM BAGBEAST WHERE ID =" + id);

                DuckDBDataReader reader = command.ExecuteReader();
                reader.Read();
                BagBeast retval;
                if (reader.IsDBNull(8))
                {
                    retval = new BagBeast
                        (
                            reader.GetString(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            reader.GetInt32(4),
                            reader.GetInt32(5),
                            reader.GetInt32(6),
                            (Type)reader.GetInt32(7)
                        );
                }
                else
                {
                    retval = new BagBeast
                        (
                            reader.GetString(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            reader.GetInt32(4),
                            reader.GetInt32(5),
                            reader.GetInt32(6),
                            (Type)reader.GetInt32(7),
                            (Type)reader.GetInt32(8)
                        );
                }
                return retval;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }



        /// <summary>
        /// Globales Field des Connectors
        /// </summary>
        private DuckDBConnection _connection;

        /// <summary>
        /// Property, damit Connector garantiert != null ist
        /// </summary>
        private DuckDBConnection DBConnection
        {
            get
            {
                if (_connection != null)
                {
                    return _connection;
                }
                else
                {
                    _connection = new DuckDBConnection("DataSource = BagBeasts.db");
                    return _connection;
                }
            }
        }
    }
}
