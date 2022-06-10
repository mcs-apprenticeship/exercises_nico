class TowerOfHanoi
{
    public static void Main()
    {
        TowerOfHanoi towerOfHanoi = new TowerOfHanoi();
        towerOfHanoi.start();
    }

    private void start()
    {
        moveTowers(4, 'a', 'c', 'b');
    }

    private void moveTowers (int amountOfPlates, char from, char to, char other)
    {
        if(amountOfPlates == 0)
        {
            return;
        }
        if(amountOfPlates == 1)
        {
            Console.WriteLine($"move from {from} to {to}");
            return;
        }
        moveTowers(amountOfPlates - 1, from, other, to);
        moveTowers(1, from, to, other);
        moveTowers(amountOfPlates - 1, other, to, from);
    }
}