using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

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

        private List<Dice> _diceList;
        private Dictionary<string, List<Dice>> _diceDictionary;
        private Dictionary<string, bool> _totalEnabledRegularFieldsDictionary;
        private Dictionary<string, bool> _totalEnabledSpecialFieldsDictionary;
        private StringBuilder stringBuilder = new StringBuilder();
        private Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            _diceList = new List<Dice>();
            _diceDictionary = new Dictionary<string, List<Dice>>();
            _totalEnabledRegularFieldsDictionary = new Dictionary<string, bool>();
            _totalEnabledSpecialFieldsDictionary = new Dictionary<string, bool>();

            Dice1 = new Dice();
            Dice2 = new Dice();
            Dice3 = new Dice();
            Dice4 = new Dice();
            Dice5 = new Dice();

            RollEnabled = true;
            BonusValueEnabled = true;

            AddTotalEnabledRegularFieldsDictionary(nameof(OnesTotalEnabled), OnesTotalEnabled = true);
            AddTotalEnabledRegularFieldsDictionary(nameof(TwosTotalEnabled), TwosTotalEnabled = true);
            AddTotalEnabledRegularFieldsDictionary(nameof(ThreesTotalEnabled), ThreesTotalEnabled = true);
            AddTotalEnabledRegularFieldsDictionary(nameof(FoursTotalEnabled), FoursTotalEnabled = true);
            AddTotalEnabledRegularFieldsDictionary(nameof(FivesTotalEnabled), FivesTotalEnabled = true);
            AddTotalEnabledRegularFieldsDictionary(nameof(SixesTotalEnabled), SixesTotalEnabled = true);

            AddTotalEnabledSpecialFieldsDictionary(nameof(OnePairTotalEnabled), OnePairTotalEnabled = true);
            AddTotalEnabledSpecialFieldsDictionary(nameof(TwoPairTotalEnabled), TwoPairTotalEnabled = true);
            AddTotalEnabledSpecialFieldsDictionary(nameof(ThreeOfAKindTotalEnabled), ThreeOfAKindTotalEnabled = true);
            AddTotalEnabledSpecialFieldsDictionary(nameof(FourOfAKindTotalEnabled), FourOfAKindTotalEnabled = true);
            AddTotalEnabledSpecialFieldsDictionary(nameof(SmallStraightTotalEnabled), SmallStraightTotalEnabled = true);
            AddTotalEnabledSpecialFieldsDictionary(nameof(LargeStraightTotalEnabled), LargeStraightTotalEnabled = true);
            AddTotalEnabledSpecialFieldsDictionary(nameof(FullHouseTotalEnabled), FullHouseTotalEnabled = true);
            AddTotalEnabledSpecialFieldsDictionary(nameof(ChanceTotalEnabled), ChanceTotalEnabled = true);
            AddTotalEnabledSpecialFieldsDictionary(nameof(YatzyTotalEnabled), YatzyTotalEnabled = true);

        }

        private void AddTotalEnabledRegularFieldsDictionary(string name, bool value)
        {
            _totalEnabledRegularFieldsDictionary.Add(name, value);
        }

        private void UpdateTotalEnabledRegularFieldsDictionary(string name, bool value)
        {
            _totalEnabledRegularFieldsDictionary[name] = value;
        }

        private void AddTotalEnabledSpecialFieldsDictionary(string name, bool value)
        {
            _totalEnabledSpecialFieldsDictionary.Add(name, value);
        }

        private void UpdateTotalEnabledSpecialFieldsDictionary(string name, bool value)
        {
            _totalEnabledSpecialFieldsDictionary[name] = value;
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
                OnesTotal = _diceDictionary["ones"].Select(x => x.Value).Sum();
            }
            if (TwosTotalEnabled == true)
            {
                TwosTotal = _diceDictionary["twos"].Select(x => x.Value).Sum();
            }
            if (ThreesTotalEnabled == true)
            {
                ThreesTotal = _diceDictionary["threes"].Select(x => x.Value).Sum();
            }
            if (FoursTotalEnabled == true)
            {
                FoursTotal = _diceDictionary["fours"].Select(x => x.Value).Sum();
            }
            if (FivesTotalEnabled == true)
            {
                FivesTotal = _diceDictionary["fives"].Select(x => x.Value).Sum();
            }
            if (SixesTotalEnabled == true)
            {
                SixesTotal = _diceDictionary["sixes"].Select(x => x.Value).Sum();
            }
            if (OnePairTotalEnabled == true)
            {
                OnePairTotal = CalculateOnePairTotal();
            }
            if (TwoPairTotalEnabled == true)
            {
                TwoPairTotal = CalculateTwoPairTotal();
            }
            if (ThreeOfAKindTotalEnabled == true)
            {
                ThreeOfAKindTotal = CalculateThreeOfAKindTotal();
            }
            if (FourOfAKindTotalEnabled == true)
            {
                FourOfAKindTotal = CalculateFourOfAKindTotal();
            }
            if (SmallStraightTotalEnabled == true)
            {
                SmallStraightTotal = CalculateSmallStraightTotal();
            }
            if (LargeStraightTotalEnabled == true)
            {
                LargeStraightTotal = CalculateLargeStraightTotal();
            }
            if (FullHouseTotalEnabled == true)
            {
                FullHouseTotal = CalculateFullHouseTotal();
            }
            if (ChanceTotalEnabled == true)
            {
                ChanceTotal = CalculateChanceTotal();
            }
            if (YatzyTotalEnabled == true)
            {
                YatzyTotal = CalculateYatzyTotal();
            }
        }

        private int CalculateOnePairTotal()
        {
            int highestOnePairTotal = 0;
            foreach (var item in _diceDictionary)
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

            return highestOnePairTotal;
        }

        private int CalculateTwoPairTotal()
        {
            int twoPairTotal = 0;
            int amoutOfPairs = 0;

            foreach (var item in _diceDictionary)
            {
                if (item.Value.Count() >= 2)
                {
                    amoutOfPairs++;
                    twoPairTotal += item.Value.Select(x => x.Value).First() * 2;
                }
            }

            return amoutOfPairs >= 2 ? twoPairTotal : 0;
        }

        private int CalculateThreeOfAKindTotal()
        {
            int threeOfAKindTotal = 0;
            foreach (var item in _diceDictionary)
            {
                if (item.Value.Count() >= 3)
                {
                    threeOfAKindTotal = item.Value.Select(x => x.Value).First() * 3;
                    break;
                }
            }

            return threeOfAKindTotal;
        }

        private int CalculateFourOfAKindTotal()
        {
            int fourOfAKindTotal = 0;
            foreach (var item in _diceDictionary)
            {
                if (item.Value.Count() >= 4)
                {
                    fourOfAKindTotal = item.Value.Select(x => x.Value).First() * 4;
                    break;
                }
            }

            return fourOfAKindTotal;
        }

        private int CalculateSmallStraightTotal()
        {
            int smallStraightTotal = 0;
            if (_diceDictionary["ones"].Count() == 1 && _diceDictionary["twos"].Count() == 1
                && _diceDictionary["threes"].Count() == 1 && _diceDictionary["fours"].Count() == 1
                && _diceDictionary["fives"].Count() == 1)
            {
                smallStraightTotal = _diceList.Select(x => x.Value).Sum();
            }

            return smallStraightTotal;
        }

        private int CalculateLargeStraightTotal()
        {
            int largeStraightTotal = 0;
            if (_diceDictionary["twos"].Count() == 1 && _diceDictionary["threes"].Count() == 1
                && _diceDictionary["fours"].Count() == 1 && _diceDictionary["fives"].Count() == 1
                && _diceDictionary["sixes"].Count() == 1)
            {
                largeStraightTotal = _diceList.Select(x => x.Value).Sum();
            }

            return largeStraightTotal;
        }

        private int CalculateFullHouseTotal()
        {
            int fullHouseTotal = 0;
            bool hasThreeOfAKind = false;
            bool hasOnePair = false;

            foreach (var item in _diceDictionary)
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
                fullHouseTotal = _diceList.Select(x => x.Value).Sum();
            }

            return fullHouseTotal;
        }

        private int CalculateChanceTotal()
        {
            return _diceList.Select(x => x.Value).Sum();
        }

        private int CalculateYatzyTotal()
        {
            int yatzyTotal = 0;
            foreach (var item in _diceDictionary)
            {
                if (item.Value.Count() == 5)
                {
                    yatzyTotal = _diceList.Select(x => x.Value).Sum() + 50;
                    MessageBox.Show($"You got Yatzy!", "Congratulations!");
                    break;
                }
            }

            return yatzyTotal;
        }

        private void UpdateDiceList()
        {
            _diceList.Clear();
            _diceList.Add(Dice1);
            _diceList.Add(Dice2);
            _diceList.Add(Dice3);
            _diceList.Add(Dice4);
            _diceList.Add(Dice5);

            var onesList = _diceList.Where(x => x.Value == 1).ToList();
            var twosList = _diceList.Where(x => x.Value == 2).ToList();
            var threesList = _diceList.Where(x => x.Value == 3).ToList();
            var foursList = _diceList.Where(x => x.Value == 4).ToList();
            var fivesList = _diceList.Where(x => x.Value == 5).ToList();
            var sixesList = _diceList.Where(x => x.Value == 6).ToList();

            _diceDictionary.Clear();
            _diceDictionary.Add("ones", onesList);
            _diceDictionary.Add("twos", twosList);
            _diceDictionary.Add("threes", threesList);
            _diceDictionary.Add("fours", foursList);
            _diceDictionary.Add("fives", fivesList);
            _diceDictionary.Add("sixes", sixesList);
        }

        private void RollDices()
        {
            if (!Dice1.Keep)
            {
                Dice1.Value = RollDice();
            }
            if (!Dice2.Keep)
            {
                Dice2.Value = RollDice();
            }
            if (!Dice3.Keep)
            {
                Dice3.Value = RollDice();
            }
            if (!Dice4.Keep)
            {
                Dice4.Value = RollDice();
            }
            if (!Dice5.Keep)
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
            var isAllBonusValuesFalse = _totalEnabledRegularFieldsDictionary.Values.All(x => x.Equals(false));
            var isAllSpecialValuesFalse = _totalEnabledSpecialFieldsDictionary.Values.All(x => x.Equals(false));
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
        #region BonusButtonClicks Region
        private void OnesTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            UpdateTotalEnabledRegularFieldsDictionary(nameof(OnesTotalEnabled), OnesTotalEnabled = false);
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
            UpdateTotalEnabledRegularFieldsDictionary(nameof(TwosTotalEnabled), TwosTotalEnabled);
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
            UpdateTotalEnabledRegularFieldsDictionary(nameof(ThreesTotalEnabled), ThreesTotalEnabled);
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
            UpdateTotalEnabledRegularFieldsDictionary(nameof(FoursTotalEnabled), FoursTotalEnabled);
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
            UpdateTotalEnabledRegularFieldsDictionary(nameof(FivesTotalEnabled), FivesTotalEnabled);
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
            UpdateTotalEnabledRegularFieldsDictionary(nameof(SixesTotalEnabled), SixesTotalEnabled);
            SixesTotal_Button.IsEnabled = false;
            UpdateSmallSum(SixesTotal);
            UpdateTotalSum(SixesTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }
        #endregion
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

            var bonusKeys = _totalEnabledRegularFieldsDictionary.Keys.ToList();
            foreach (var item in bonusKeys)
            {
                _totalEnabledRegularFieldsDictionary[item] = true;
            }

            var speicalKeys = _totalEnabledSpecialFieldsDictionary.Keys.ToList();
            foreach (var item in speicalKeys)
            {
                _totalEnabledSpecialFieldsDictionary[item] = true;
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
        #region SpecialButtonClicks Region
        private void OnePairTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            UpdateTotalSum(OnePairTotal);
            ResetKeepButtons();
            RollDices();
            OnePairTotalEnabled = false;
            UpdateTotalEnabledSpecialFieldsDictionary(nameof(OnePairTotalEnabled), OnePairTotalEnabled);
            OnePairTotal_Button.IsEnabled = false;
            UpdateDiceList();
            CalculateTotals();
            
        }

        private void TwoPairTotal_Button_Click(object sender, RoutedEventArgs e)
        {
            RollCount = 0;
            RollEnabled = true;
            TwoPairTotalEnabled = false;
            UpdateTotalEnabledSpecialFieldsDictionary(nameof(TwoPairTotalEnabled), TwoPairTotalEnabled);
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
            UpdateTotalEnabledSpecialFieldsDictionary(nameof(ThreeOfAKindTotalEnabled), ThreeOfAKindTotalEnabled);
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
            UpdateTotalEnabledSpecialFieldsDictionary(nameof(FourOfAKindTotalEnabled), FourOfAKindTotalEnabled);
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
            UpdateTotalEnabledSpecialFieldsDictionary(nameof(SmallStraightTotalEnabled), SmallStraightTotalEnabled);
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
            UpdateTotalEnabledSpecialFieldsDictionary(nameof(LargeStraightTotalEnabled), LargeStraightTotalEnabled);
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
            UpdateTotalEnabledSpecialFieldsDictionary(nameof(FullHouseTotalEnabled), FullHouseTotalEnabled);
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
            UpdateTotalEnabledSpecialFieldsDictionary(nameof(ChanceTotalEnabled), ChanceTotalEnabled);
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
            UpdateTotalEnabledSpecialFieldsDictionary(nameof(YatzyTotalEnabled), YatzyTotalEnabled);
            YatzyTotal_Button.IsEnabled = false;
            UpdateTotalSum(YatzyTotal);
            CheckForCompletion();
            ResetKeepButtons();
            RollDices();
            UpdateDiceList();
            CalculateTotals();
        }
        #endregion
    }
}
