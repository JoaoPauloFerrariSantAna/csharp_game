using System;

namespace OOP5.Dices {
    public static class TargetDice
    {
        public static int CalculateTargetIndex(int maxTargets, int minTarget = 1)
        {
            Random receivedDamage = new Random();

            return receivedDamage.Next(minTarget, maxTargets);
        }
    }
}
