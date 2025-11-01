using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp7.Interfaces;

namespace WpfApp7.Models
{
    public class UserRepository : IReposotory<User>
    {
        private List<User> _data = 
        [
            new User(1, "Name1") {Rating = 123 },
            new User(2, "Name2"){Rating = 5},
            new User(3, "Name3"){Rating = -9999},
            new User(4, "Name4") { Rating = 500 },
        ];
        public IEnumerable<User> GetAll() => _data;
        public User? Get(int id) => _data.FirstOrDefault(u => u.Id == id);
        public bool Add(User user)
        {
            user.Id = GetNewId();
            if (_data.Any(u=> user.Name == u.Name))
                return false;
            _data.Add(user);
            return true;
        }
        private int GetNewId () => _data.Max(u => u.Id)+1;
    }
}
