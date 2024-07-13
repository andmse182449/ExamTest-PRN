
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repositories
{
    public class AccountRepository
    {
        ExamTestContext _context;
        public Account? Get(string username)
        {
            ExamTestContext db = new ExamTestContext();
            return db.Accounts.FirstOrDefault(a => a.Username == username);
        }
        public List<Account> GetAll()
        {
            ExamTestContext db = new ExamTestContext();
            return db.Accounts.Where(x => x.Role != 2).ToList();
        }
        public void Create(Account account)

        {
            _context = new ExamTestContext();
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
        public void Update(Account account)
        {
            _context = new ExamTestContext();
            _context.Update(account);
            _context.SaveChanges();
        }
        public void Delete(string username)
        {
            _context = new ExamTestContext();
            var book = _context.Accounts.FirstOrDefault(x => x.Username.Equals(username));
            if (book != null)
            {
                _context.Remove(book);
                _context.SaveChanges();
            }

        }


    }
}
