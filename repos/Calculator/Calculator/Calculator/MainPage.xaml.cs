using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
	public partial class MainPage : ContentPage
	{
        string Operation;
        int currentState = 1;
        double firstNumber, secondNumber;

        public object DisplayText { get; private set; }

        public MainPage()
		{
			InitializeComponent();
          
		}
        
        void OperationSelect(object sender, EventArgs e)
        {
            currentState = -2;
            Button buttonPressed = (Button)sender;
            string selected = buttonPressed.Text;
            Operation = selected;
        }

        void NumberSelect(object sender, EventArgs e)
        {
            Button buttonPressed = (Button)sender;
            string selected = buttonPressed.Text;

            if(this.displayResult.Text == "0" || currentState < 0)
            {
                this.displayResult.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.displayResult.Text += selected;

            double numSelected;
            if (double.TryParse(this.displayResult.Text, out numSelected))
            {
                this.displayResult.Text = numSelected.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = numSelected;
                }
                else
                {
                    secondNumber = numSelected;
                }
            }

        }

        void Calculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                double result = 0;
                switch (Operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        result = firstNumber / secondNumber;
                        break;
                }
                firstNumber = result;
                this.displayResult.Text = result.ToString("N0");
                currentState = -1;
            }
        }

        void ClearDisplay(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.displayResult.Text = "0";
        }


    }
}
