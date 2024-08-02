using System;
using System.Runtime.InteropServices;

namespace SpaceChessGUI.Model.Wrapper
{
    internal abstract class GameWrapper
    {
        private const string DllString = @"..\..\..\x64\Release\C++SpaceChessAlphaBeta.dll";

        // DLL imports From C++
        [DllImport(DllString, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool playerMadeMove(int i, int j);

        [DllImport(DllString, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool makeComputerMove();

        [DllImport(DllString, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getGridSize();

        [DllImport(DllString, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gameGrid();

        [DllImport(DllString, CallingConvention = CallingConvention.Cdecl)]
        public static extern int winnerType();

        [DllImport(DllString, CallingConvention = CallingConvention.Cdecl)]
        public static extern void resetGame();

        // Parse the IntPtr gameGrid into 2d character array
        public static char[,] GetGameGrid()
        {
            int size = getGridSize();

            IntPtr intPtr = gameGrid();

            char[,] grid = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = Marshal.PtrToStructure<char>(intPtr + (i * size + j));
                }
            }

            return grid;
        }
    }
}