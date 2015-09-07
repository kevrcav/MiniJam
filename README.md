# MiniJam

HOW TO PARTICIPATE IN MINIJAM:

1) create a new folder inside the 'Scenes' folder named whatever you like - try to make it unique so that there aren't any collisions with other people's names. This will be your game's name

2) inside that folder, create a scene with the same name as the folder. This will be the name of your minigame. 

3) in your new scene, create a game object with the same name (same exact, including capitalization) as your scene. Add the "MiniGame" component to it.

4) Make any other objects you add to the scene children of the MiniGame GameObject.

5) Once your game is finished, make a push request and it'll be reviewed for addition.

THE MINIGAME API:

Assuming everything is working correctly, all you'll need to interact with is the MiniGame component that you added to your scene. 

Your MiniGame component will be accessible by calling "MiniGame.Instance".

-------------

The MiniGame fields:

Game Time: int from 5-10 seconds. This is how long your game will last at maximum at 1.0 speed.

Win On Time Out: true if the player wins by reaching the time limit, false if the player loses. A game where the player has to keep juggling for the time limit would set this to true, while a hide-and-seek game would set it to false.

Instruction: The text that appears over your game when it starts and tells the player what to do. Keep it simple.

Complete Lines (Optional): Pool of lines to pull from for when the player wins your game.

Fail Lines (Optional): Pool of lines to pull form when the player loses your game.

--------------

The MiniGame methods (that you should call):

ReportWin(): Reports that the game was won.

ReportLose(): Reports that the game was lost.

The MiniGame methods (that you should not call):

StartGame(): I. Don't know what will happen if your game calls this. Probably nothing good, so, don't? Thanks.

GetCompleteLine(): You could call this, I guess, it's just an accessor for your complete and fail lines

GetInstruction(): I guess you could call this too, it's just another accessor

STUFF NOT TO DO:

Put any assets (scripts, sprites, animations, etc) outside your game's folder. Nothing outside your game's folder will be merged into the main branch.

Put any game object's Z value below -9 (because then they'll show up in front of the loading doors)

Add any objects to your scene not beneath your MiniGame component, or spawn any without parents during runtime. This will make cleanup really messy.

Change ANY scripts or assets not a part of your own game. Any changes to those will not get merged, and if your game relies on those changes it won't work outside your local copy. 
  If you find a bug and fix it, put it into its own changelist and I'll pull over that fix
