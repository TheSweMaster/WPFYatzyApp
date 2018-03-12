using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfYatzyApp
{
    public class Dice : INotifyPropertyChanged
    {
        //public int Id { get; set; }
        //public int Value { get; set; }
        //public bool Keep { get; set; }

        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _keep;
        public bool Keep
        {
            get { return _keep; }
            set
            {
                _keep = value;
                OnPropertyChanged();
            }
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }


        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

