using System;
using System.Runtime.InteropServices;

namespace SpaceChessGUI.Model
{
    internal class GameWrapper
    {
        private const string dllString = @"..\..\x64\Debug\C++SpaceChessAlphaBeta.dll";
        // DLL imports From C++
        [DllImport(dllString, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool playerMadeMove(int i, int j);

        [DllImport(dllString, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool makeComputerMove();

        [DllImport(dllString, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getGridSize();

        [DllImport(dllString, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gameGrid();

        [DllImport(dllString, CallingConvention = CallingConvention.Cdecl)]
        public static extern int winnerType();

        // 
        public static char[,] getGameGrid()
        {
            int size = getGridSize();

            IntPtr intPtr = gameGrid();

            char[,] grid = new char[size ,size];
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
