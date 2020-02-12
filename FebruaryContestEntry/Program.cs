using System;

namespace FebruaryContestEntry
{
    internal class Program
    {
        private const char block = '▓';

        private const int cols = 30;

        private const int rows = 15;

        private static void Main(string[] args)
        {
            InitConsoleBuffer();

            Solution1();

            Console.ResetColor();
            Console.WriteLine();

            Solution2();

            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Yay, a colorful shape!");
            Console.ReadLine();
        }

        private static void InitConsoleBuffer()
        {
            Console.SetWindowSize(Math.Max(Console.WindowWidth, cols), Math.Max(Console.WindowHeight, rows));
            Console.SetBufferSize(Math.Max(Console.BufferWidth, cols), Math.Max(Console.BufferHeight, rows * 10));
        }

        private static void Solution1()
        {
            var arr = new char[cols];
            Span<char> span = arr.AsSpan();
            span.Fill(block);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(arr);

            for (int i = 1; i < rows - 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(block);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(arr, 1, cols - 2);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(block);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(span.ToArray());
        }

        private static void Solution2()
        {
            Console.WriteLine();

            var bufferTop = Console.CursorTop;

            var arr = new char[cols];
            Span<char> span = arr.AsSpan();
            span.Fill(block);

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(arr);
            }

            Console.MoveBufferArea(0, bufferTop, cols, 1, 0, bufferTop + 1, block, ConsoleColor.Green, ConsoleColor.Black);
            Console.MoveBufferArea(0, bufferTop + rows - 1, cols, 1, 0, bufferTop + 2, block, ConsoleColor.Green, ConsoleColor.Black);

            Console.MoveBufferArea(0, bufferTop, 1, rows, 1, bufferTop, block, ConsoleColor.Green, ConsoleColor.Black);
            Console.MoveBufferArea(cols - 1, bufferTop, 1, rows, 1, bufferTop, block, ConsoleColor.Green, ConsoleColor.Black);
        }
    }
}