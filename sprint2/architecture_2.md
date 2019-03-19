# Program Organization

The game starts with a GUI for playing the game, bringing up the help GUI, and quitting the game. The user will then be able to select the amount of players and start the game with the amount of players selected. Inputs will be read via controllers and the game will run until 1 player is left alive. The help GUI can be accessed during the game.

Architecture Diagram:

![alt text](https://github.com/kgminer/Hold-The-Line/blob/master/sprint1/Sequence%20Diagram.PNG)

* The "Controllers" block is there because of User Story 1, which requested that users control the movement of the base defense mechanism. 
* The "Menu" block" block is there because of User Story 3. This way a user can learn how to play and start the game.
* The "Player Slect GUI" block is there because of User Story 15, which allows the user to select the amount of players in the game.
* The "Game Logic" block is there because of User Story 5, 6, 8, 12, 14 and 23. This handles the way users want the game to work, pause the game and have a top-down view of the game.
* The "Game Over GUI" block is there because of User Story 7, which allows the user to know who has won the game.
* The "Exit Game" block is there to represent exiting the game.

# Major Classes

There will be multiple scripts for loading the game/ going into the game. Other scripts will be handling collision detection within the map. Significant classes are the player and AI class for the user and filled in bots. Some sort of management class will handle the current game state.

# Data Design

Currently, there are no special data designs used. When additional features are added, like power-ups, a data design will likely be used.

# Business Rules

There are no business rules in this project. The project is a game that isn't affected by external rules. 

# User Interface Design
Main Menu:
![alt text](https://github.com/kgminer/Hold-The-Line/blob/master/sprint1/Hold%20The%20Line%20Main%20Menu.png "Main Menu")
Player Select:
![alt text](https://github.com/kgminer/Hold-The-Line/blob/master/sprint1/Hold%20The%20Line%20Player%20Select.png "Player Select Screen")
Help:
![alt text](https://github.com/kgminer/Hold-The-Line/blob/master/sprint1/Hold%20The%20Line%20Help%20Screen.png "Help Screen")
Gameplay: Pause menu will only show up when a player hits the pause button.
![alt text](https://github.com/kgminer/Hold-The-Line/blob/master/sprint1/Hold%20The%20Line%20Game%20Screen.png "Gameplay Screen")

# Resource Management

There are no scarce resources in this project. Therefore, there is no need for resource management.

# Security

No security measures are needed. The most we are storing are user names for the players.

# Performance

The game should run at about 30 frames per second. There are going to be projectiles moving at different speeds and response time is a important factor to win the game.

# Scalability

This game is currently designed to be a local game where there is no online connectivity.

# Interoperability

This game will not communicate with other software or hardware. 

# Internationalization/Localization

This game will be in English only since it won't be distributed internationally. We will be using string in line in the code where they're needed.

# Input/Output

The errors will be handled in the field and we will use a just-in-time reading scheme. 

# Error Processing

Error processing will be corrective and active for incorrect data input before the game starts. When an error is detected, a dialogue box with an error message will pop up to the user to change input. When the game starts, error processing will be detective and the program will propagate errors for incorrect inputs on the controller and/or arrow keys. Exceptions will discard exceptions to keep the game running. Errors will be detected at the point of detection and each class will be responsible for validating its own data.

# Fault Tolerance

If any projectiles or paddles were to go out of the arena, then these items are to be placed back to its last spot in the arena and played normally.

# Architectural Feasibility

There are no architectural concerns in the project where it would hinder the performance requirements. This game is already a simpler version of more complex games with the same premise that work fine. Therefore, the game shouldn't run into any architectural feasibility issues.

# Over Engineering

We are going to be programming on the side of doing the simplest thing that works and errors will be handled accordingly.

# Build-vs-Buy Decisions

We will be using Unity as the framework for creating our game. Unity already comes with a large amount of features (specify) already built into the program, so we will not have to build them from scratch.

# Reuse

We are not planning on reusing any preexisting software that we have made, so reusability does not apply.

# Change Strategy

We will design our program to be abstract enough to handle changes should they occur during construction.
