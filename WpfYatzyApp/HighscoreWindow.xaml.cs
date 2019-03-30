using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace WpfYatzyApp
{
    /// <summary>
    /// Interaction logic for HighscoreWindow.xaml
    /// </summary>
    public partial class HighscoreWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _highscore1;
        public int Highscore1 { get { return _highscore1; } set { _highscore1 = value; OnPropertyChanged(); } }
        
        private int _highscore2;
        public int Highscore2 { get { return _highscore2; } set { _highscore2 = value; OnPropertyChanged(); } }

        private int _highscore3;
        public int Highscore3 { get { return _highscore3; } set { _highscore3 = value; OnPropertyChanged(); } }

        private int _highscore4;
        public int Highscore4 { get { return _highscore4; } set { _highscore4 = value; OnPropertyChanged(); } }

        private int _highscore5;
        public int Highscore5 { get { return _highscore5; } set { _highscore5 = value; OnPropertyChanged(); } }

        private int _highscore6;
        public int Highscore6 { get { return _highscore6; } set { _highscore6 = value; OnPropertyChanged(); } }

        private int _highscore7;
        public int Highscore7 { get { return _highscore7; } set { _highscore7 = value; OnPropertyChanged(); } }

        private int _highscore8;
        public int Highscore8 { get { return _highscore8; } set { _highscore8 = value; OnPropertyChanged(); } }

        private int _highscore9;
        public int Highscore9 { get { return _highscore9; } set { _highscore9 = value; OnPropertyChanged(); } }

        private int _highscore10;
        public int Highscore10 { get { return _highscore10; } set { _highscore10 = value; OnPropertyChanged(); } }

        public HighscoreWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
            DataContext = this;

            var highscores = Highscores.GetHighscoreList();

            Highscore1 = highscores[0];
            Highscore2 = highscores[1];
            Highscore3 = highscores[2];
            Highscore4 = highscores[3];
            Highscore5 = highscores[4];
            Highscore6 = highscores[5];
            Highscore7 = highscores[6];
            Highscore8 = highscores[7];
            Highscore9 = highscores[8];
            Highscore10 = highscores[9];
        }
    }
}
