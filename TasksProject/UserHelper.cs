using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksProject
{
    public class UserHelper : INotifyPropertyChanged
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string _Fulname;
        public string Fulname
        {
            get
            {
                return _Fulname;
            }

            set
            {
                _Fulname = value;
                OnPropertyChanged(nameof(Fulname));
            }
        }
        private string _Authan;
        public string Authan
        {
            get
            {
                return _Authan;
            }
            set
            {
                _Authan = value;
                OnPropertyChanged(nameof(Authan));
            }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set
            {
                _Phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        private Nullable<int> _Userid;
        public Nullable<int> Userid
        {
            get { return _Userid; }

            set
            {
                _Userid = value;
                OnPropertyChanged(nameof(Userid));
            }
        }
        public Nullable<double> _Price;
        public Nullable<double> Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public Nullable<double> _PriceRate;
        public Nullable<double> PriceRate
        {
            get { return _PriceRate; }
            set
            {
                _PriceRate = value;
                OnPropertyChanged(nameof(_PriceRate));
            }
        }
        public List<UserHelper> Adds { get; set; }
        public int SelectedAddId { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private UserHelper _SelectedUser;
        public UserHelper SelectedUser
        {
            get { return _SelectedUser; }
            set
            {
                _SelectedUser = value;
                // Optionally, you can add any additional logic here
                OnPropertyChanged(nameof(SelectedUser)); // Implement INotifyPropertyChanged if needed
            }
        }

    }

}
