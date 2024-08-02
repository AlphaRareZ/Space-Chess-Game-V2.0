#include "Game.h"
#define ExportDll __declspec(dllexport)
extern "C" {
    Game game;

    // to be exported as dll
    ExportDll bool playerMadeMove(int i, int j) {
        return game.playerMadeMove(i, j);
    }

    ExportDll bool makeComputerMove() {
        return game.computerTurn();
    }

    ExportDll int getGridSize() {
        return game.getGridSize();
    }

    ExportDll const char* gameGrid() {
        return game.gameGrid();
    }

    ExportDll int winnerType() {
        return game.hasWinner();
    }

}
