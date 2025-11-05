using System;

namespace OOP5.Dices {
    public static class DamageDice
    {
        public static int CalculateReceivedDamage(int maxDamage, int minDamage)
        {
            Random receivedDamage = new Random();

            return receivedDamage.Next(minDamage, maxDamage);
        }
    }
}
