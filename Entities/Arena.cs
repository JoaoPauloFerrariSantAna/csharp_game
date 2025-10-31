using System;
using System.Collections.Generic;
using OOP5.Entities;

namespace OOP5.Entities {
	public class Arena
	{
		private List<Character> PlayerParty;
		private List<Character> EnemyParty;

		public Arena(List<Character> playerParty, List<Character> enemyParty)
		{
			this.PlayerParty = playerParty;
			this.EnemyParty = enemyParty;
		}

		public void Start()
		{
			throw new NotImplementedException();
		}
	}
}
