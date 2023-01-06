# Conway-s-Game-Of-Life

I saw this cellular automaton on youtube and I saw it as a fun project to create. It took me way longer than it should have but I finally got it working.

**The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970. It is a zero-player game, meaning that its evolution is determined by its initial state, requiring no further input.**(Wikipedia)

This game has some simple rules every cell checks its 8 neighbours and evolves according to these rules :
1. Any live cell with two or three live neighbours survives.
2. Any dead cell with three live neighbours becomes a live cell.
3. All other live cells die in the next generation. Similarly, all other dead cells stay dead.

These simple rules create some crazy patterns and I wanted to see if I could program this application.
I used a single class for this project (Form1.cs). I used a 2D array of size 200x200 (numOfCells). The program seems to run smoothly with up to 400x400 but you have to decrease the size of cells to 1(int size) to see the whole grid. Also included the number of starting population, current population and frames elapsed.

Running Code : Download Code folder, Open Game Of Life folder, open Game Of Life.csproj

Running Application : Download Run folder, Open Game Of Life.exe
