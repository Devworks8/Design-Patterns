//
//  Strategy.cs
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

namespace Patterns.Strategy
{
    public interface IFlyingBehaviour
    {
        void Fly();
    }

    public interface IQuackingBehaviour
    {
        void Quack();
    }

    public class FlyStrategy : IFlyingBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("This bird can fly");
        }
    }

    public class NoFlyStrategy : IFlyingBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("This bird can't fly");
        }
    }

    public class QuackStragery : IQuackingBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("This bird can quack");
        }
    }

    public class NoQuackStrategy : IQuackingBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("This bird can't quack");
        }
    }

    public class Duck
    {
        private IQuackingBehaviour quackingStrategy;
        private IFlyingBehaviour flyingStrategy;

        public Duck(IFlyingBehaviour flyingStrategy, IQuackingBehaviour quackingStrategy)
        {
            this.quackingStrategy = quackingStrategy;
            this.flyingStrategy = flyingStrategy;
        }

        public void Fly()
        {
            flyingStrategy.Fly();
        }

        public void Quack()
        {
            quackingStrategy.Quack();
        }
    }
}
