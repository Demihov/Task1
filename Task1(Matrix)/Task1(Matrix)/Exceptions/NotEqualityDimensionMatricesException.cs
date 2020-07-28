using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_Matrix.Exceptions
{
    public class NotEqualityDimensionMatricesException : Exception
    {
        public NotEqualityDimensionMatricesException(string str) : base(str) { }
        
    }
}
