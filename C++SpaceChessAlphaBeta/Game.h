#ifndef GAME_H
#define GAME_H
using namespace std;
#include <algorithm> // For std::swap
#include <iostream>

// Define the enums for the movement validity and game result
// Define the enums for the movement validity and game result
enum Movement {
    GOOD = 1,
    JUMP = 2,
    BAD = 0
};

enum Result {
    NONE = 0,
    PLAYER = 1,
    COMPUTER = 2
};

struct Move {
    int row = -1;
    int column = -1;
};

class Game {
private:
    char matrix[5][5]{
        '#', 'O', 'O', 'O', '#',
        'X', '.', '.', '.', '.',
        'X', '.', '.', '.', '.',
        'X', '.', '.', '.', '.',
        '#', '.', '.', '.', '#'
    };

    int isValidComputerMovement(int x, int y) const;
    int minimaxComputerTurn(int depth, int alpha, int beta);
    int minimaxPlayerTurn(int depth, int alpha, int beta);
    Move findBestMove();

public:
    const char* gameGrid() const;
    static int getGridSize();
    bool playerMadeMove(int i, int j);
    int isValidPlayerMovement(int x, int y);
    bool computerTurn();
    int hasWinner();
};

#endif // GAME_H
