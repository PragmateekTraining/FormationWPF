using System;
using System.Text.RegularExpressions;
using System.Windows.Markup;
using System.Xaml;

namespace Xaml
{
    public class CalculatorExtension : MarkupExtension
    {
        private readonly Double result = 0.0;

        public CalculatorExtension(String operation)
        {
            Regex regex = new Regex(@"(\d+)(\+|\-|\*|\/)(\d+)");

            MatchCollection matches = regex.Matches(operation);

            double leftOperand = Double.Parse(matches[0].Groups[1].Value);
            string @operator = matches[0].Groups[2].Value;
            double rightOperand = Double.Parse(matches[0].Groups[3].Value);

            switch (@operator)
            {
                case "+":
                    result = leftOperand + rightOperand;
                    break;
                case "-":
                    result = leftOperand - rightOperand;
                    break;
                case "*":
                    result = leftOperand * rightOperand;
                    break;
                case "/":
                    result = leftOperand / rightOperand;
                    break;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return result;
        }
    }

    public class Result
    {
        public double Value { get; set; }
    }

    internal class XamlCalculator
    {
        public void Run()
        {
            Result[] results = XamlServices.Load("Computations.xaml") as Result[];

            Console.WriteLine("Computation results:");

            foreach (Result result in results)
            {
                Console.WriteLine(result.Value);
            }
        }
    }
}
