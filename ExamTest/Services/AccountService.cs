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
            if (account != null && account.Status == 0 && account.Password == password)
            {
                return account;
            }
            else return null;
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

        public int CountStudent()
        {
            return _repository.GetAll().Where(b => b.Role == 0).ToList().Count();
        }
        public int CountTeacher()
        {
            return _repository.GetAll().Where(b => b.Role == 1).ToList().Count();
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
        public void DisbaleAccount(String username)
        {
            var account = GetAccount(username);
            account.Status = 1;
            _repository.Update(account);
        }
        public void EnableAccount(String username)
        {
            var account = GetAccount(username);
            account.Status = 0;
            _repository.Update(account);
        }

    }
}
