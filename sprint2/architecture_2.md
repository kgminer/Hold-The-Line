# Program Organization

The game will start with an interface for interacting with the user by starting the game, leaving the game, help, etc. Once the game has started, the program will be interpreting input commands to play the game. The game will run continuously until the game ending criteria is met. When that criteria is met, the program will interact with the user to either start another game or leave the game.

# Major Classes

There will be multiple scripts for loading the game/ going into the game. Other scripts will be handling collision detection within the map. Significant classes are the player and AI class for the user and filled in bots. Some sort of management class will handle the current game state.

# Data Design

At the moment, we don't know how we are going to store current states of objects in the game. However, a method will be established in the near future and this section will be updated.

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
