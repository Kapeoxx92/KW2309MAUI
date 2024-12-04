namespace KW2309MAUI
{
    public partial class MainPage : ContentPage
    {
        private const int NumberOfDice = 5;
        private const int MaxDiceValue = 6;
        private Random random;
        private int gameResult = 0;

        public MainPage()
        {
            InitializeComponent();
            random = new Random();
        }

        private void DiceRoll(object sender, EventArgs e)
        {
            int[] dice = new int[NumberOfDice];
            for (int i = 0; i < NumberOfDice; i++)
            {
                dice[i] = random.Next(1, MaxDiceValue + 1);
            }

           
            dice_0.Source = $"k6_{dice[0]}.png";
            dice_1.Source = $"k6_{dice[1]}.png";
            dice_2.Source = $"k6_{dice[2]}.png";
            dice_3.Source = $"k6_{dice[3]}.png";
            dice_4.Source = $"k6_{dice[4]}.png";

            int rollResult = CalculateRollResult(dice);

            RollResultLabel.Text = $"Wynik tego losowania: {rollResult}";
            gameResult += rollResult;
            GameResultLabel.Text = $"Wynik gry: {gameResult}";
        }

        private int CalculateRollResult(int[] dice)
        {
            int rollResult = 0;

            int[] counts = new int[MaxDiceValue + 1];

            foreach (var die in dice)
            {
                counts[die]++;
            }

            for (int value = 1; value <= MaxDiceValue; value++)
            {
                if (counts[value] >= 3)
                {
                    rollResult += value * 3;
                }
                else if (counts[value] == 2)
                {
                    rollResult += value * 2;
                }
                else if (counts[value] == 1)
                {
                    rollResult += value;
                }
            }

            return rollResult;
        }

        private void ResetGame(object sender, EventArgs e)
        {
            dice_0.Source = "k6_0.png";
            dice_1.Source = "k6_0.png";
            dice_2.Source = "k6_0.png";
            dice_3.Source = "k6_0.png";
            dice_4.Source = "k6_0.png";

            gameResult = 0;
            GameResultLabel.Text = $"Wynik gry: {gameResult}";
            RollResultLabel.Text = "Wynik tego losowania: 0";
        }
    }
}
