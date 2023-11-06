using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Task1
{
    public class Matrix
    {
        public int[,] _matrix;
        public int count;
        public Matrix(int n, int m)
        {
            _matrix = new int[n, m];
        }

        private int getRandom(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public void setRandomMatrix()
        {
            int rows = _matrix.GetLength(0);
            int cols = _matrix.GetLength(1);

            Random r = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    _matrix[i, j] = r.Next(-100,100);//getRandom(-100, 100);
                }
            }
        }
        public Matrix MultiMatrix(Matrix b)
        {
            int n = _matrix.GetLength(0);
            int m = b._matrix.GetLength(1);
            Matrix matrixC = new Matrix(n,m);
            count = 0;
            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                for (var j = 0; j < b._matrix.GetLength(1); j++)
                {
                    matrixC._matrix[i, j] = 0;

                    for (var k = 0; k < _matrix.GetLength(1); k++)
                    {
                        count++;
                        matrixC._matrix[i, j] += _matrix[i, k] * b._matrix[k, j];
                    }
                }
            }
            return matrixC;
        }
        public void printMatrix()
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
    }
}