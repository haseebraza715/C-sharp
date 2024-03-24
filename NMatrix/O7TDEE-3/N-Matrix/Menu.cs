using NMatrix;
using System;

namespace NMatrix
{
    public class Menu
    {
        private Matrix m1, m2;

        public void Run()
        {
            try
            {
                Console.WriteLine("=======NMATRIX APPLICATION:=======");
                Console.Write("Enter size of matrices: ");
                int size = int.Parse(Console.ReadLine());
                m1 = InitializeMatrix(size);
                Console.WriteLine("Now put the entries for the 2nd Matrices:");
                m2 = InitializeMatrix(size);

                while (true)
                {
                    PrintOptions();
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            GetValue();
                            break;
                        case 2:
                           GetValue2();
                            break;

                        case 3:
                            PrintMatrix(m1.Add(m2));
                            break;
                        case 4:
                            PrintMatrix(m1.Multiply(m2));
                            break;
                        case 5:
                            PrintMatrix(m1);
                            break;
                        case 6:
                            PrintMatrix(m2);
                            break;
                        case 0:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private Matrix InitializeMatrix(int size)
        {
            Console.WriteLine($"Enter diagonal elements for matrix of size {size}:");
            int[] diagonal = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);

            if (diagonal.Length != size)
            {
                throw new ArgumentException($"Diagonal should have exactly {size} elements.");
            }

            int[] firstColumn = new int[size];
            int[] lastColumn = new int[size];

            Console.WriteLine($"Enter {size - 1} elements for the first column (from the second number):");
            int[] firstColInput = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);

            if (firstColInput.Length != size - 1)
            {
                throw new ArgumentException($"First column should have exactly {size - 1} elements.");
            }

            Console.WriteLine($"Enter {size - 1} elements for the last column (except the last number):");
            int[] lastColInput = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);

            if (lastColInput.Length != size - 1)
            {
                throw new ArgumentException($"Last column should have exactly {size - 1} elements.");
            }

            for (int i = 0; i < size - 1; i++)
            {
                firstColumn[i + 1] = firstColInput[i];
                lastColumn[i] = lastColInput[i];
            }

      

            return new Matrix(size, diagonal, firstColumn, lastColumn);
        }

        private void PrintOptions()
        {
            Console.WriteLine("\n1. Get value at index for Matrix1: ");
            Console.WriteLine("2. Get value at index for Matrix2: ");
            Console.WriteLine("3. Add matrices");
            Console.WriteLine("4. Multiply matrices");
            Console.WriteLine("5. Print matrix 1");
            Console.WriteLine("6. Print matrix 2");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");
        }

        private void GetValue()
        {
            Console.Write("Enter row index: ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter column index: ");
            int col = int.Parse(Console.ReadLine());

            try
            {
                int value = m1.GetValue(row, col);
                Console.WriteLine($"Value at index [{row}, {col}] in matrix 1: {value}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void GetValue2()
        {
            Console.Write("Enter row index: ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter column index: ");
            int col = int.Parse(Console.ReadLine());

            try
            {
                int value = m2.GetValue(row, col);
                Console.WriteLine($"Value at index [{row}, {col}] in matrix 1: {value}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        private void PrintMatrix(Matrix matrix)
        {
            Console.WriteLine("Matrix:");
            matrix.PrintMatrix();
        }
    }
}
