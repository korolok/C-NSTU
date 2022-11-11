using System;

namespace Game
{
    public class Game
    {
        public Player Player { get; set; }
        public List<Enemy> Enemys { get; set; }
        public Game()
        {
            Player = new Player(24, 100);
            Enemys= GenerationEnemy();
        }
        public void AwaitPlayerAction()  //метод с циклом пока не выход продолжаем: вывод «Выбор действия: атака или передвижение
        {
            while(Player.IsAlive)
            {
                Console.WriteLine(Player.ToString());
                Console.Write("Действие(attack/move/map):");
                string action = Console.ReadLine();
                DoPlayeraction(action);
              
            }
        }
        public void DoPlayeraction(string action)//case attack / case move 
        {

            switch (action)
            {
                case "attack":
                    var enemy = GetNearstEnemy();
                    if (enemy != null)
                    {
                        enemy.GetDamage(Player.Damage);
                        if (enemy.Hp <= 0)
                        {
                            Enemys.Remove(enemy);
                            Player.AddExp();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"Hp противника:{enemy.Hp}");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("удар в пустоту");
                    }
                    break;
                case "move":
                    Console.Write("Куда идем(forward/backward/up/down):");
                    string direction = Console.ReadLine();
                    Move(direction);
                    var checkEnemy = GetNearstEnemy();
                    if (checkEnemy != null)
                    {
                        Console.WriteLine($"На пути противк!\n HP:{checkEnemy.Hp}");
                    }
                    break;
                case "map":
                    MiniMap();
                    break;
                default:
                    Console.WriteLine("Нет такой команды");
                    break;
            }

            
            
        }
        private Enemy GetNearstEnemy()//Получение противника с которым находимся в одной позиции
        {
            foreach(var enemy in Enemys)
            {
                if (Player.Colide(enemy))
                {
                    return enemy;
                }
            }
            return null;
        }

        private void Move(string direction)
        {
            switch (direction)
            {
                case "forward":
                    Player.Move(1, 0);
                    break;
                case "backward":
                    Player.Move(-1, 0);
                    break;
                case "up":
                    Player.Move(0, 1);
                    break;
                case "down":
                    Player.Move(0,-1);
                    break;
                default:
                    Console.WriteLine("Нет такого движения");
                    break;
            }

        }

        private List<Enemy> GenerationEnemy()
        {
            Enemys = new List<Enemy>();
            Random random = new Random();

            Enemys.Add(new Enemy(random.Next(0,6), random.Next(0,3), 55));
            Enemys.Add(new Enemy(random.Next(6, 9), random.Next(0, 3), 55));
            Enemys.Add(new Enemy(random.Next(9, 12), random.Next(0, 3), 55));
            return Enemys;
        }
        private void MiniMap()
        {
            Console.WriteLine("Противники");
            foreach (var enemy in Enemys)
            {
                Console.WriteLine(enemy.ToString());
            }
        }
    }
}
