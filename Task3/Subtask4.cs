namespace Vector
{
    class SquereMatrix
    {
        private int[,] matrix;
        private StartTurn startTurn;

        public SquereMatrix()
        {
        }

        public SquereMatrix(int size, StartTurn startTurn)
        {
            matrix = new int[size, size];
            this.startTurn = startTurn;
        }

        private bool CheckStep(int step)
        {
            step %= 2;
            switch (startTurn)
            {
                case StartTurn.right:
                    if (step != 0) return true;
                    else if (step == 0) return false;
                    break;
                case StartTurn.down:
                    if (step != 0) return false;
                    else if (step == 0) return true;
                    break;
            }

            return false;
        }

        public void FillMatrix()
        {
            int firstHalfNumber = 1, secondHalfNumber = matrix.Length;
            int lineLenght = matrix.GetLength(0) - 1;
            int i = 0, j = 0;

            switch (startTurn)
            {
                case StartTurn.right:
                    i = -1;
                    j = 0;
                    break;
                case StartTurn.down:
                    i = 0;
                    j = -1;
                    break;
            }

            for(int k = 0; k <= lineLenght; k++)
            {
                if (CheckStep(k))
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
                for(int j = 0; j < matrix.GetLength(0); j++)
                {
                    result += matrix[i, j] + "\t";
                }

                result += "\n";
            }

            return result;
        }
    }
}
