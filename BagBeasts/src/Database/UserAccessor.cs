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
        /// Holt den User anhand des Authtokens
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public bool userExist(string username)
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    bool retval = context.Users.Any(x => x.Name == username);
                    return retval;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
        
        /// <summary>
        /// Prüft, ob ein Auth token valide ist
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool validateAuthToken(string token)
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    bool retval = context.Users.Any(x => x.Auth == token);
                    return retval;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Ändert einen User in der Datenbank
        /// </summary>
        /// <param name="user">Userobjekt</param>
        /// <returns>Funktioniert y/n</returns>
        public bool UpdateUser(User user)
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    User retval = context.Users.Where(x => x.Id == user.Id).First() ?? new();
                    retval = user;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Schreibt einen User in die Datenbank
        /// </summary>
        /// <param name="user">Userobjekt</param>
        /// <returns>Funktioniert y/n</returns>
        public bool InsertUser(User user)
        {
            try
            {
                using (PostgresContext context = new PostgresContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
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
