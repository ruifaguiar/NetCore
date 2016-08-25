namespace FactoryPattern
{
     public interface IAnimalFactory
   {
       IAnimal CreateAnimal(AnimalType animalType);
   }
}