using System;

namespace OOP5.Calculators
{
    public static class DamageCalculator
    {
        public static int CalculateReceivedDamage(int maxDamage, int minDamage)
        {
            Random receivedDamage = new Random();

            return receivedDamage.Next(minDamage, maxDamage);
        }
    }
}
