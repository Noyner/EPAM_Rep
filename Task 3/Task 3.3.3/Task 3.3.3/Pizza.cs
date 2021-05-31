namespace Task_3._3._3
{
    abstract class Pizza
    {
        public string Name { get; protected set; }
        public abstract int GetCost();
        public Pizza(string n)
        {
            this.Name = n;
        }
    }
}
