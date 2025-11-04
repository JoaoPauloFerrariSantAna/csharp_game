using System.Collections.Generic;
using OOP5.Constants;
using OOP5.Entities;

namespace OOP5.Entities {
	public class Game {
		private static Arena PrepareArena()
		{
			List<Character> playerParty = new List<Character> {
				new Knight(
					"Cecil Havery",
					(int)LevelDefault.CurrentLevel,
					(int)LevelDefault.Hitpoint,
					(float)LevelDefault.Attack
				)
			};

			List<Character> enemyParty =  new List<Character> {
				new Orc(
					"Orc1",
					((int)LevelDefault.CurrentLevel) + 1,
					((int)LevelDefault.Hitpoint) + 4,
					((float)LevelDefault.Attack) + 12.75f
				)
			};

			return new Arena(playerParty, enemyParty);
		}

		public static void Run()
		{
			Arena arena = PrepareArena();

			arena.Start();
		}
	}
}
