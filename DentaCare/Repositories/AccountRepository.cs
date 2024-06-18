using Repositories.Models;

namespace Repositories
{
    public class AccountRepository
    {
        public Account? Get(string Username)
        {
            DentaCareContext db = new DentaCareContext();
            return db.Accounts.FirstOrDefault(a => a.Username == Username);
        }
    }
}
