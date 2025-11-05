using OOP5.Constants;
using OOP5.Dices;
using OOP5.Entities;

namespace OOP5.Entities {
	public class Enemy : Character
	{
		public Enemy(string name, int baseLevel, int baseHealthPoints,
					float baseAttack)
					: base(name, baseLevel, baseHealthPoints, baseAttack) {}

		override public void Act(Character playerCharacter)
		{
			EnemyState state = (EnemyState)ActionDice.ChooseAction();

			if(state == EnemyState.Attacking)
			{
				Attack(playerCharacter);
			}
		}
	}
}
