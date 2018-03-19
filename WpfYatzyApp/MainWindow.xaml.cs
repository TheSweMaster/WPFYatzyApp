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

        public bool OnesTotalEnabled { get; set; }
        public bool TwosTotalEnabled { get; set; }
        public bool ThreesTotalEnabled { get; set; }
        public bool FoursTotalEnabled { get; set; }
        public bool FivesTotalEnabled { get; set; }
        public bool SixesTotalEnabled { get; set; }
        public bool OnePairTotalEnabled { get; set; }
        public bool TwoPairTotalEnabled { get; set; }
        public bool ThreeOfAKindTotalEnabled { get; set; }
        public bool FourOfAKindTotalEnabled { get; set; }
        public bool SmallStraightTotalEnabled { get; set; }
        public bool LargeStraightTotalEnabled { get; set; }
        public bool FullHouseTotalEnabled { get; set; }
        public bool ChanceTotalEnabled { get; set; }
        public bool YatzyTotalEnabled { get; set; }
        public bool BonusValueEnabled { get; set; }

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

        private int _smallSumTotal;
        public int SmallSumTotal { get { return _smallSumTotal; } set { _smallSumTotal = value; OnPropertyChanged(); } }

        private int _bonusValue;
        public int BonusValue { get { return _bonusValue; } set { _bonusValue = value; OnPropertyChanged(); } }

        private int _onePairTotal;
        public int OnePairTotal { get { return _onePairTotal; } set { _onePairTotal = value; OnPropertyChanged(); } }

        private int _twoPairTotal;
        public int TwoPairTotal { get { return _twoPairTotal; } set { _twoPairTotal = value; OnPropertyChanged(); } }

        private int _threeOfAKindTotal;
        public int ThreeOfAKindTotal { get { return _threeOfAKindTotal; } set { _threeOfAKindTotal = value; OnPropertyChanged(); } }

        private int _fourOfAKindTotal;
        public int FourOfAKindTotal { get { return _fourOfAKindTotal; } set { _fourOfAKindTotal = value; OnPropertyChanged(); } }

        private int _smallStraightTotal;
        public int SmallStraightTotal { get { return _smallStraightTotal; } set { _smallStraightTotal = value; OnPropertyChanged(); } }

        private int _largeStraightTotal;
        public int LargeStraightTotal { get { return _largeStraightTotal; } set { _largeStraightTotal = value; OnPropertyChanged(); } }

        private int _fullHouseTotal;
        public int FullHouseTotal { get { return _fullHouseTotal; } set { _fullHouseTotal = value; OnPropertyChanged(); } }

        private int _chanceTotal;
        public int ChanceTotal { get { return _chanceTotal; } set { _chanceTotal = value; OnPropertyChanged(); } }

        private int _yatzyTotal;
        public int YatzyTotal { get { return _yatzyTotal; } set { _yatzyTotal = value; OnPropertyChanged(); } }

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

        private List<Dice> diceList;
        private Dictionary<string, List<Dice>> diceDictionary;
        private Dictionary<string, bool> enabledTotalBonusDictionary;
        private Dictionary<string, bool> enabledTotalSpecialDictionary;
        private StringBuilder stringBuilder = new StringBuilder();
        private Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            diceList = new List<Dice>();
            diceDictionary = new Dictionary<string, List<Dice>>();
            enabledTotalBonusDictionary = new Dictionary<string, bool>();
            enabledTotalSpecialDictionary = new Dictionary<string, bool>();

            Dice1 = new Dice();
            Dice2 = new Dice();
            Dice3 = new Dice();
            Dice4 = new Dice();
            Dice5 = new Dice();

            RollEnabled = true;
            BonusValueEnabled = true;

            AddEnabledTotalToBonusDictionary(nameof(OnesTotalEnabled), OnesTotalEnabled = true);
            AddEnabledTotalToBonusDictionary(nameof(TwosTotalEnabled), TwosTotalEnabled = true);
            AddEnabledTotalToBonusDictionary(nameof(ThreesTotalEnabled), ThreesTotalEnabled = true);
            AddEnabledTotalToBonusDictionary(nameof(FoursTotalEnabled), FoursTotalEnabled = true);
            AddEnabledTotalToBonusDictionary(nameof(FivesTotalEnabled), FivesTotalEnabled = true);
            AddEnabledTotalToBonusDictionary(nameof(SixesTotalEnabled), SixesTotalEnabled = true);

            AddEnabledTotalToSpecialDictionary(nameof(OnePairTotalEnabled), OnePairTotalEnabled = true);
            AddEnabledTotalToSpecialDictionary(nameof(TwoPairTotalEnabled), TwoPairTotalEnabled = true);
            AddEnabledTotalToSpecialDictionary(nameof(ThreeOfAKindTotalEnabled), ThreeOfAKindTotalEnabled = true);
            AddEnabledTotalToSpecialDictionary(nameof(FourOfAKindTotalEnabled), FourOfAKindTotalEnabled = true);
            AddEnabledTotalToSpecialDictionary(nameof(SmallStraightTotalEnabled), SmallStraightTotalEnabled = true);
            AddEnabledTotalToSpecialDictionary(nameof(LargeStraightTotalEnabled), LargeStraightTotalEnabled = true);
            AddEnabledTotalToSpecialDictionary(nameof(FullHouseTotalEnabled), FullHouseTotalEnabled = true);
            AddEnabledTotalToSpecialDictionary(nameof(ChanceTotalEnabled), ChanceTotalEnabled = true);
            AddEnabledTotalToSpecialDictionary(nameof(YatzyTotalEnabled), YatzyTotalEnabled = true);

        }

        private void AddEnabledTotalToBonusDictionary(string name, bool value)
        {
            enabledTotalBonusDictionary.Add(name, value);
        }

        private void UpdateEnabledTotalToBonusDictionary(string name, bool value)
        {
            enabledTotalBonusDictionary[name] = value;
        }

        private void AddEnabledTotalToSpecialDictionary(string name, bool value)
        {
            enabledTotalSpecialDictionary.Add(name, value);
        }

        private void UpdateEnabledTotalToSpecialDictionary(string name, bool value)
        {
            enabledTotalSpecialDictionary[name] = value;
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
                OnesTotal = diceDictionary["ones"].Select(x => x.Value).Sum();
            }
            if (TwosTotalEnabled == true)
            {
                TwosTotal = diceDictionary["twos"].Select(x => x.Value).Sum();
            }
            if (ThreesTotalEnabled == true)
            {
                ThreesTotal = diceDictionary["threes"].Select(x => x.Value).Sum();
            }
            if (FoursTotalEnabled == true)
            {
                FoursTotal = diceDictionary["fours"].Select(x => x.Value).Sum();
            }
            if (FivesTotalEnabled == true)
            {
                FivesTotal = diceDictionary["fives"].Select(x => x.Value).Sum();
            }
            if (SixesTotalEnabled == true)
            {
                SixesTotal = diceDictionary["sixes"].Select(x => x.Value).Sum();
            }
            if (OnePairTotalEnabled == true)
            {
                int highestOnePairTotal = 0;
                foreach (var item in diceDictionary)
                {
                    if (item.Value.Count() >= 2)
                    {
                        var onePairTotal = item.Value.Select(x => x.Value).First() * 2;
                        if (highestOnePairTotal < onePairTotal)
                        {
                            highestOnePairTotal = onePairTotal;
                        }
                    }
                }
                OnePairTotal = highestOnePairTotal;
            }
            if (TwoPairTotalEnabled == true)
            {
                int twoPairTotal = 0;
                int amoutOfPairs = 0;
                foreach (var item in diceDictionary)
                {
                    if (item.Value.Count() >= 2)
                    {
                        amoutOfPairs++;
                        twoPairTotal += item.Value.Select(x => x.Value).First() * 2;
                    }
                }
                if (amoutOfPairs >= 2)
                {
                    TwoPairTotal = twoPairTotal;
                }
                else
                {
                    TwoPairTotal = 0;
                }
            }
            if (ThreeOfAKindTotalEnabled == true)
            {
                foreach (var item in diceDictionary)
                {
                    if (item.Value.Count() >= 3)
                    {
                        FourOfAKindTotal = item.Value.Select(x => x.Value).First() * 3;
                        break;
                    }
                    else
                    {
                        FourOfAKindTotal = 0;
                    }
                }
            }
            if (FourOfAKindTotalEnabled == true)
            {
                foreach (var item in diceDictionary)
                {
                    if (item.Value.Count() >= 4)
                    {
                        FourOfAKindTotal = item.Value.Select(x => x.Value).First() * 4;
                        break;
                    }
                    else
                    {
                        FourOfAKindTotal = 0;
                    }
                }
            }
            if (SmallStraightTotalEnabled == true)
            {
                if (diceDictionary["ones"].Count() == 1 && diceDictionary["twos"].Count() == 1 
                    && diceDictionary["threes"].Count() == 1 && diceDictionary["fours"].Count() == 1 
                    && diceDictionary["fives"].Count() == 1)
                {
                    SmallStraightTotal = diceList.Select(x => x.Value).Sum();
                }
                else
                {
                    SmallStraightTotal = 0;
                }
            }
            if (LargeStraightTotalEnabled == true)
            {
                if (diceDictionary["twos"].Count() == 1 && diceDictionary["threes"].Count() == 1
                    && diceDictionary["fours"].Count() == 1 && diceDictionary["fives"].Count() == 1
                    && diceDictionary["sixes"].Count() == 1)
                {
                    LargeStraightTotal = diceList.Select(x => x.Value).Sum();
                }
                else
                {
                    LargeStraightTotal = 0;
                }
            }
            if (FullHouseTotalEnabled == true)
            {
                bool hasThreeOfAKind = false;
                bool hasOnePair = false;
                foreach (var item in diceDictionary)
                {
                    if (item.Value.Count() == 3)
                    {
                        hasThreeOfAKind = true;
                    }
                    if (item.Value.Count() == 2)
                    {
                        hasOnePair = true;
                    }
                }
                if (hasThreeOfAKind && hasOnePair)
                {
                    FullHouseTotal = diceList.Select(x => x.Value).Sum();
                }
                else
                {
                    FullHouseTotal = 0;
                }
            }
            if (ChanceTotalEnabled == true)
            {
                ChanceTotal = diceList.Select(x => x.Value).Sum();
            }
            if (YatzyTotalEnabled == true)
            {
                foreach (var item in diceDictionary)
                {
                    if (item.Value.Count() == 5)
                    {
                        YatzyTotal = diceList.Select(x => x.Value).Sum() + 50;
                        MessageBox.Show($"You got Yatzy!", "Congratulations!");
                        break;
                    }
                    else
                    {
                        YatzyTotal = 0;
                    }
                }
            }

        }

        private void UpdateDiceList()
        {
            diceList.Clear();
            diceList.Add(Dice1);
            diceList.Add(Dice2);
            diceList.Add(Dice3);
            diceList.Add(Dice4);
            diceList.Add(Dice5);

            var onesList = diceList.Where(x => x.Value == 1).ToList();
            var twosList = diceList.Where(x => x.Value == 2).ToList();
            var threesList = diceList.Where(x => x.Value == 3).ToList();
            var foursList = diceList.Where(x => x.Value == 4).ToList();
            var fivesList = diceList.Where(x => x.Value == 5).ToList();
            var sixesList = diceList.Where(x => x.Value == 6).ToList();

            diceDictionary.Clear();
            diceDictionary.Add("ones", onesList);
            diceDictionary.Add("twos", twosList);
            diceDictionary.Add("threes", threesList);
            diceDictionary.Add("fours", foursList);
            diceDictionary.Add("fives", fivesList);
            diceDictionary.Add("sixes", sixesList);
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
            if (BonusValueEnabled == true)
            {
                if (SmallSumTotal >= 63)
                {
                    BonusValue = 50;
                    BonusValueEnabled = false;
                }
            }
        }

        private void CheckForCompletion()
        {
            var isAllBonusValuesFalse = enabledTotalBonusDictionary.Values.All(x => x.Equals(false));
            var isAllSpecialValuesFalse = enabledTotalSpecialDictionary.Values.All(x => x.Equals(false));
            if (isAllBonusValuesFalse == true && isAllSpecialValuesFalse == true)
            {
                MessageBox.Show($"You got a score of {SumTotal}!", "Congratulations!");
                RollEnabled = false;
                return;
            }
        }

        private void UpdateSmallSum(int smallSum)
        {
            SmallSumTotal += smallSum;
        }

        private void OnesTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            UpdateEnabledTotalToBonusDictionary(nameof(OnesTotalEnabled), OnesTotalEnabled = false);
            OnesTotal_Button.IsEnabled = false;
            UpdateSmallSum(OnesTotal);
            UpdateTotalSum(OnesTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void TwosTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            TwosTotalEnabled = false;
            UpdateEnabledTotalToBonusDictionary(nameof(TwosTotalEnabled), TwosTotalEnabled);
            TwosTotal_Button.IsEnabled = false;
            UpdateSmallSum(TwosTotal);
            UpdateTotalSum(TwosTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void ThreesTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            ThreesTotalEnabled = false;
            UpdateEnabledTotalToBonusDictionary(nameof(ThreesTotalEnabled), ThreesTotalEnabled);
            ThreesTotal_Button.IsEnabled = false;
            UpdateSmallSum(ThreesTotal);
            UpdateTotalSum(ThreesTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void FoursTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            FoursTotalEnabled = false;
            UpdateEnabledTotalToBonusDictionary(nameof(FoursTotalEnabled), FoursTotalEnabled);
            FoursTotal_Button.IsEnabled = false;
            UpdateSmallSum(FoursTotal);
            UpdateTotalSum(FoursTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void FivesTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            FivesTotalEnabled = false;
            UpdateEnabledTotalToBonusDictionary(nameof(FivesTotalEnabled), FivesTotalEnabled);
            FivesTotal_Button.IsEnabled = false;
            UpdateSmallSum(FivesTotal);
            UpdateTotalSum(FivesTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void SixesTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            SixesTotalEnabled = false;
            UpdateEnabledTotalToBonusDictionary(nameof(SixesTotalEnabled), SixesTotalEnabled);
            SixesTotal_Button.IsEnabled = false;
            UpdateSmallSum(SixesTotal);
            UpdateTotalSum(SixesTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void ResetGame_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            SumTotal = 0;
            SmallSumTotal = 0;
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
            OnePairTotal = 0;
            TwoPairTotal = 0;
            ThreeOfAKindTotal = 0;
            FourOfAKindTotal = 0;
            SmallStraightTotal = 0;
            LargeStraightTotal = 0;
            FullHouseTotal = 0;
            SmallStraightTotal = 0;
            LargeStraightTotal = 0;
            ChanceTotal = 0;
            YatzyTotal = 0;

            OnesTotal_Button.IsEnabled = true;
            TwosTotal_Button.IsEnabled = true;
            ThreesTotal_Button.IsEnabled = true;
            FoursTotal_Button.IsEnabled = true;
            FivesTotal_Button.IsEnabled = true;
            SixesTotal_Button.IsEnabled = true;
            OnePairTotal_Button.IsEnabled = true;
            TwoPairTotal_Button.IsEnabled = true;
            ThreeOfAKindTotal_Button.IsEnabled = true;
            FourOfAKindTotal_Button.IsEnabled = true;
            SmallStraightTotal_Button.IsEnabled = true;
            LargeStraightTotal_Button.IsEnabled = true;
            FullHouseTotal_Button.IsEnabled = true;
            ChanceTotal_Button.IsEnabled = true;
            YatzyTotal_Button.IsEnabled = true;

            var bonusKeys = enabledTotalBonusDictionary.Keys.ToList();
            foreach (var item in bonusKeys)
            {
                enabledTotalBonusDictionary[item] = true;
            }

            var speicalKeys = enabledTotalSpecialDictionary.Keys.ToList();
            foreach (var item in speicalKeys)
            {
                enabledTotalSpecialDictionary[item] = true;
            }

            OnesTotalEnabled = true;
            TwosTotalEnabled = true;
            ThreesTotalEnabled = true;
            FoursTotalEnabled = true;
            FivesTotalEnabled = true;
            SixesTotalEnabled = true;
            OnePairTotalEnabled = true;
            TwoPairTotalEnabled = true;
            ThreeOfAKindTotalEnabled = true;
            FourOfAKindTotalEnabled = true;
            SmallStraightTotalEnabled = true;
            LargeStraightTotalEnabled = true;
            FullHouseTotalEnabled = true;
            ChanceTotalEnabled = true;
            YatzyTotalEnabled = true;
        }

        private void OnePairTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            UpdateTotalSum(OnePairTotal);
            ResetKeepButtons();
            RollDices();
            OnePairTotalEnabled = false;
            UpdateEnabledTotalToSpecialDictionary(nameof(OnePairTotalEnabled), OnePairTotalEnabled);
            OnePairTotal_Button.IsEnabled = false;
            UpdateDiceList();
            CalculateTotals();
            
        }

        private void TwoPairTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            TwoPairTotalEnabled = false;
            UpdateEnabledTotalToSpecialDictionary(nameof(TwoPairTotalEnabled), TwoPairTotalEnabled);
            TwoPairTotal_Button.IsEnabled = false;
            UpdateTotalSum(TwoPairTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void ThreeOfAKindTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            ThreeOfAKindTotalEnabled = false;
            UpdateEnabledTotalToSpecialDictionary(nameof(ThreeOfAKindTotalEnabled), ThreeOfAKindTotalEnabled);
            ThreeOfAKindTotal_Button.IsEnabled = false;
            UpdateTotalSum(ThreeOfAKindTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void FourOfAKindTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            FourOfAKindTotalEnabled = false;
            UpdateEnabledTotalToSpecialDictionary(nameof(FourOfAKindTotalEnabled), FourOfAKindTotalEnabled);
            FourOfAKindTotal_Button.IsEnabled = false;
            UpdateTotalSum(FourOfAKindTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void SmallStraightTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            SmallStraightTotalEnabled = false;
            UpdateEnabledTotalToSpecialDictionary(nameof(SmallStraightTotalEnabled), SmallStraightTotalEnabled);
            SmallStraightTotal_Button.IsEnabled = false;
            UpdateTotalSum(SmallStraightTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void LargeStraightTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            LargeStraightTotalEnabled = false;
            UpdateEnabledTotalToSpecialDictionary(nameof(LargeStraightTotalEnabled), LargeStraightTotalEnabled);
            LargeStraightTotal_Button.IsEnabled = false;
            UpdateTotalSum(LargeStraightTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void FullHouseTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            FullHouseTotalEnabled = false;
            UpdateEnabledTotalToSpecialDictionary(nameof(FullHouseTotalEnabled), FullHouseTotalEnabled);
            FullHouseTotal_Button.IsEnabled = false;
            UpdateTotalSum(FullHouseTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void ChanceTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            ChanceTotalEnabled = false;
            UpdateEnabledTotalToSpecialDictionary(nameof(ChanceTotalEnabled), ChanceTotalEnabled);
            ChanceTotal_Button.IsEnabled = false;
            UpdateTotalSum(ChanceTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

        private void YatzyTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            YatzyTotalEnabled = false;
            UpdateEnabledTotalToSpecialDictionary(nameof(YatzyTotalEnabled), YatzyTotalEnabled);
            YatzyTotal_Button.IsEnabled = false;
            UpdateTotalSum(YatzyTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }

    }
}
