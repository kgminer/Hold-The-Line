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

The Class Diagram can be found by clicking the link [here](https://drive.google.com/file/d/1nTNHmBsXDmiHwgTFE3tG03V_o0zKW2fb/view?usp=sharing).

GameManager class: 

The GameManager class handles the game's state. It keeps track of whether the game is paused, running, or if the game has ended. It is also used to keep track of how many active players there are in the game. When the amount of players is selected in the player select screen, this information is relayed back to the GameManager so that it can set the appropriate name for each player and make the correct paddles active or inactive. While the game is running, the GameManager will continuously check how many active players are in the game, and when there is only one player left, the game is considered over and the GameManager will enter the GAME_OVER state and open the HUD's Game Over panel displaying the name of the appropriate winner. When the start button is pressed by any controller, the GameManager will enter the PAUSE state and display the pause screen from the HUD until the Resume button is pressed. It also handles the game difficulty, the longer the game is played, the harder it will get by spawning more balls and increasing their speed. Along with this is sudden death mode, which happens after the game has gone on for too long. This drastically raises the speed of the balls and increases their damage. The GameManager relates to user stories 2, 5, 7, 13, 15, and 30. User story 2 and 13 are the increasing difficulty and sudden death mode. User story 30 handles the audio slider, which is located in the options menu. It relates to 5 and 7 because it handles both the pause screen and the game over screen. It relates to user story 15 because when the user selects the amount of players from the player select screen, the GameManager will start the game with that many players.

Paddle Class: 

Implementation of user story 1 and 8.
Start() only runs when the object is created. Determines which player number the paddle is for based on the location of the paddle. Uses GetRelativePaddlePositionX() and GetRelativePaddlePositionY() to determine the paddle’s location relative to the pivot point.
Update() runs once every frame. Reads input from controller to determine which direction and speed to move the paddle. Calls 
StopPaddleAtWall() to check if the paddle has reached the wall and stop the paddle from moving any farther in that direction. Uses transform.RotateAround from Unity’s built in UnityEngine class to rotate the paddle around a fixed point based on the input from the controller.
GetRelativePaddlePositionX() checks if the paddle is to the left or to the right of the pivot point. Positive is right, negative is left.
GetRelativePaddlePositionY() checks if the paddle is above or below the pivot point. Positive is above, negative is below.
StopPaddleAtWall() checks if the paddle has reached the wall. If it has reached the wall and the controller is trying to move the paddle in that direction, then the speed of the paddle is set to zero. Otherwise this function doesn’t change the speed of the paddle at all.

Ball Class: 

Implementation of user story 6.
Start() only runs when the object is created. Sets the ball to move in a random direction.
LateUpdate() runs once at the end of every frame. Ensures that the ball velocity stays the same. Sets the rotation of the ball.
BallStartDirectionVector() function that randomly sets the direction for the ball to begin moving in. First the function determines the quadrant that it will move towards. Then it will assign a random X and Z velocity component between 0.1 and 1. This was done so that a value of zero could not be chosen, as that would get the ball stuck bouncing between the same two spots indefinitely. The two velocity values are normalized using the Vector3.Normalize() function provided by UnityEngine. The normalized velocity vector is then returned.
SetRotation() sets the ball rotation to be perpendicular to axis of translation. X and Z axes need to be flipped so that rotation is perpendicular to translation rather than rotating around the axis of translation. Z axis of rotation needs to be inverted due to right hand rule.

HUD Class:

This class is responsible for managing the various menus that appear during the actual game. This includes the Pause menu from user story 5, which has the Help menu from user story 3 contained in it, the Game Over menu from user story 7. In addition the HUD is responsible for displaying the labels that show the players which part of the screen they are located on which relates to user story 15. Get and Set methods are provided for the GameManager class to use to set up the labels based on how many players there will be at the start of the game.

QuitOnClick Class:

This class is involved with User Stories 4, 5, and 7. All of these menus have a requirement that the game should be able to quit from those menus. This class holds the code that allows the player to quit the game.

SelectOnInput Class:

This class deals with the ability for the player to select buttons on the screen using a controller. Whenever there is input from the controller, the event manager in Unity is told to move the next button in that direction, making it selectable. This plays into the implementation of user stories 9 and 11. This script allows the player to click on buttons that advance the menus to the next screen and also works for clicking on the back buttons to return to the previous screen that the player was at.

StartGameOnClick Class:

This class is responsible for user story 15 which deals with the transition from the main menu to the actual game. The function StartByIndex() is used to load from one scene to another. Additionally, the function SetNumberOfPlayers() is used to let the GameManager class in the game know how many players are in a match when it starts.

Defense Class:

This class handles the color change of the blocks to visualize the damage taken by the ball. This is done with a counter that keeps track of how many times the ball has made contact with the block inside the OnTriggerEnter() function and change the material color accordingly. If the ball hits the increased damage powerup, it will deal extra damage to the walls structures. After 4 collisions, the block will destroy itself in the function Uptade(). These tie in to user story 14 as it requested a way to visualize damage taken and to disappear after a certain amount of damage is taken. It also ties in to user story 20 as it wanted the ball to deal extra damage to destroy bases faster.

Base Class:

This class causes the players base to disappear if the ball makes contact with it. That way a player can be eliminated. This was implemented for user story 12, which allows the user(s) to see the current state of each players base. 

HitSound Class:

This class is responsible for playing an audio clip whenever any ball collides with any other game object. It relates to user story 27.

# Data Design

Currently our game implements a number of free assets that were obtained from the Unity Asset Store and from a free font generation site. The assets obtained from the Unity Store were boulder models that we are using as the ball for our game, and a set of wooden UI elements that we are using for our buttons and panels. All of these assets are contained under the Asset file of our project.

# Business Rules

There are no business rules in this project. The project is a game that isn't affected by external rules. 

# User Interface Design
The entirety of the user interface deals with user story 12. The completion of all these interfaces yields a complete representation of the game during its different phases. In addition just about every user interface deals with user stories 9 and 11. All of the menus at some point have to deal with the player being able to move from item to item, selecting those items, and going back to previous screens. The details of the individuals interfaces are broken down below.

Main Menu:
Users will interact with the main menu by using the joystick on the controller to navigate around to the different parts of the screen that they want to go to and then using the A button on the controller to select that item. This menu deals with user story 4, as it provides the main menu for the game to start at.
![alt text](https://github.com/kgminer/Hold-The-Line/blob/master/sprint1/Hold%20The%20Line%20Main%20Menu.png "Main Menu")
Player Select:
The Player Select menu is responsible for starting the game based on how many players there will be which takes care of user story 15. The player will interact with the Player Select menu in the same way that they interact with the main menu.
![alt text](https://github.com/kgminer/Hold-The-Line/blob/master/sprint1/Hold%20The%20Line%20Player%20Select.png "Player Select Screen")
Help:
The Help menu deals with user story 3 in that it displays the information to help the player learn the game. Once again, interactions are the same as the previous menus, using the joystick to move around to the button of choice and then hitting A to select that button.
![alt text](https://github.com/kgminer/Hold-The-Line/blob/master/sprint1/Hold%20The%20Line%20Help%20Screen.png "Help Screen")
Gameplay: Pause menu will only show up when a player hits the pause button. 7, 14
The Gameplay interface is the first part of the program where the user interacts with it in a different way than the other interfaces. Now each player will be tied to a base where they carry out user stories 1 and 8 which deals with moving the paddle to block projectiles that come towards their base. The game is loaded in at a top-down view which applies to user story 23. At any time during the game, the player can hit the pause button on their controller to enter into the pause screen as discussed in user story 5. While on the pause screen, interaction with the game returns to method that is used with all other interfaces. During the gameplay, the state of the walls are updated as they take damage through the code used in user story 14. This continues until there is one player remaining. This cause the game over message of user story 7 to be displayed. From here the user can choose to either quit the game or go back to the main menu to start the game over again.
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
