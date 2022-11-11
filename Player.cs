namespace Game
{
    public class Player : GameObject
    {
        public int Experience { get; set; }
        public int Damage { get; set; }
        public int Hp { get; set; }
        public int Level { get; set; }
        public bool IsAlive => Hp > 0;
        public Player( int damage, int hp)
        {
            
            Damage = damage;
            Hp = hp;
            Level = 1;
            Experience = 0;
            X = 0;
            Y = 0;
        }

        public void Attack()
        {

        }
        public void Move(int x,int y)
        {
            X += x;
            Y += y;
        }
        public void AddExp()
        {
            Experience += 40;
            if (Experience > 100)
            {
                Console.Clear();
                Console.WriteLine("Достигнут новый уровень!");
                Level++;
                Experience -= 100;
                Damage += 10;
            }
        }
        public override string ToString()
        {
            return $"Hp:{Hp} Level:{Level} Exp:{Experience} X:{X} Y:{Y}";
        }
    }
}
