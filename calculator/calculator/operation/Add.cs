using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.operation
{
    public class Add : Result
    {
        //public int num1 { get; set; }
        //public int num2 { get; set; }
        public float Equal(float num1,float num2)
        {
            return (num1 + num2);
        }
    }
}
