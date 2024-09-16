namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public string historyText;
        public bool isOperation = false;
        public bool isRavno = false;
        public bool IsEmpty=true;
        public MainPage()
        {
            InitializeComponent();
        }

        public void History(char operation)
        {
            if(isOperation)
            {
                historyText = historyText.Remove(historyText.Length - 1, 1);
                historyText += operation;
                history.Text = historyText;
            }
            else
                history.Text = historyText;
        }

        private void ClickOperation(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var operation1 = button.Text.ToString()[0];
            //промежуточный результат выводить, при нажатии на любую цифру убирать
            if (!isOperation)
            {
                if (count < 1)
                    double.TryParse(input.Text, out x);
                historyText += input.Text;
                historyText += operation1;
                count++;
                if(count >1)
                {
                    ClickResult(null, new EventArgs());
                }
                History(operation1);
                isOperation = true;
               IsEmpty = true;
            }
            else
                History(operation1);
            operation = operation1;
        }
        double result = 0;
        private void ClickResult(object sender, EventArgs e)
        {
            result = 0;
            double.TryParse(input.Text, out double y);
            switch (operation)
            {
                case '+': result = x + y; break;
                case '-': result = x - y; break;
                case '*': result = x * y; break;
                case '/': result = x / y; break;
            }
        IsEmpty = false;
            if (sender != null)
            {
                history.Text = "";
                historyText = "";
                count = 0;
           IsEmpty = true;
            }
            x = result;
            input.Text = result.ToString();
            
        }

        private void ClickBackspace(object sender, EventArgs e)
        {
            if (input.Text != null && input.Text.Length > 0)
            {
                input.Text = input.Text.Remove(input.Text.Length - 1);
            }
        }

        private void ClickC(object sender, EventArgs e)
        {
            operation = ' ';
            x = 0;
            input.Text = null;
            history.Text = null;
            historyText = null;
        }
        private void ClickCE(object sender, EventArgs e)
        {
            operation = ' ';
            x = 0;
            input.Text = null;
            historyText = null;
        }
        private void ClickPlusMinus(object sender, EventArgs e)
        {
            if (input.Text.StartsWith("-"))
                input.Text = input.Text.Remove(0, 1);
            else
                input.Text = "-" + input.Text;
        }

        private void ClckSquareRoot(object sender, EventArgs e)
        {
            double.TryParse(input.Text, out double y);
            input.Text = (Math.Sqrt(y)).ToString();
        }

        private void ClickNumber(object sender, EventArgs e)
        {
            isOperation = false;
            if (IsEmpty)
            {
                input.Text = "";
                IsEmpty = false;
            }
                Button button = (Button)sender;
                input.Text += button.Text.ToString();
        }

        double x = 0;
        char operation = ' ';
       

        private void ClickPersent(object sender, EventArgs e)
        {
            double percent1 = x / 100;
            double.TryParse(input.Text, out double y);
            input.Text = (y * percent1).ToString();
        }

        private void ClickDivideX(object sender, EventArgs e)
        {
            double.TryParse(input.Text, out double y);
            input.Text = (1 / y).ToString();
        }

        private void ClickDot(object sender, EventArgs e)
        {
            if (!isOperation)
            {
                if (!input.Text.Contains(","))
                    input.Text += ",";
            }
        }

       

        private void ClickSquare(object sender, EventArgs e)
        {
            double.TryParse(input.Text, out double y);
            input.Text = (Math.Pow(y, 2)).ToString();
        }

        private void ClickSin(object sender, EventArgs e)
        {
            double.TryParse(input.Text, out double y);
            input.Text = (Math.Sin(y)).ToString();
        }

        private void ClickLog(object sender, EventArgs e)
        {
            double.TryParse(input.Text, out double y);
            input.Text = (Math.Log(y)).ToString();
        }

        private void ClickSquareX(object sender, EventArgs e)
        {
            double.TryParse(input.Text, out double y);
            input.Text = (Math.Pow(10, y)).ToString();
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }

}
