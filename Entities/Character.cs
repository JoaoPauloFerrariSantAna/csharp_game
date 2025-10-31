using System;
using static System.Math;

namespace OOP5.Entities {
	public abstract class Character
	{
		private string Name;
		private int BaseLevel;
		private int BaseHealthPoints;
		private float BaseAttack;
		private float StealChance = 0.01f;

		public Character(string name, int baseLevel, int baseHealthPoints, float baseAttack, float stealChance)
		{
			this.Name = name;
			this.BaseLevel = baseLevel;
			this.BaseHealthPoints = baseHealthPoints;
			this.BaseAttack = baseAttack;
			this.StealChance = stealChance;
		}

		public string GetName()
		{
			return this.Name;
		}

		public int GetBaseHealtPoints()
		{
			return this.BaseHealthPoints;
		}

		public void SetBaseHealtPoints(int newHealth)
		{
			this.BaseHealthPoints = newHealth;
		}

		public void UpdateHealthPoints(int damage)
		{
			int newHealth = this.BaseHealthPoints - damage;

			this.SetBaseHealtPoints(newHealth);
		}

		/**
		* i can attack
		* i can defend
		* i can heal (if i have items)
		* i have a critical chance
		* i can use magic if i'm a mage
		*/

		public int Attack(Character chara)
		{
			// TODO: do something with defence
			// TODO: do something with steal chance
			int entityCurrentHeath = chara.GetBaseHealtPoints();
			int damageTaken = (int)(entityCurrentHeath - this.BaseAttack);

			// was the damage taken the enough to KO the enemy
			if(damageTaken > entityCurrentHeath) {
				Console.WriteLine($"{chara.GetName()} was KO'd.");
				return damageTaken;
			}

			chara.SetBaseHealtPoints(damageTaken);

			return damageTaken;
		}
	}
}
