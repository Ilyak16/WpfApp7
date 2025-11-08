using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp7.Models;
using WpfApp7.Utils;

namespace WpfApp7.ViewModels
{
    internal class MainWindowViewModel : PropertyChangeBase
    {        
        private readonly UserRepository _userRepository;
        private MyCommand _increaseScoreComand;
        private MyCommand _decreaseScoreComand;
        //public MyCommand IncreaseScoreComand
        //{
        //    get => _increaseScoreComand ??= new(
        //        (obj) =>
        //        {
        //            if (obj is not User user) return;
        //            user.Rating++;
        //        }, 
        //        (obj) =>
        //        {
        //            if (obj is not User user) return false;
        //            return user.Rating <= int.MaxValue;
        //        }
        //        );

        //}
        //public MyCommand DecreaseScoreComand
        //{
        //    get => _decreaseScoreComand ??= new(
        //        (obj) =>
        //        {
        //            if (obj is not User user) return;
        //            user.Rating--;
        //        },
        //        (obj) =>
        //        {
        //            if (obj is not User user) return false;
        //            return user.Rating > 0;
        //        }
        //        );
        //}
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users 
        {
            get => _users;
            set
            {
                if (value != null) _users = value;
            } 
        }
        public MainWindowViewModel()
        {
            _userRepository = new();
            var collection = _userRepository.GetAll();
            Users = new ObservableCollection<User>(collection);
            Users.CollectionChanged += OnListChanged;
            Users.Add(new User(0, "Jeck", 100));
        }

        private void OnListChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (User user in e.NewItems)
                {
                    if (!_userRepository.Add(user))
                    {
                        Users = new(Users.Except([user]));
                    }
                    Users.Add(new User(0, "Jeck", 100));

                }
            }
        }
    }
}
