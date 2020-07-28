using System;
using System.Collections.Generic;
using System.Text;
using Task1_Matrix.Exceptions;

namespace Task1_Matrix
{
    public partial class Matrix
    {
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.GetRows() != m2.GetRows() || m1.GetColumns() != m2.GetColumns())
            {
                throw new NotEqualityDimensionMatricesException("At least one dimension of the matrices is not the same");
            }

            Matrix result = new Matrix(m1.GetRows(), m1.GetColumns());

            for (int i = 0; i < m1.GetRows(); i++)
            {
                for (int j = 0; j < m1.GetColumns(); j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.GetRows() != m2.GetRows() || m1.GetColumns() != m2.GetColumns())
            {
                throw new NotEqualityDimensionMatricesException("At least one dimension of the matrices is not the same");
            }

            Matrix result = new Matrix(m1.GetRows(), m1.GetColumns());

            for (int i = 0; i < m1.GetRows(); i++)
            {
                for (int j = 0; j < m1.GetColumns(); j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }

            return result;
        }
        public static Matrix operator *(Matrix m1, int scalar)
        {
            Matrix result = new Matrix(m1.GetRows(), m1.GetColumns());

            for (int i = 0; i < m1.GetRows(); i++)
            {
                for (int j = 0; j < m1.GetColumns(); j++)
                {
                    result[i, j] = m1[i, j] * scalar;
                }
            }

            return result;
        }
        public static Matrix operator *(int scalar, Matrix m1)
        {
            return m1 * scalar;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.GetColumns() != m2.GetRows())
            {
                logger.Info("internal dimensions of the matrices are not the same");
                throw new NotEqualityDimensionMatricesException("internal dimensions of the matrices are not the same");
            }

            Matrix result = new Matrix(m1.GetRows(), m2.GetColumns());

            for (var i = 0; i < m1.GetRows(); i++)
            {
                for (var j = 0; j < m2.GetColumns(); j++)
                {
                    result[i, j] = 0;

                    for (var k = 0; k < m1.GetColumns(); k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            
            return result;
        }
    }
}
