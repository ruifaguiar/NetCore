using System;

namespace NetCore.FactoryPattern 
{
public class AnimalFactory : IAnimalFactory
    {
        private AnimalFactory()
        {

        }
        public IAnimal CreateAnimal(AnimalType typeOfAnimal)
        {
            switch (typeOfAnimal)
            {
                case AnimalType.Carnivore:
                    return new Lion();
                case AnimalType.Herbivore:
                    return new Sheep();
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeOfAnimal), typeOfAnimal, null);
            }
        }

        public static AnimalFactory CreateFactory()
        {
            return new AnimalFactory();
        }
    }
}