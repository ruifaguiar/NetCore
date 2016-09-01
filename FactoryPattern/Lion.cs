namespace NetCore.FactoryPattern
{
public class Lion:IAnimal
    {
       public string Eat()
       {
           return "sheep";
       }

       public int Sleep()
       {
           return 3;
       }
    }
}