/* Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18 */
Console.Clear();
int rowsMatrix1 = GetNumberFromUser("Укажите количество строк первой матрицы: ", "Ошибка ввода!");
int columnsMatrix1 = GetNumberFromUser("Укажите количество столбцов первой матрицы: ", "Ошибка ввода!");
int rowsMatrix2 = GetNumberFromUser("Укажите количество строк второй матрицы: ", "Ошибка ввода!");
int columnsMatrix2 = GetNumberFromUser("Укажите количество столбцов второй матрицы: ", "Ошибка ввода!");
int minValue = GetNumberFromUser("Укажите минимальное значение для элементов матриц: ", "Ошибка ввода!");
int maxValue = GetNumberFromUser("Укажите максимальное значение для элементов матриц: ", "Ошибка ввода!");
int[,] matrix1 = GetArray(rowsMatrix1, columnsMatrix1, minValue, maxValue);
Console.WriteLine("Первая матрица");
PrintArray(matrix1);
int[,] matrix2 = GetArray(rowsMatrix2, columnsMatrix2, minValue, maxValue);
Console.WriteLine("Вторая матрица");
PrintArray(matrix2);
IsPossiblyMultiplyMatrix(matrix1, matrix2);
//////////////////////////////////////////////////////////////////////////////////
// Описание методов
// Запрашивает у пользователя целое положительное число
int GetNumberFromUser(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if (isCorrect && userNumber > 0)
        {
            return userNumber;
        }
        Console.WriteLine(errorMessage);
    }
}
// создаём двумерный массив, заполненный случайными числами
int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}
// Метод для проверки возможности умножения двух матриц и вывода результата умножения в случае возможности
void IsPossiblyMultiplyMatrix(int[,] matrix1, int[,] matrix2)
{
    if (matrix1.GetLength(1) != matrix2.GetLength(0))
    {
        Console.WriteLine("Умножение данных матриц невозможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы!");
    }
    else
    {
        int[,] matrixResult = GetMultiplication(matrix1, matrix2);
        Console.WriteLine("Произведение матриц");
        PrintArray(matrixResult);
    }
}
// Метод для получения новой матрицы с результатами умножения вдух входящих матриц
int[,] GetMultiplication(int[,] arr1, int[,] arr2)
{
    int[,] matrixMult = new int[arr1.GetLength(0), arr2.GetLength(1)];
    for (int i = 0; i < arr1.GetLength(0); i++)
    {
        for (int j = 0; j < arr2.GetLength(1); j++)
        {
            matrixMult[i, j] = 0;
            for (int m = 0; m < arr2.GetLength(0); m++)
            {
                matrixMult[i, j] += arr1[i, m] * arr2[m, j];
            }
        }
    }
    return matrixMult;
}
// выводим в консоль элементы двумерного массива построчно
void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}