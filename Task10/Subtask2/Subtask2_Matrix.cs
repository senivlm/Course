using System;
namespace Course.Task10
{
    enum FillTypes
    {
        vertically,
        spirally,
        diagonaly,
        exeption
    }

    class Matrix
    {
        private int[,] matrix;
        private FillTypes fillType;

        public Matrix()
        {
            matrix = null;
            fillType = FillTypes.exeption;
        }

        public Matrix(int lenght, int hight, FillTypes fillType)
        {
            matrix = new int[hight, lenght];
            this.fillType = fillType;
        }

        public void FillMatrix()
        {
            switch (fillType)
            {
                case FillTypes.vertically:
                    VerticalFill();
                    break;
                case FillTypes.spirally:
                    SpirallFill();
                    break;
                case FillTypes.diagonaly:
                    DiagonalyFill();
                    break;
                case FillTypes.exeption:
                    throw new ArgumentException();
            }
        }

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

        private void SpirallFill()
        {
            int currentNumber = 1;
            int currentHight = matrix.GetLength(0), currentLenght = matrix.GetLength(1);
            int i = -1, j = 0;
            int step = 0;
            while (currentNumber <= matrix.Length)
            {
                if (step % 2 != 0)
                {
                    if (j == currentLenght)
                    {
                        for (int k = 0; k < currentLenght - 1; k++)
                        {
                            matrix[i, --j] = currentNumber++;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < currentLenght - 1; k++)
                        {
                            matrix[i, ++j] = currentNumber++;
                        }
                    }
                    currentLenght--;
                }
                else
                {
                    if (i == currentHight)
                    {
                        for (int k = 0; k < currentHight; k++)
                        {
                            matrix[--i, j] = currentNumber++;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < currentHight; k++)
                        {
                            matrix[++i, j] = currentNumber++;
                        }
                    }
                    currentHight--;
                }
                step++;
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
