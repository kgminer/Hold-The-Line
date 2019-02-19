# Program Organization



# Major Classes



# Data Design

At the moment, we don't know how we are going to store current states of objects in the game. However, a method will be established in the near future and this section will be updated.

# Business Rules

There are no business rules in this project. The project is a game that isn't affected by external rules. 

# User Interface Design

# Resource Management

There are no scarce resources in this project. Therefore, there is no need for resource management.

# Security

No security measures are needed. The most we are storing are usenames for the players.

# Performance

The game should run at about 30 frames per second. There are going to be projectiles moving at different speeds and respose times is an important factor to win the game.

# Scalability

This game is currently designed to be a local game where there is no online connectivity.

# Interoperability

This game will not communvate with other sortware or hardware. 

# Internationalization/Localization

This game will be in English only since it won't be distributed internationally. We will be using string in line in the code where they're needed.

# Input/Output

The errors whould handled in the field and we would use a just-in-time reading scheme. 

# Error Processing

Error processing will be corrective and active for incorrect data input before the game starts. When an error is detected, a dialogue box with an error message will pop up to the user to change input. When the game starts, error processing will be detective and the program will propagate errors for incorrect inputs on the controller and/or arrow keys. Exceptions will discard exceptions to keep the game running. Errors will be detected at the point of detection and each class will be resonsible for validating it's own data.

# Fault Tolerance

If any projectiles or paddles were to go out of the arena, then these items are to be placed back to its last spot in the arena and played normally.

# Architectural Feasibility

There are no architectural concerns in the project where it would hinder the performance requirements. 

# Overengineering

We are going to be programming on the side of doing the simplest thing that works and errors will be handled accordingly.

# Build-vs-Buy Decisions

We will be using Unity as the framework for creating our game. Unity already comes with a large amount of features (specify) already built into the program, so we will not have to build them from skratch.

# Reuse

We are not planning on reusing any preexisting software that we have made, so reusability does not apply.

# Change Strategy

We will design our program to be abstract enough to handle changes should they occur during construction.
