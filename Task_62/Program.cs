// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07
/////////////////////////////////////////////////////////////////////////////////////////////////
Console.Clear();
int sizeMatrix = GetNumberFromUser("Укажите размерность массива: ", "Ошибка ввода!");
int[,] array = GetArray(sizeMatrix);
PrintArray(array);
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
// создаём двумерный массив заданной размерности, заполненный спирально возрастающими числами от 1
int[,] GetArray(int n)
{
    int[,] result = new int[n, n];
    int count = 1;
    {
        for (int m = 0; m < n; m++)
        {
            for (int j = m; j < n - m; j++)
                result[m, j] = count++;
            for (int i = 1 + m; i < n - m; i++)
                result[i, n - 1 - m] = count++;
            for (int j = n - 2 - m; j >= 0 + m; j--)
                result[n - 1 - m, j] = count++;
            for (int i = n - 2 - m; i >= 0 + 1 + m; i--)
                result[i, 0 + m] = count++;
        }
        return result;
    }
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