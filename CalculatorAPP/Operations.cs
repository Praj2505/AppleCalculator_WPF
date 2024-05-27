using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPP
{
    class Operations
    {
       private double num1 { get; set; }
       private double num2 { get; set; }

     public double Addition(double a1, double a2)
        {
            return a1 + a2;
        }
        public double Subtraction(double a1, double a2)
        {
            return a1 - a2;
        }
        public double Multiply(double a1, double a2)
        {
            return a1 * a2;
        }
        public double Divide(double a1, double a2)
        {
            return a1 / a2;
        }

    }
}
