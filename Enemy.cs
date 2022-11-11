namespace Game
{
    public class Enemy : GameObject
    {
        public int Hp { get; set; }
        public Enemy(int x, int y, int hp)
        {
            this.X = x;
            this.Y = y;
            this.Hp = hp;

        }
        public void GetDamage(int damage)
        {
            if (damage > 0)
            {
                Hp -= damage;
            }
            if (Hp < 0)
            {
                Console.WriteLine("kill");
            }
        }
        public override string ToString()
        {
            return "X:" + X.ToString() + " Y:" + Y.ToString();
        }
    }
}
