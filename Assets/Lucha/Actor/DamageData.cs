namespace Lucha.Actor
{
    public struct DamageData
    {
        public float Amount { get; }
        public float KnockbackForce { get; }
        public Actor Source { get; }

        public DamageData(float amount, float knockbackForce, Actor source)
        {
            Amount = amount;
            KnockbackForce = knockbackForce;
            Source = source;
        }
    }
}