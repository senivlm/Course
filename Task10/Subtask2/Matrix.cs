using System;
using System.Collections;
using System.Collections.Generic;

namespace Course.Task10
{
    enum FillTypes
    {
        Vertically,
        Diagonaly,
        Exeption
    }

    class Matrix : IEnumerable<int>
    {
        private int[,] matrix;
        private FillTypes fillType;

        #region Constructors
        public Matrix()
        {
            matrix = null;
            fillType = FillTypes.Exeption;
        }

        public Matrix(int[,] matrix)
        {
            Array.Copy(matrix, this.matrix, matrix.Length);
            fillType = FillTypes.Exeption;
        }

        public Matrix(int lenght, int hight, FillTypes fillType)
        {
            matrix = new int[hight, lenght];
            this.fillType = fillType;
        }
        #endregion

        public void FillMatrix()
        {
            switch (fillType)
            {
                case FillTypes.Vertically:
                    VerticalFill();
                    break;
                case FillTypes.Diagonaly:
                    DiagonalyFill();
                    break;
                case FillTypes.Exeption:
                    throw new ArgumentException();
            }
        }

        #region Filling
        private void VerticalFill()
        {
            int currentNumber = 1;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (i % 2 == 0)
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        matrix[j, i] = currentNumber;
                        currentNumber++;
                    }
                else
                    for (int j = matrix.GetLength(0) - 1; j >= 0; j--)
                    {
                        matrix[j, i] = currentNumber;
                        currentNumber++;
                    }
            }
        }

        private void DiagonalyFill()
        {
            int firstHalfNumber = 1, secondHalfNumber = matrix.Length;
            int lineLenght = matrix.GetLength(0) - 1;
            int i = -1, j = 0;

            for (int k = 0; k <= lineLenght; k++)
            {
                if (k % 2 != 0)
                {
                    j++;
                    matrix[i, j] = firstHalfNumber;
                    matrix[lineLenght, lineLenght - j] = secondHalfNumber;
                    secondHalfNumber--;
                    firstHalfNumber++;
                    for (int h = 0; h < k; h++)
                    {
                        i++;
                        j--;
                        matrix[i, j] = firstHalfNumber;
                        matrix[lineLenght - i, lineLenght - j] = secondHalfNumber;
                        secondHalfNumber--;
                        firstHalfNumber++;
                    }
                }
                else
                {
                    i++;
                    matrix[i, j] = firstHalfNumber;
                    matrix[lineLenght - i, lineLenght] = secondHalfNumber;
                    secondHalfNumber--;
                    firstHalfNumber++;
                    for (int h = 0; h < k; h++)
                    {
                        i--;
                        j++;
                        matrix[i, j] = firstHalfNumber;
                        matrix[lineLenght - i, lineLenght - j] = secondHalfNumber;
                        secondHalfNumber--;
                        firstHalfNumber++;
                    }
                }
            }
        }
        #endregion

        #region IEnumerators
        // Vertical snake
        //public IEnumerator<int> GetEnumerator()
        //{
        //    for (int i = 0; i < matrix.GetLength(1); i++)
        //    {
        //        if (i % 2 == 0)
        //            for (int j = 0; j < matrix.GetLength(0); j++)
        //            {
        //                yield return matrix[j, i];
        //            }
        //        else
        //            for (int j = matrix.GetLength(0) - 1; j >= 0; j--)
        //            {
        //                yield return matrix[j, i];
        //            }
        //    }
        //}

        // Diagonaly
        public IEnumerator<int> GetEnumerator()
        {
            int lineLenght = matrix.GetLength(0) * 2 - 1;
            int i = -1, j = 0;

            for (int k = 0; k < lineLenght; k++)
            {
                if (k % 2 != 0)
                {
                    int steps = k;
                    if (k > 3)
                    {
                        i++;
                        steps = lineLenght - k - 1;
                    }
                    else
                        j++;

                    yield return matrix[i, j];
                    for (int h = 0; h < steps; h++)
                    {
                        i++;
                        j--;
                        yield return matrix[i, j];
                    }
                }
                else
                {
                    int steps = k;
                    if (k > 3)
                    {
                        j++;
                        steps = lineLenght - k - 1;
                    }
                    else i++;

                    yield return matrix[i, j];
                    for (int h = 0; h < steps; h++)
                    {
                        i--;
                        j++;
                        yield return matrix[i, j];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return matrix.GetEnumerator();
        }
        #endregion

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i, j] + "\t";
                }
                result += "\n";
            }
            return result;
        }
    }
}