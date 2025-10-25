using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7.Models
{
    public class UserRepository
    {
        private List<User> _data = 
        [
            new User(1, "Name1"),
            new User(2, "Name2"),
            new User(3, "Name3"),
            new User(4, "Name4"),
        ];
        public List<User> GetAll() => _data;
        public User? Find(int id) => _data.FirstOrDefault(u => u.Id == id);
        public void Add(User user)
        {
            user.Id = GetNewId();
            _data.Add(user);
        }
        private int GetNewId () => _data.Max(u => u.Id)+1;
    }
}
