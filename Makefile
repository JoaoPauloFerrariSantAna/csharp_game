PLAYABLE_CHARACTERS := Entities/Knight.cs
DICES := Dices/DamageDice.cs Dices/TargetDice.cs
ENEMIES := Entities/Enemy.cs Entities/Orc.cs
CONSTANTS := Constants/PossibleActions.cs Constants/LevelDefaults.cs
FILES := Entities/Character.cs Entities/Arena.cs $(DICES) $(CONSTANTS) $(ENEMIES) $(PLAYABLE_CHARACTERS) Entities/Game.cs Program.cs

game: Program.cs
	mcs $(FILES) -out:Game.exe
