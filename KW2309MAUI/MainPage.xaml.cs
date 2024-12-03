namespace KW2309MAUI
{
    public partial class MainPage : ContentPage
    {
        int gameResult = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void DiceRoll(object sender, EventArgs e)
        {
            int[] dice = new int[5];
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                dice[i] = r.Next(1, 7);
            }

            dice_0.Source = "k6_" + dice[0] + ".png";
            dice_1.Source = "k6_" + dice[1] + ".png";
            dice_2.Source = "k6_" + dice[2] + ".png";
            dice_3.Source = "k6_" + dice[3] + ".png";
            dice_4.Source = "k6_" + dice[4] + ".png";

            int rollResult = 0;
            for (int dots = 1; dots <= 6; dots++)
            {
                int count = 0;
                for (int diceIndex = 0; diceIndex < 5; diceIndex++)
                {
                    if (dice[diceIndex] == dots)
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    rollResult += dots * count;
                }
            }

            RollResultLabel.Text = "Wynik tego losowania: " + rollResult;
            gameResult += rollResult;
            GameResultLabel.Text = "Wynik gry: " + gameResult;
        }

        private void ResetGame(object sender, EventArgs e)
        {
            dice_0.Source = "k6_0.png";
            dice_1.Source = "k6_0.png";
            dice_2.Source = "k6_0.png";
            dice_3.Source = "k6_0.png";
            dice_4.Source = "k6_0.png";

            gameResult = 0;
            GameResultLabel.Text = "Wynik gry: " + gameResult;
            RollResultLabel.Text = "Wynik tego losowania: 0";
        }
    }
}