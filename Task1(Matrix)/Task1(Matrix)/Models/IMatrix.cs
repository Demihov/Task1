using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_Matrix.Models
{
    interface IMatrix
    {
        public int GetRows();
        public int GetColumns();
        public void Show();

        public int this[int m, int n] { get; set; }
    }
}
