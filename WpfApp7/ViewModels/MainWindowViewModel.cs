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
        private UserRepository _userRepository;
        private MyCommand _increaseScoreComand;
        private MyCommand _decreaseScoreComand;
        public MyCommand IncreaseScoreComand
        {
            get => _increaseScoreComand ??= new(
                (obj) =>
                {
                    if (obj is not User user) return;
                    user.Score++;
                }, 
                (obj) =>
                {
                    if (obj is not User user) return false;
                    return user.Score <= int.MaxValue;
                }
                );

        }
        public MyCommand DecreaseScoreComand
        {
            get => _decreaseScoreComand ??= new(
                (obj) =>
                {
                    if (obj is not User user) return;
                    user.Score--;
                },
                (obj) =>
                {
                    if (obj is not User user) return false;
                    return user.Score > 0;
                }
                );

        }
        public ObservableCollection<User> Users { get; set; }
        public MainWindowViewModel()
        {
            _userRepository = new();
            var collection = _userRepository.GetAll();
            Users = new ObservableCollection<User>(collection);
            Users.CollectionChanged += OnListChanged;
        }

        private void OnListChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (User user in e.NewItems)
                {
                    _userRepository.Add(user);
                }
            }
        }
    }
}
