using System;
using System.Collections.Generic;
using OOP5.Constants;
using OOP5.Entities;

namespace OOP5.Entities {
	public class Arena
	{
		private List<Character> PlayerParty;
		private List<Character> EnemyParty;
		private bool IsInBattle;
		private bool IsPlayersTurn;

		public Arena(List<Character> playerParty, List<Character> enemyParty)
		{
			this.PlayerParty = playerParty;
			this.EnemyParty = enemyParty;
			this.IsInBattle = true;
			// will be used in the state machine
			this.IsPlayersTurn = true;
		}

		private void ParsePlayerAction(char action)
		{
			switch(action)
			{
				case (char)PossibleAtions.Attack:
					Console.WriteLine("Atacando!");
				break;

				case (char)PossibleAtions.Defend:
					Console.WriteLine("Defendendo");
				break;

				default:
				break;
			}
		}

		public void Start()
		{
			/* TODO: fazer um sistema de turnos
			 * preciso que tenha um "começo de turno"
			 * preciso que tenha um "fim de turno"
			 * para isso eu preciso de algo que me diga quando chegamos no fim do turno
			*/
			while(this.IsInBattle) {
				Console.WriteLine("Players turn!");
				while(this.IsPlayersTurn)
				{
					foreach(var chara in this.PlayerParty)
					{
						Console.WriteLine("What would you like to do?");
						Console.WriteLine("- [a]ttack\n- [d]efend");
						Console.Write("(action) >> ");
						char action = Convert.ToChar(Console.ReadLine());
						ParsePlayerAction(action);
					}

					this.IsPlayersTurn = false;
				}

				Console.WriteLine("Enemies turn!");

				while(!this.IsPlayersTurn)
				{
					this.IsPlayersTurn = true;
				}
			}
		}
	}
}
