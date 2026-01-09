using BagBeasts.src.Beast;
using System.Diagnostics;

namespace BagBeasts.src.Database
{
    public class UserAccessor
    {
        /// <summary>
        /// Besorgt einen User anhand seines Namens
        /// </summary>
        /// <param name="userName">Username</param>
        /// <returns>User</returns>
        public User GetUser(string userName)
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    User retval = context.Users.Where(x => x.Name == userName).First() ?? new();
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
        /// Schreibt einen User in die Datenbank
        /// </summary>
        /// <param name="user">Userobjekt</param>
        /// <returns>Funktioniert y/n</returns>
        public bool WriteUser(User user)
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    User retval = context.Users.Where(x => x == user).First() ?? new();
                    retval = user;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
