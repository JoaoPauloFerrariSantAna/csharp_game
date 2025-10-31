namespace OOP5.Entities {
	public class Enemy : Character
	{
		public Enemy(string name, int baseLevel, int baseHealthPoints,
					float baseAttack, float stealChance)
					: base(name, baseLevel, baseHealthPoints, baseAttack, stealChance) {}
	}
}
