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

		private void PrintEnemiesHitpoints()
		{
			foreach (var enemy in this.EnemyParty)
			{
				Console.Write($"{enemy.GetName()} -> ");
				Console.WriteLine(enemy.GetBaseHealtPoints());
			}
		}

		// TODO: make a ParseAutomaticAction
		private void ParseAction(Character actor, List<Character> enemyParty, char action)
		{
			switch(action)
			{
				case (char)PossibleAtions.Attack:
					Console.WriteLine($"Which enemy would you like to attack? There are {enemyParty.Count}");

					int enemyToAttack = Convert.ToInt16(Console.ReadLine());
                    actor.Attack(enemyParty[enemyToAttack - 1]);
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
			 * para isso eu preciso de algo que me diga quando chegamos no fim do turno */
			while(this.IsInBattle) {
				while(this.IsPlayersTurn)
				{
					Console.WriteLine("---- Make Your Choise, Hero! ----");

					PrintEnemiesHitpoints();

					foreach(var chara in this.PlayerParty)
					{
						Console.WriteLine($"Your HP: {chara.GetBaseHealtPoints()}");


						Console.WriteLine($"What would you like to do, {chara.GetName()}?");
						Console.WriteLine("- [a]ttack\n- [d]efend");
						Console.Write("(action) >> ");

						char action = Convert.ToChar(Console.ReadLine());
						ParseAction(chara, this.EnemyParty, action);
					}

					this.IsPlayersTurn = false;
				}

				while(!this.IsPlayersTurn)
				{
					Console.WriteLine("---- The monster thinks...! ----");

					foreach (var enemy in this.EnemyParty)
					{
						/*
						 * 
						 * we want to make the enemy choose by itself which character to attack
						 * then we will want to make it attack the player
						 * 
						 */
						int index = enemy.ChooseTarget(this.PlayerParty.Count);

						enemy.Attack(this.PlayerParty[index]);
					}

					this.IsPlayersTurn = true;
				}
			}
		}
	}
}
