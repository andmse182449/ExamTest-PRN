using Repositories;
using Repositories.Models;

namespace Services
{
    public class AccountService
    {
        public Account? CheckLogin(String email, String password)
        {
            AccountRepository repo = new AccountRepository();
            Account? account = repo.Get(email);
            /*            if (account == null)
                            return null;
                        if (account.Password == password)
                            return account;*/
            return account != null && account.Password == password ? account : null;
        }
    }
}
