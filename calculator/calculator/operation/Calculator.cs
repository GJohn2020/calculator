using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.operation
{
    public class Calculator : ICalculator
    {
        private float firstNumber;
        private float secondNumber;
        private Result operation;

        public void SetFirstNumber(float number)
        {
            firstNumber = number;
        }

        public void SetSecondNumber(float number)
        {
            secondNumber = number;
        }

        public void SetOperation(Result op)
        {
            operation = op;
        }

        public float Calculate()
        {
            if (operation == null)
            {
                throw new InvalidOperationException("No operation selected");
            }

            return operation.Equal(firstNumber, secondNumber);
        }

        public void Clear()
        {
            firstNumber = 0;
            secondNumber = 0;
            operation = null;
        }
    }
}
