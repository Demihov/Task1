using System;
using Task1_Matrix.Exceptions;
using Task1_Matrix.Models;
using Newtonsoft.Json;
using NLog;

namespace Task1_Matrix
{
    [Serializable]
    public partial class Matrix : IMatrix, ICloneable
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        [JsonProperty]
        private int[,] _matrix;

        public int GetRows() { return _matrix.GetLength(0); }
        public int GetColumns() { return _matrix.GetLength(1); }

        public Matrix() { }
        public Matrix(int m, int n)
        {
            if (m <= 0 || n <= 0)
            {
                logger.Info("Invalid matrix dimension exception");
                throw new InvalidMatrixDimensionException();
            }

            this._matrix = new int[m, n];
        }
        public Matrix(int[,] matrix)
        {
            if (matrix.GetLength(0) <= 0 || matrix.GetLength(1) <= 0)
            {
                logger.Info("Invalid matrix dimension exception");
                throw new InvalidMatrixDimensionException();
            }

            this._matrix = matrix;
        }

        public override bool Equals(object obj)
        {
            Matrix compared = obj as Matrix;

            if (compared == null)
            {
                return false;
            }

            if (_matrix.GetLength(0) != compared.GetRows() || _matrix.GetLength(1) != compared.GetColumns())
            {
                logger.Info("The dimension of the matrices is not the same");
                throw new NotEqualityDimensionMatricesException("The dimension of the matrices is not the same");
            }

            for (int i = 0; i < compared.GetRows(); i++)
            {
                for (int j = 0; j < compared.GetColumns(); j++)
                {
                    if (_matrix[i, j] != compared[i, j]) return false;
                }
            }

            return true;
        }
        public object Clone()
        {
            int[,] result = new int[_matrix.GetLength(0), _matrix.GetLength(1)];

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    result[i, j] = _matrix[i, j];
                }
            }

            logger.Info("Matrix was clone");
            return result;
        }

        public void Show()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.Write(_matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int this[int m, int n]
        {
            get
            {
                return this._matrix[m, n];
            }
            set
            {
                this._matrix[m, n] = value;
            }
        }
    }
}
