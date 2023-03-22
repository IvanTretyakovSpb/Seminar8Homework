// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
/////////////////////////////////////////////////////////////////////////////////////////////////
Console.Clear();
int rows = GetNumberFromUser("Укажите количество строк массива: ", "Ошибка ввода!");
int columns = GetNumberFromUser("Укажите количество столбцов массива: ", "Ошибка ввода!");
int minValue = GetNumberFromUser("Укажите минимальное значение для элемента массива: ", "Ошибка ввода!");
int maxValue = GetNumberFromUser("Укажите максимальное значение для элемента массива: ", "Ошибка ввода!");
int[,] array = GetArray(rows, columns, minValue, maxValue);
PrintArray(array);
int stringNumber = GetStringNumber(GetSumStringArray(array));
Console.WriteLine($"Номер строки с наименьшей суммой элементов: {stringNumber}");
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
// На основе двумерного массива получаем одномерный массив из сумм элементов в строках двумерного.
int[] GetSumStringArray(int[,] arr)
{
    int[] tempArray = new int[arr.GetLength(0)]; // создаём временный одномерный массив для записи суммы элементов каждой строки массива
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            tempArray[i] += arr[i, j];
        }
    }
    return tempArray;
}
// Метод для поиска индекса минимального элемента одномерного массива
int GetStringNumber(int[] inArray)
{
    int stringNumber = 0;
    for (int i = 1; i < inArray.Length; i++)
    {
        if (inArray[stringNumber] > inArray[i])
        {
            stringNumber = i;
        }
    }
    return stringNumber + 1; // для порядкого номера строки возвращаем число, увеличенное на 1, т.к. строки в массиве нумеруются с 0
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