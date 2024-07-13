using Repositories;
using Repository.Models;


namespace Services
{
    public class AccountService
    {
        AccountRepository _repository = new AccountRepository();
        public Account? CheckLogin(String user, String password)
        {
            Account? account = _repository.Get(user);
            return account != null && account.Password == password ? account : null;
        }
        public List<Account> GetAllAccounts()
        {
            return _repository.GetAll();
        }
        public List<Account> Search(string keyword)
        {
            return _repository.GetAll().Where(b => b.FullName.ToLower().Contains(keyword.ToLower()) ||
                                              b.Username.ToLower().Contains(keyword.ToLower())).ToList();

        }

        public void Delete(String username)
        {
            _repository.Delete(username);

        }
        public Account GetAccount(String username)
        {
            return _repository.Get(username);

        }
        public void AddAccount(Account account)
        {
            _repository.Create(account);

        }
        public void UpdateAccount(Account account)
        {
            _repository.Update(account);

        }
    }
}
