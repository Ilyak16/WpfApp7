using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7.Models
{
    public class User : PropertyChangeBase
    {
        private int _id;
        private string _name;
        private int _rating;
        public int Id
        {
            get => _id;
            set
            {
                if (_id == value) return;
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public int Rating 
        { 
            get => _rating;
            set
            {
                if (_rating == value) return;
                _rating = value;
                OnPropertyChanged();
            }
        }


        public User() : this(-1, string.Empty) { }
        public User(int id, string name)
        {
            Id = id;
            _name = name;
        }
    }
}
