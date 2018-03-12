using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfYatzyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Dice Dice1 { get; set; }
        public Dice Dice2 { get; set; }
        public Dice Dice3 { get; set; }
        public Dice Dice4 { get; set; }
        public Dice Dice5 { get; set; }
        public ObservableCollection<Dice> DiceList { get; set; }

        public bool OnesTotalEnabled { get; set; }
        public bool TwosTotalEnabled { get; set; }
        public bool ThreesTotalEnabled { get; set; }
        public bool FoursTotalEnabled { get; set; }
        public bool FivesTotalEnabled { get; set; }
        public bool SixesTotalEnabled { get; set; }

        private int _onesTotal;
        public int OnesTotal { get { return _onesTotal; } set { _onesTotal = value; OnPropertyChanged(); } }

        private int _twosTotal;
        public int TwosTotal { get { return _twosTotal; } set { _twosTotal = value; OnPropertyChanged(); } }

        private int _threesTotal;
        public int ThreesTotal { get { return _threesTotal; } set { _threesTotal = value; OnPropertyChanged(); } }

        private int _foursTotal;
        public int FoursTotal { get { return _foursTotal; } set { _foursTotal = value; OnPropertyChanged(); } }

        private int _fivesTotal;
        public int FivesTotal { get { return _fivesTotal; } set { _fivesTotal = value; OnPropertyChanged(); } }

        private int _sixesTotal;
        public int SixesTotal { get { return _sixesTotal; } set { _sixesTotal = value; OnPropertyChanged(); } }

        private int _sumTotal;
        public int SumTotal { get { return _sumTotal; } set { _sumTotal = value; OnPropertyChanged(); } }

        private bool _rollEnabled;
        public bool RollEnabled
        {
            get { return _rollEnabled; }
            set { _rollEnabled = value; OnPropertyChanged(); }
        }

        private int _rollCount;
        public int RollCount { get { return _rollCount; } set { _rollCount = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private StringBuilder stringBuilder = new StringBuilder();
        private Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            DiceList = new ObservableCollection<Dice>();
            Dice1 = new Dice();
            Dice2 = new Dice();
            Dice3 = new Dice();
            Dice4 = new Dice();
            Dice5 = new Dice();

            RollEnabled = true;

            OnesTotalEnabled = true;
            TwosTotalEnabled = true;
            ThreesTotalEnabled = true;
            FoursTotalEnabled = true;
            FivesTotalEnabled = true;
            SixesTotalEnabled = true;
            
        }

        private void Roll_Button_Click(object sender, RoutedEventArgs e)
        {
            RollDices();

            if (RollCount >= 3)
            {
                RollEnabled = false;
            }

            UpdateDiceList();
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            if (OnesTotalEnabled == true)
            {
                OnesTotal = DiceList.Where(x => x.Value == 1).Select(x => x.Value).Sum();
                if (OnesTotal == 5)
                {
                    MessageBox.Show("You got Yatzy!", "Congratulations!");
                }
            }
            if (TwosTotalEnabled == true)
            {
                TwosTotal = DiceList.Where(x => x.Value == 2).Select(x => x.Value).Sum();
                if (TwosTotal == 10)
                {
                    MessageBox.Show("You got Yatzy!", "Congratulations!");
                }
            }
            if (ThreesTotalEnabled == true)
            {
                ThreesTotal = DiceList.Where(x => x.Value == 3).Select(x => x.Value).Sum();
                if (ThreesTotal == 15)
                {
                    MessageBox.Show("You got Yatzy!", "Congratulations!");
                }
            }
            if (FoursTotalEnabled == true)
            {
                FoursTotal = DiceList.Where(x => x.Value == 4).Select(x => x.Value).Sum();
                if (FoursTotal == 20)
                {
                    MessageBox.Show("You got Yatzy!", "Congratulations!");
                }
            }
            if (FivesTotalEnabled == true)
            {
                FivesTotal = DiceList.Where(x => x.Value == 5).Select(x => x.Value).Sum();
                if (FivesTotal == 25)
                {
                    MessageBox.Show("You got Yatzy!", "Congratulations!");
                }
            }
            if (SixesTotalEnabled == true)
            {
                SixesTotal = DiceList.Where(x => x.Value == 6).Select(x => x.Value).Sum();
                if (SixesTotal == 30)
                {
                    MessageBox.Show("You got Yatzy!", "Congratulations!");
                }
            }
        }

        private void UpdateDiceList()
        {
            DiceList.Clear();
            DiceList.Add(Dice1);
            DiceList.Add(Dice2);
            DiceList.Add(Dice3);
            DiceList.Add(Dice4);
            DiceList.Add(Dice5);
        }

        private void RollDices()
        {
            if (Dice1.Keep == false)
            {
                Dice1.Value = RollDice();
            }
            if (Dice2.Keep == false)
            {
                Dice2.Value = RollDice();
            }
            if (Dice3.Keep == false)
            {
                Dice3.Value = RollDice();
            }
            if (Dice4.Keep == false)
            {
                Dice4.Value = RollDice();
            }
            if (Dice5.Keep == false)
            {
                Dice5.Value = RollDice();
            }
            RollCount++;
        }

        private int RollDice()
        {
            return r.Next(1, 7);
        }
        #region Unchecked Toggle Region
        private void ToggleButton1_Checked(object sender, RoutedEventArgs e)
        {
            Dice1.Keep = true;
        }

        private void ToggleButton1_Unchecked(object sender, RoutedEventArgs e)
        {
            Dice1.Keep = false;
        }

        private void ToggleButton2_Checked(object sender, RoutedEventArgs e)
        {
            Dice2.Keep = true;
        }

        private void ToggleButton2_Unchecked(object sender, RoutedEventArgs e)
        {
            Dice2.Keep = false;
        }

        private void ToggleButton3_Checked(object sender, RoutedEventArgs e)
        {
            Dice3.Keep = true;
        }

        private void ToggleButton3_Unchecked(object sender, RoutedEventArgs e)
        {
            Dice3.Keep = false;
        }

        private void ToggleButton4_Checked(object sender, RoutedEventArgs e)
        {
            Dice4.Keep = true;
        }

        private void ToggleButton4_Unchecked(object sender, RoutedEventArgs e)
        {
            Dice4.Keep = false;
        }

        private void ToggleButton5_Checked(object sender, RoutedEventArgs e)
        {
            Dice5.Keep = true;
        }

        private void ToggleButton5_Unchecked(object sender, RoutedEventArgs e)
        {
            Dice5.Keep = false;
        }
        #endregion
        private void Reset_Count_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            ResetKeepButtons();
            RollDices();
        }

        private void ResetKeepButtons()
        {
            Dice1.Keep = false;
            ToggleButton1.IsChecked = false;
            Dice2.Keep = false;
            ToggleButton2.IsChecked = false;
            Dice3.Keep = false;
            ToggleButton3.IsChecked = false;
            Dice4.Keep = false;
            ToggleButton4.IsChecked = false;
            Dice5.Keep = false;
            ToggleButton5.IsChecked = false;
        }
        private void UpdateTotalSum(int total)
        {
            SumTotal += total;
        }

        private void OnesTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            UpdateTotalSum(OnesTotal);
            ResetKeepButtons();
            RollDices();
            OnesTotalEnabled = false;
            OnesTotal_Button.IsEnabled = false;
            UpdateDiceList();
            CalculateTotals();
        }

        private void TwosTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            UpdateTotalSum(TwosTotal);
            ResetKeepButtons();
            RollDices();
            TwosTotalEnabled = false;
            TwosTotal_Button.IsEnabled = false;
            UpdateDiceList();
            CalculateTotals();
        }

        private void ThreesTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            UpdateTotalSum(ThreesTotal);
            ResetKeepButtons();
            RollDices();
            ThreesTotalEnabled = false;
            ThreesTotal_Button.IsEnabled = false;
            UpdateDiceList();
            CalculateTotals();
        }

        private void FoursTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            UpdateTotalSum(FoursTotal);
            ResetKeepButtons();
            RollDices();
            FoursTotalEnabled = false;
            FoursTotal_Button.IsEnabled = false;
            UpdateDiceList();
            CalculateTotals();
        }

        private void FivesTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            UpdateTotalSum(FivesTotal);
            ResetKeepButtons();
            RollDices();
            FivesTotalEnabled = false;
            FivesTotal_Button.IsEnabled = false;
            UpdateDiceList();
            CalculateTotals();
        }

        private void SixesTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            UpdateTotalSum(SixesTotal);
            ResetKeepButtons();
            RollDices();
            SixesTotalEnabled = false;
            SixesTotal_Button.IsEnabled = false;
            UpdateDiceList();
            CalculateTotals();
        }

        private void ResetGame_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SumTotal >= 63)
            {
                MessageBox.Show($"You got a score of over 63 and will get a bonus of 50 points!", "Congratulations!");
            }

            RollCount = 0;
            RollEnabled = true;
            SumTotal = 0;
            ResetKeepButtons();
            ResetScoreButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void ResetScoreButtons()
        {
            OnesTotal = 0;
            TwosTotal = 0;
            ThreesTotal = 0;
            FoursTotal = 0;
            FivesTotal = 0;
            SixesTotal = 0;

            OnesTotal_Button.IsEnabled = true;
            TwosTotal_Button.IsEnabled = true;
            ThreesTotal_Button.IsEnabled = true;
            FoursTotal_Button.IsEnabled = true;
            FivesTotal_Button.IsEnabled = true;
            SixesTotal_Button.IsEnabled = true;

            OnesTotalEnabled = true;
            TwosTotalEnabled = true;
            ThreesTotalEnabled = true;
            FoursTotalEnabled = true;
            FivesTotalEnabled = true;
            SixesTotalEnabled = true;
        }

    }
}
