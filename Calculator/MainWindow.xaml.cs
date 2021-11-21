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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double firstNumber;
        private double lastNumber;
        private double result;
        SelectedOperatation selectedOperator;
        private enum SelectedOperatation
        {
            None,
            Division,
            Multiplication,
            Subtraction,
            Sum
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Number(object sender, RoutedEventArgs e)
        {
            Button number = (Button)sender;
            Display.Text += number.Content.ToString();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Display.Text = string.Empty;
        }

        private void Operator(object sender, RoutedEventArgs e)
        {
            if (Display.Text == string.Empty)
            {
                MessageBox.Show("Operator cannot be put without number");
            }
            else if (Display.Text.Contains("+") || Display.Text.Contains("-") || Display.Text.Contains("x") || Display.Text.Contains("÷"))
            {
                MessageBox.Show("Cannot have more than one operation...");
            }
            else
            {
                Button ope = (Button)sender;
                switch (ope.Content.ToString())
                {
                    case "+":
                        firstNumber = Convert.ToDouble(Display.Text);
                        selectedOperator = SelectedOperatation.Sum;
                        Display.Text = string.Empty;
                        break;
                    case "-":
                        firstNumber = Convert.ToDouble(Display.Text);
                        selectedOperator = SelectedOperatation.Subtraction;
                        Display.Text = string.Empty;
                        break;
                    case "x":
                        firstNumber = Convert.ToDouble(Display.Text);
                        selectedOperator = SelectedOperatation.Multiplication;
                        Display.Text = string.Empty;
                        break;
                    case "÷":
                        firstNumber = Convert.ToDouble(Display.Text);
                        selectedOperator = SelectedOperatation.Division;
                        Display.Text = string.Empty;
                        break;
                    case "=":
                        switch (selectedOperator)
                        {
                            case SelectedOperatation.Division:
                                if (Display.Text.ToString() == "0")
                                {
                                    MessageBox.Show("Cannot divide a number 0");
                                }
                                else
                                {
                                    lastNumber = Convert.ToDouble(Display.Text);
                                    result = firstNumber / lastNumber;
                                    Display.Text = result.ToString();
                                }
                                break;

                            case SelectedOperatation.Multiplication:
                                lastNumber = Convert.ToDouble(Display.Text);
                                result = firstNumber * lastNumber;
                                Display.Text = result.ToString();
                                break;

                            case SelectedOperatation.Subtraction:
                                lastNumber = Convert.ToDouble(Display.Text);
                                result = firstNumber - lastNumber;
                                Display.Text = result.ToString();
                                break;

                            case SelectedOperatation.Sum:
                                lastNumber = Convert.ToDouble(Display.Text);
                                result = firstNumber + lastNumber;
                                Display.Text = result.ToString();
                                break;

                        }

                        break;
                }
            }
        }

            private void PlusMinus(object sender, RoutedEventArgs e)
            {
                if (!(Display.Text.ToString() == "0" || Display.Text == string.Empty))
                {
                    double value = Convert.ToDouble(Display.Text);
                    value *= -1;
                    Display.Text = value.ToString();
                }
            }

            private void Point(object sender, RoutedEventArgs e)
            {
                if (Display.Text.Contains("."))
                {
                    MessageBox.Show("Cannot contain more than one point");
                }
                else
                {
                    Display.Text += ".";
                }
            }

            private void Percentage(object sender, RoutedEventArgs e)
            {
                double value = Convert.ToDouble(Display.Text);
                value /= 100;
                Display.Text = value.ToString();
            }
        }
    }

