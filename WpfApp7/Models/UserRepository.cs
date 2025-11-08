using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp7.Domain;
using WpfApp7.Interfaces;

namespace WpfApp7.Models
{
    public class UserRepository : IReposotory<User>
    {
        private readonly string conn = "Data Source = mydatabase.db";
        public IEnumerable<User> GetAll()
        {
            try
            {
                using var context = new MyDataBaseContext(conn);
                return context.Users.ToList();
            }
            catch (Exception e) { return []; }
        }
        public User? Get(int id)
        {
            try
            {
                using var context = new MyDataBaseContext(conn);
                return context.Users.FirstOrDefault(u => u.Id == id);
            }
            catch { return null; }
        }
        public bool Add(User user)
        {
            try
            {
                using var context = new MyDataBaseContext(conn);
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public bool Remove(int id)
        {
            try
            {
                using var context = new MyDataBaseContext(conn);
                User? user = context.Find<User>(id);
                if (user != null)
                {
                    context.Remove(user);
                    context.SaveChanges();
                }
                return true;
            }
            catch { return false; }
            ;
        }
        public bool Update(int id, User entity)
        {
            try
            {
                using var context = new MyDataBaseContext(conn);
                User? user = context.Find<User>(id);

                if (user != null && user.Id == entity.Id)
                {
                    user.Name = entity.Name;
                    user.Rating = entity.Rating;
                    //Помечаем для модефикации так
                    context.Update(user);
                    // Либо так
                    //context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
                return true;
            }
            catch { return false; };
        }
    }
}
