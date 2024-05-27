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

namespace CalculatorAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum operators {Addition, Subtraction, Division, Multiplication };
 
        Stack<double> num_sp = new Stack<double>();
        Stack<operators> op_sp = new Stack<operators>();
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void OpnBtn_Click(object sender, RoutedEventArgs e)
        {
            
            double f;
           if (num_sp.Count==0&&op_sp.Count==0)
            {
                if (Double.TryParse(resultSection.Content.ToString(), out f))
                {
                    num_sp.Push(f);
                    switch((sender as Button).Content.ToString())
                    {
                        case "+": op_sp.Push(operators.Addition);
                            break;
                        case "-": op_sp.Push(operators.Subtraction);
                            break;
                        case "X":
                            op_sp.Push(operators.Multiplication);
                            break;
                        case "/":
                            op_sp.Push(operators.Division);
                            break;
                    }
                }
            }
           else
            {
                if (Double.TryParse(resultSection.Content.ToString(), out f))
                {
                    Calc(f);
                }
                if (Double.TryParse(resultSection.Content.ToString(), out f))
                {
                    
                    switch ((sender as Button).Content.ToString())
                    {
                        case "+":
                            op_sp.Push(operators.Addition);
                            break;
                        case "-":
                            op_sp.Push(operators.Subtraction);
                            break;
                        case "X":
                            op_sp.Push(operators.Multiplication);
                            break;
                        case "/":
                            op_sp.Push(operators.Division);
                            break;
                    }
                }
            }
            resultSection.Content = "";
                
        }
        
        private void Calc(double num)
        {
            Operations op = new Operations();
            switch (op_sp.Peek())
            {
                case operators.Addition:
                    {
                        num_sp.Push(op.Addition(num_sp.Peek(), num));
                        break;
                    }
                case operators.Subtraction:
                    {
                        num_sp.Push(op.Subtraction(num_sp.Peek(), num));
                        break;
                    }
                case operators.Multiplication:
                    {
                        num_sp.Push(op.Multiply(num_sp.Peek(), num));
                    }
                    break;
                case operators.Division:
                    {
                        if (num != 0)
                        {
                            num_sp.Push(op.Divide(num_sp.Peek(), num));
                        }
                        else
                        {
                            MessageBox.Show("Division Error", "Divide by Zero", MessageBoxButton.OK, MessageBoxImage.Error);
                            resultSection.Content = "0";
                            num_sp.Clear();
                            op_sp.Clear();
                        }

                        break;
                    }
            }
        }
           
            
           
        private void AllClear_Click(object sender, RoutedEventArgs e)
        {
            resultSection.Content = "0";
            num_sp.Clear();
            op_sp.Clear();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double f;
           
                if (Double.TryParse(resultSection.Content.ToString(), out f))
                {
                    Calc(f);
                }
            
            if(num_sp.Count!=0)
            {
                resultSection.Content = num_sp.Peek().ToString();
            }
            else
            {
                if (Double.TryParse(resultSection.Content.ToString(), out f))
                {
                    Calc(f);
                }
            }
        }
        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            double f;


            if (Double.TryParse((sender as Button).Content.ToString(), out f))
            {
                if (resultSection.Content.ToString() != "0")
                {
                    resultSection.Content += f.ToString();
                }
                else
                {
                    resultSection.Content = f;
                }
            }
            else
            {
                if ((sender as Button).Content.ToString() == ".")
                {
                    resultSection.Content += ".";
                }
            }
        }
    }
}
