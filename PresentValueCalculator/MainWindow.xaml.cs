using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Text.RegularExpressions;


namespace PresentValueCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TextInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]");

            if (regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        
        private void FV_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            FV_TextInput.Text = (Math.Round(FV_Slider.Value)).ToString();
        }

        private void IR_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IR_TextInput.Text = (Math.Round(IR_Slider.Value, 2)).ToString();
        }

        private void NL_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            NL_TextInput.Text = (Math.Round(NL_Slider.Value)).ToString();
        }

        private void FV_TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            FV_Slider.Value = (double.Parse(FV_TextInput.Text));
        }

        private void IR_TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            IR_Slider.Value = (double.Parse(IR_TextInput.Text));
        }

        private void NL_TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            NL_Slider.Value = (double.Parse(NL_TextInput.Text));
        }

        private void BtnOut_Click(object sender, RoutedEventArgs e)
        {
            Button btnClicked = (Button)sender;
            double futureValue = double.Parse(FV_TextInput.Text);
            double interestRate = double.Parse(IR_TextInput.Text)/100;
            double numberLine = double.Parse(NL_TextInput.Text);

            if (Annually.IsChecked == true)
            {
                if(futureValue == 0 && interestRate == 0 && numberLine == 0)
                {
                    LblOut.Content = "Please enter all values to calculate";
                }
                else
                {
                    double calculation = futureValue / Math.Pow((1 + interestRate), numberLine);
                    LblOut.Content = $"${Math.Round(calculation, 2)}";
                }
            }
            else if (Quarterly.IsChecked == true)
            {
                if (futureValue == 0 && interestRate == 0 && numberLine == 0)
                {
                    LblOut.Content = "Please enter all values to calculate";
                }
                else
                {
                    double calculation = futureValue / Math.Pow((1 + interestRate/2), numberLine*2);
                    LblOut.Content = $"${Math.Round(calculation, 2)}";
                }
            }
            else if (Monthly.IsChecked == true)
            {
                if (futureValue == 0 && interestRate == 0 && numberLine == 0)
                {
                    LblOut.Content = "Please enter all values to calculate";
                }
                else
                {
                    double calculation = futureValue / Math.Pow((1 + interestRate / 12), numberLine * 12);
                    LblOut.Content = $"${Math.Round(calculation, 2)}";
                }
            }
            else if (Daily.IsChecked == true)
            {
                if (futureValue == 0 && interestRate == 0 && numberLine == 0)
                {
                    LblOut.Content = "Please enter all values to calculate";
                }
                else
                {
                    double calculation = futureValue / Math.Pow((1 + interestRate / 365), numberLine * 365);
                    LblOut.Content = $"${Math.Round(calculation, 2)}";
                }
            }
        }
        
        /*
        private void BtnOut_Click(object sender, RoutedEventArgs e)
        {
            Button btnClicked = (Button)sender;
            double futureValue = double.Parse(FV_TextInput.Text);
            double interestRate = double.Parse(IR_TextInput.Text);
            double numberLine = double.Parse(NL_TextInput.Text);

            if (futureValue == 0 && interestRate == 0 && numberLine == 0)
            {
                LblOut.Content = "Please enter all values to calculate";
            }
            else
            {
                double calculation = futureValue / Math.Pow((1 + interestRate), numberLine);
                LblOut.Content = $"{Math.Round(calculation,2)}";
            }
        }
        
        private void Annual_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Semi_Annual_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Monthly_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Daily_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Quarterly_Checked(object sender, RoutedEventArgs e)
        {

        }
        */
    }
}
