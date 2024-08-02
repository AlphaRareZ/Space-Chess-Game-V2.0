# Space-Chess-Game-V2.0
Space Chess Game: A C++ game implementing alpha-beta pruning for AI, integrated via DLL into a C# Windows Forms GUI. Experience strategic gameplay with a futuristic twist and Win if you can! 🤪

# Alpha-Beta Pruning Game in C++ with C# GUI

This project implements a game using the **Minimax algorithm with Alpha-Beta pruning** in C++. The core game logic is encapsulated in a C++ library, which is compiled into a DLL (Dynamic Link Library) for use with a C# application. The C# application provides a graphical user interface (GUI) that makes the game more intuitive and user-friendly.

https://github.com/user-attachments/assets/2e5444b9-391a-498b-95f1-be9ddc6149df

## Features

- **Minimax Algorithm with Alpha-Beta Pruning**: The game uses the Minimax algorithm enhanced with Alpha-Beta pruning to optimize the decision-making process for the computer player. This allows the computer to make optimal moves efficiently by pruning unnecessary branches of the decision tree.

- **DLL Export**: The core game logic is compiled into a DLL, which can be linked to the C# application. This separation of concerns allows the game logic to be written in a performant, low-level language (C++), while the user interface can be developed in a more flexible, high-level language (C#).

- **C# Integration**: The exported functions from the DLL are used in the C# application to manage the game's state, update the UI, and handle user inputs. This setup provides a smooth and interactive gaming experience.

## Setup Instructions

### Building the C++ Project
1. Ensure you have a C++ compiler installed on your system.
2. Compile the C++ code into a DLL using your preferred build system (e.g., CMake, Visual Studio).
3. The resulting DLL will be used in the C# project + **No Need to Change Directories Just Clone and Enjoy** 🥳

### Running the Game
1. Launch the C# application.
2. The game should load, and you can start playing against the computer.
3. The GUI will handle user inputs and display the game's state, while the underlying C++ logic will manage the gameplay.

## Future Enhancements

- **Improved AI**: Enhance the AI by fine-tuning the Minimax algorithm or exploring other AI techniques.
- **Customizable GUI**: Develop a more customizable and visually appealing GUI in C#.
