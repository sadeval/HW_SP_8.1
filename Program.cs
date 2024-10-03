using System;
using System.Text;

class Program
{
    static unsafe void Main()
    {
        double value = 0;

        // Получаем указатель на переменную
        byte* ptr = (byte*)&value;

        // Записываем значение 1 в первый байт
        *ptr = 1;

        // Преобразуем символы ƍAƍ в байты 
        byte[] symbolBytes = Encoding.UTF8.GetBytes("ƍAƍ");

        // Записываем эти байты в память
        for (int i = 0; i < symbolBytes.Length; i++)
        {
            *(ptr + 1 + i) = symbolBytes[i];
        }

        // Записываем значение 2 в следующие 4 байта
        for (int i = 0; i < 4; i++)
        {
            *(ptr + 4 + i) = 2;
        }

        // Записываем значение 3 в восьмой байт
        *(ptr + 8) = 3;

        Console.WriteLine($"Результат записи: {value}");
    }
}
