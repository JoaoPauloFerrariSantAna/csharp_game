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

		virtual public int ChooseTarget(int partyCount)
		{
			int targetIndex = TargetDice.CalculateTargetIndex(partyCount);

			return targetIndex - 1;
		}

        virtual public void Attack(Character chara)
		{
			// TODO: do something with defence
			int entityCurrentHeath = chara.GetBaseHealtPoints();
			int damageTaken = DamageDice.CalculateReceivedDamage(entityCurrentHeath, (int)(entityCurrentHeath - this.BaseAttack));

			// is the current health negative
			if(entityCurrentHeath <= 0 || damageTaken > entityCurrentHeath) {
				throw new Exception($"{chara.GetName()} was KO'd.");
			}

			chara.SetBaseHealtPoints(damageTaken);
		}
	}
}