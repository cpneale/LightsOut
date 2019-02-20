# LightsOut

## Summary
A MVP implementation of the game [Lights Out](https://en.wikipedia.org/wiki/Lights_Out_(game)) based on the following requirements.

## Requirements
Lights Out is a puzzle game consisting of an n x n grid of lights. At the beginning of the game, some of the lights are switched on. When a light is pressed, this light and the four adjacent lights are toggled, i.e., they are switched on if they were off, and switched off if they were on. The purpose of the game is to switch all the lights off.

Implement the game for a 5 by 5 grid in the .Net environment. 
The game must start with some lights turned on, and the user keeps playing till he either gives up or turns off all the lights.
There is no need to focus on the interface of the game. A simple console or WinForms application is enough.

## Setup
* Clone or download the repository and open in Visual Studio 2015+ or Visual Studio Code (not tested!).
* Build the project.
* Open a Test Explorer window and run all the tests (hopefully they'll all turn green!).

## Game Play
In Visual Studio, hit F5 to begin the game.

The game will begin with 1 random cell selected.

Click the grid until all the lights are turned out, at which point a message will be displayed and, on acknowledgement, the game will begin again.

To reset the game, hit the Reset Game button.

## Future
See Issues for the backlog of features.
