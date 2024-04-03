using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace CSharpWpfApp2_31_03
{
    public partial class MainWindow : Window
    {
        private string currentNumber = "";
        private string previousOperations = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            currentNumber += button.Content.ToString();
            currentNumberTextBox.Text = currentNumber;
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!currentNumber.Contains("."))
            {
                currentNumber += ".";
                currentNumberTextBox.Text = currentNumber;
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            previousOperations += $"{currentNumber} {button.Content} ";
            currentNumber = "";
            previousOperationsTextBox.Text = previousOperations;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = new DataTable().Compute(previousOperations + currentNumber, null);
                currentNumberTextBox.Text = result.ToString();
                previousOperations = "";
                previousOperationsTextBox.Text = "";
                currentNumber = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CEButton_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = "";
            currentNumberTextBox.Text = "";
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = "";
            currentNumberTextBox.Text = "";
            previousOperations = "";
            previousOperationsTextBox.Text = "";
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber.Length > 0)
            {
                currentNumber = currentNumber.Substring(0, currentNumber.Length - 1);
                currentNumberTextBox.Text = currentNumber;
            }
        }

        private void SqrtButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                var result = Math.Sqrt(double.Parse(currentNumber));
                currentNumberTextBox.Text = result.ToString();
                currentNumber = result.ToString();
            }
        }

        private void SquareButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                var result = Math.Pow(double.Parse(currentNumber), 2);
                currentNumberTextBox.Text = result.ToString();
                currentNumber = result.ToString();
            }
        }

        private void ReciprocalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                var result = 1 / double.Parse(currentNumber);
                currentNumberTextBox.Text = result.ToString();
                currentNumber = result.ToString();
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                var result = double.Parse(currentNumber) / 100;
                currentNumberTextBox.Text = result.ToString();
                currentNumber = result.ToString();
            }
        }
    }
}