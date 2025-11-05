using System;
using static System.Math;
using OOP5.Dices;

namespace OOP5.Entities {
	public abstract class Character
	{
		private string Name;
		private int BaseLevel;
		private int BaseHealthPoints;
		private float BaseAttack;

		public Character(string name, int baseLevel, int baseHealthPoints, float baseAttack)
		{
			this.Name = name;
			this.BaseLevel = baseLevel;
			this.BaseHealthPoints = baseHealthPoints;
			this.BaseAttack = baseAttack;
		}

		public string GetName()
		{
			return this.Name;
		}

		public int GetBaseHealtPoints()
		{
			return this.BaseHealthPoints;
		}

		public int GetCurrentLevel()
		{
			return this.BaseLevel;
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
		* i can heal (if i have items or if i'm a mage)
		* i have a critical chance
		* i can use magic if i'm a mage
		*/

		virtual public int ChooseTarget(int partyCount)
		{
			int targetIndex = TargetDice.CalculateTargetIndex(partyCount);

			return targetIndex - 1;
		}

        virtual public void Attack(Character chara)
		{
			// TODO: do something with defence
			int currentHealth = chara.GetBaseHealtPoints();
			int damageTaken = DamageDice.CalculateReceivedDamage(
				currentHealth,
				(int)((currentHealth - this.BaseAttack) - (chara.GetCurrentLevel() / 10))
			);

			// is the current health negative
			if(currentHealth <= 0 || damageTaken > currentHealth) {
				throw new Exception($"{chara.GetName()} was KO'd.");
			}

			chara.SetBaseHealtPoints(damageTaken);
		}
	}
}
