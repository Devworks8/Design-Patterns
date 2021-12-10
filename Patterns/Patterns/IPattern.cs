//
//  IPattern.cs
//
//  Author:
//       Christian Lachapelle <lachapellec@gmail.com>
//
//  Copyright (c) 2021 Devworks8
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using Patterns.Strategy;
using Patterns.Observer;
using Patterns.Decorator;
using Patterns.Factory;
using Patterns.Singleton;
using Patterns.Command;

namespace Patterns.Executor
{
    public interface IPattern
    {
        void Execute();
    }

    public class StrategyPattern : IPattern
    {
        public void Execute()
        {
            Console.WriteLine("---> Strategy Pattern <---");

            var realDuck = new Duck(new FlyStrategy(), new QuackStragery());
            var rubberDuck = new Duck(new NoFlyStrategy(), new NoQuackStrategy());

            Console.WriteLine("---realDuck---");
            realDuck.Fly();
            realDuck.Quack();

            Console.WriteLine("---rubberDuck---");
            rubberDuck.Fly();
            rubberDuck.Quack();

            Console.ReadKey(true);
        }
    }

    public class ObserverPattern : IPattern
    {
        public void Execute()
        {
            Console.WriteLine("---> Observer Pattern <---");

            ConcreteObservable observable = new ConcreteObservable();
            ConcreteObserver observer1 = new ConcreteObserver(observable);
            ConcreteObserver observer2 = new ConcreteObserver(observable);

            Console.WriteLine("Observer registred");
            observable.registerObserver(observer1);
            Console.WriteLine("Observer registred");
            observable.registerObserver(observer2);

            Console.WriteLine("Observers notified");
            observable.notifyObserver();

            Console.WriteLine("Observer unregistred");
            observable.unregisterObserver(observer1);

            Console.WriteLine("Observer notified");
            observable.notifyObserver();

            Console.ReadKey(true);
        }
    }

    public class DecoratorPattern : IPattern
    {
        public void Execute()
        {
            Console.WriteLine("---> Decorator Pattern <---");

            Beverage espresso = new Espresso();
            Beverage espressoWithSoy = new SoyDecorator(espresso);
            Beverage espressoWithSoyAndCaramel = new CaramelDecorator(espressoWithSoy);
            Beverage espressoWithCaramel = new CaramelDecorator(espresso);

            Console.WriteLine($"The cost of an Espresso is : {espresso.cost()}");
            Console.WriteLine($"The cost of an Espresso with soy is : {espressoWithSoy.cost()}");
            Console.WriteLine($"The cost of an Espresso with caramel is : {espressoWithCaramel.cost()}");
            Console.WriteLine($"The cost of an Espresso with soy and caramel is : {espressoWithSoyAndCaramel.cost()}");

            Console.ReadKey(true);
        }
    }

    public class FactoryPattern : IPattern
    {
        public void Execute()
        {
            Console.WriteLine("---> Factory Method Pattern <---");

            ConcreteCreator factoryMethod = new ConcreteCreator();

            var product1 = factoryMethod.factoryMethod();
            var product2 = factoryMethod.factoryMethod();
            var product3 = factoryMethod.factoryMethod();

            Console.WriteLine($"Product1 count value is: {product1.getCount()}");
            Console.WriteLine($"Product2 count value is: {product2.getCount()}");
            Console.WriteLine($"Product3 count value is: {product3.getCount()}");

            Console.WriteLine("\n---> Abstract Factory Pattern <---");

            ConcreteAbstractCreator abstractFactory = new ConcreteAbstractCreator();

            var abstractProduct11 = abstractFactory.abstractProduct1();
            var abstractProduct12 = abstractFactory.abstractProduct2();
                                                            
            var abstractProduct21 = abstractFactory.abstractProduct1();
            var abstractProduct22 = abstractFactory.abstractProduct2();
           
            Console.WriteLine($"Product11 count value is: {abstractProduct11.getCount()}");
            Console.WriteLine($"Product12 count value is: {abstractProduct12.getCount()}");
            Console.WriteLine($"Product21 count value is: {abstractProduct21.getCount()}");
            Console.WriteLine($"Product22 count value is: {abstractProduct22.getCount()}");
        }
    }

    public class SingletonPattern : IPattern
    {
        public void Execute()
        {
            var singleton1 = SingletonExample.getInstance();
            var singleton2 = SingletonExample.getInstance();

            Console.WriteLine("---> Singleton Pattern<---");
            Console.WriteLine($"Hashcode for singleton1: {singleton1.GetHashCode()}");
            Console.WriteLine($"Hashcode for singleton2: {singleton2.GetHashCode()}");
        }
    }

    public class CommandPattern : IPattern
    {
        public void Execute()
        {
            var receiver = new Receiver();

            var helloCommand = new HelloCommand(receiver);
            var worldCommand = new WorldCommand(receiver);

            var invoker = new Command.Invoker(helloCommand, worldCommand);

            Console.WriteLine("---> Command Pattern<---");
            
        }
    }

    public static class Invoker
    {
        private static List<IPattern> patterns = new List<IPattern>();

        public static void AddPattern(IPattern patternStrategy)
        {
            patterns.Add(patternStrategy);
        }

        public static void Execute()
        {
            foreach (IPattern pattern in patterns)
            {
                pattern.Execute();
                Console.WriteLine();
            }
        }
    }
}
