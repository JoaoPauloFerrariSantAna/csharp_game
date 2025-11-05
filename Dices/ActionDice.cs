using System;
using OOP5.Constants;

namespace OOP5.Dices {
	public static class ActionDice
	{
		public static int ChooseAction()
		{
			Random action = new Random();

			for(int warmer = 0; warmer <= 5; warmer++)
			{
				action.Next((int)EnemyState.Attacking, (int)EnemyState.Still);
			}

			int actionToBeDone = action.Next((int)EnemyState.Attacking, (int)EnemyState.Defend);

			return actionToBeDone;
		}
	}
}
