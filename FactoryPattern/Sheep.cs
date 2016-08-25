namespace FactoryPattern
{
    public class Sheep:IAnimal
    {
        public string Eat()
        {
            return "Grass";
        }

        public int Sleep()
        {
            return 6;
        }
    }
}