using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_Matrix.Exceptions
{
    public class InvalidMatrixDimensionException: Exception
    {
        public InvalidMatrixDimensionException() : base("The dimensions of matrix are invalid") { }
    }
}
