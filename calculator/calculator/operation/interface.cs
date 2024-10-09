using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.operation
{
    public interface ICalculator
    {
        void SetOperation(Result result);
        void SetFirstNumber(float number);
        void SetSecondNumber(float number);
        float Calculate();
    }
    public interface Result
    {
        float Equal(float num1, float num2);
    }
}
