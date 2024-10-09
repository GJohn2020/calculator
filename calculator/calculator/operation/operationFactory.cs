using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.operation
{
    public static class operationFactory
    {
        public static Result GetOperation(string operation)
        {
            switch (operation)
            {
                case "+":
                    return new Add();
                case "-":
                    return new Substract();
                // You can add more operations here, e.g., "*", "/"
                default:
                    throw new ArgumentException("Invalid operation");
            }
        }
    }
}
