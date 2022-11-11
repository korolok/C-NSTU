namespace Game
{
    public class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Colide(GameObject gameObject)
        {
            return gameObject.X == X && gameObject.Y == Y;
        }
        public void Move(int x, int y) 
        {
            X += x;
            Y += y;  
        }
    }
}
