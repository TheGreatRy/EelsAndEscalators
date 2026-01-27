# Eels & Escalators 
3D Video Game version of Snakes and Ladders based on the Spongebob Squarepants episode. 

## What Is This? 
This is our recreation of the Eels and Escalators board game from Spongebob Squarepants. It's a variation of Snakes and Ladders where instead of a flat board, players are moved up and down a spiral staircase. 2-6 players can play locally and try to get to the top of the board first. 

*Made in Unity for our software engineering class.*

# Features 
- 2-6 player local multiplayer
- Turn-based gameplay
- Roll a die to move your piece
- Land on escalators to go up multiple spaces
- Land on eels to slide down multiple spaces
- Penalty voting system (players can vote to penalize other players)
- Custom player names
- Mute button for sound
- Camera options to help with motion sickness 

# System Requirements 
- Windows 10 or Newer
- Keyboard and Mouse
- Local Player Support
- Installation 

# Installation 

- Clone this repository with `git clone https://github.com/eels-and-escalators.git'`
- Open the project in Unity. This was built using Version 6000.3.4f1
- Open the EelsAndEscalators Scene located in `Assets/Scenes/`
- Hit `Play` to run it within Unity or build it for Windows under `File -> Build Settings` 

# How to Play 
*Initialization*
- Start the game and enter player names (2-6 players, empty names don't count)
- Everyone votes on who goes first
- Rest of the turn order is chosen by players 

*On your turn:*  
- Other players can vote to penalize you (optional, 10 second window)
- Roll the die by clicking the button
- Your piece moves forward

*Movement*
- Normal Space: No special action is taken, and your movement stops on it
- Escalator Space: On a space adjacent to the base of an escalator, your piece advances up it and stops on the corresponding space at the top of the escalator
- Eel Space: On a space adjacent to the tail of an eel, your piece slides down it and stops on the corresponding space at the head of the eel 

*Win Condidtion*
- Turn passes to next player until the first one to reach the final space at the top, who is declared the winner 

# Game Rules 

## Basic Rules 
- Roll a die (1-6) to move forward
- Escalators = move UP
- Eels = move DOWN
- Multiple pieces can be on same space
- First to final space wins (The die roll can be exact or above the required spaces) 

## Penalty Votes 
*At start of each turn:* 
- Other players have 10 seconds to call a vote
- Everyone votes (except current player)
- If majority says yes, that player moves back to nearest eel 

## Penalty Vote Rules:  
- Only 1 vote per turn
- Each player can only call 3 votes total per game
- Can't vote against yourself
- Ties = no penalty 

# Controls 
- Mouse - click buttons
- Keyboard - type player names
- "Roll Die" button - rolls the die
- "Vote" button - start a penalty vote 

# Project Structure 

## We used 5 main modules: 
- `Game Manager` - runs the whole game, tracks turns, checks win conditions
- `Player Controller` - handles individual player stuff like position and die rolls
- `UI Manager` - updates the display and shows info
- `Rule Set` - makes sure moves are legal and determines turn order
- `Board Tile` - individual spaces on the board (normal, eel, escalator, or win) 

*Data is stored using 3D vectors for positions and arrays for the board spaces.*

# Team 
- Ry Ellender
- Kay Desist
- Trinten Tatar 

*Built with Unity for our SE class. We used Waterfall methodology and had 2 weeks to make this.*

# Documentation 
*Check out our [SRS](https://neumont-my.sharepoint.com/:w:/g/personal/rellender_student_neumont_edu/IQD9g4Tixj-MQJdv-Qj6B1khAVxNPcDT87AcYGfO8bvwPTg?e=I6aeR4) and [SDD](https://neumont-my.sharepoint.com/:w:/g/personal/rellender_student_neumont_edu/IQDZ70mtxNUnTI9K5WgIFZQXASR19Xo0lI5UuyPnyV6ZVJI?e=bIZBVN) documents for more detailed info about requirements and design!*

# References 
- [Snakes and Ladders](https://en.wikipedia.org/wiki/Snakes_and_ladders)
- [Eels and Escalators Board Game](https://a.co/d/0hps2gt)

 
