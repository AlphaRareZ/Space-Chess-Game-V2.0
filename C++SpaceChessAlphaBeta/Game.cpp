#include "Game.h"


int Game::isValidComputerMovement(const int x, const int y) const
{
    if (x == 4)
        return false;
    else
    {
        if (matrix[x + 1][y] != '.' && x + 2 < 5 && matrix[x + 2][y] == '.')
        {
            return JUMP; // move 2 down
        }
        else if (matrix[x + 1][y] == '.')
        {
            return GOOD; // move one down
        }
        else
            return BAD; // can't move, the path is not clear
    }
}

int Game::minimaxComputerTurn(const int depth, int alpha, int beta)
{
    int score = hasWinner();
    if (score == 1)
    {
        return -1e9;
    }
    else if (score == 2)
    {
        return 1e9 - depth;
    }
    int best = 1e9;
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; ++j)
        {
            if (matrix[i][j] == 'X')
            {
                int movement = isValidPlayerMovement(i, j);
                if (movement)
                {
                    swap(matrix[i][j], matrix[i][j + movement]); // make movement
                    best = min(best, minimaxPlayerTurn(depth, alpha, beta));
                    beta = min(best, beta);
                    swap(matrix[i][j], matrix[i][j + movement]); // undo the movement
                    if (alpha >= beta)
                        break;
                }
                else
                    continue;
            }
        }
    }
    return best;
}

int Game::minimaxPlayerTurn(int depth, int alpha, int beta)
{
    int score = hasWinner();
    if (score == 1)
    {
        return -1e9;
    }
    else if (score == 2)
    {
        return 1e9 - depth;
    }

    int best = -1e9;
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; ++j)
        {
            if (matrix[i][j] == 'O')
            {
                int movement = isValidComputerMovement(i, j);
                if (movement)
                {
                    swap(matrix[i][j], matrix[i + movement][j]);
                    best = max(best, minimaxComputerTurn(depth + 1, alpha, beta));
                    alpha = max(best, alpha);
                    swap(matrix[i][j], matrix[i + movement][j]);
                    if (alpha >= beta)break;
                }
                else
                    continue;
            }
        }
    }
    return best;
}

Move Game::findBestMove()
{
    Move bestMove;

    int bestVal = -1e9;
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            if (matrix[i][j] == 'O')
            {
                int movement = isValidComputerMovement(i, j);
                if (movement)
                {
                    swap(matrix[i][j], matrix[i + movement][j]);
                    int moveVal = minimaxComputerTurn(0, -1e9, 1e9);
                    swap(matrix[i][j], matrix[i + movement][j]);

                    if (moveVal > bestVal && moveVal > 0)
                    {
                        bestMove.row = i;
                        bestMove.column = j;
                        bestVal = moveVal;
                    }
                }
            }
        }
    }
    return bestMove;
}

const char* Game::gameGrid() const
{
    return &matrix[0][0];
}

int Game::getGridSize()
{
    return 5;
}

bool Game::playerMadeMove(int i, int j)
{
    int movement = isValidPlayerMovement(i, j);
    if (movement)
    {
        swap(matrix[i][j], matrix[i][j + movement]);
        return true;
    }
    return false;
}

int Game::isValidPlayerMovement(int x, int y)
{
    if (y == 4)
        return false;
    else
    {
        if (matrix[x][y + 1] == '.')
        {
            return GOOD; // move 1 right
        }
        else if (matrix[x][y + 1] != '.' && y + 2 < 5 && matrix[x][y + 2] == '.')
        {
            return JUMP; // move 2 right
        }
        else
        {
            return BAD; // can't move, the path is not clear
        }
    }
}

bool Game::computerTurn()
{
    Move myMove = findBestMove();
    int row = myMove.row, col = myMove.column;
    if (myMove.row == -1 && myMove.column == -1)
    {
        return false;
    }
    else
    {
        swap(matrix[row][col], matrix[row + isValidComputerMovement(row, col)][col]);
        return true;
    }
}

int Game::hasWinner()
{
    if (matrix[4][1] == 'O' && matrix[4][2] == 'O' && matrix[4][3] == 'O')
    {
        return COMPUTER; // computer wins
    }
    else if (matrix[1][4] == 'X' && matrix[2][4] == 'X' && matrix[3][4] == 'X')
    {
        return PLAYER; // player wins
    }
    else
        return NONE; // no one wins ... the game is still going
}

void Game::resetGame()
{
    char gameGrid[5][5]{
        '#', 'O', 'O', 'O', '#',
        'X', '.', '.', '.', '.',
        'X', '.', '.', '.', '.',
        'X', '.', '.', '.', '.',
        '#', '.', '.', '.', '#'
    };
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            matrix[i][j] = gameGrid[i][j];
        }
    }
}
