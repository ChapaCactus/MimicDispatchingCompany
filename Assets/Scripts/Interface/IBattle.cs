namespace CCG
{
    public interface IBattle
    {
        void Attack(IBattle target);
        void Damage(int damage);
    }
}