namespace Lucha.Actor
{
    public struct DamageData
    {
        public float Amount { get; }
        public float KnockbackForce { get; }
        public Lucha.Actor.Actor Source { get; }

        public DamageData(float amount, float knockbackForce, Lucha.Actor.Actor source)
        {
            Amount = amount;
            KnockbackForce = knockbackForce;
            Source = source;
        }
    }
}