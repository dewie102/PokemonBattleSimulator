# PokemonBattleSimulator

This is a textbased Pokemon Battle Simulator written in C#. The goal is to incrementally build the program to acheive the final goal.

## TASKS
- [x] Setup basic class/ program structure
- [x] Add a few `Pokemon` classes to play and test with
- [x] Add `Player` class to track information per player
- [x] Get first "simulation" working, this invovles randomly selected pokemon for each player then the users pokemon will attack until it wins
- [x] Add states to the pokemon, currently `Available` and `Fainted`
- [x] Add basic `Inventory` class and organize Pokemon to be in the players inventory
- [x] Add `Simulator` class, pull most of the code in the program class into the simulator and organize it properly
- [x] Allow the user to pick from available Pokemon
- [x] Add defense stats to the pokemon, fix attack method to calculate health and change state as needed
- [x] Allow the opponent to attack back
- [ ] Add random times where an attack will miss
- [ ] Add a `Moves` class, create some moves and add it to certain Pokemon 
- [ ] Allow the user to pick what move they want to use
- [ ] Add better control over console output and colors for easier visuals