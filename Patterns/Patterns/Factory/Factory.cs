//
//  Factory.cs
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

namespace Patterns.Factory
{
    // Factory Method Pattern

    public interface ICreator
    {
        IProduct factoryMethod();
    }

    public class ConcreteCreator : ICreator
    {
        private static int count = 0;

        public IProduct factoryMethod()
        {
            ConcreteProduct product = new ConcreteProduct(count);
            count++;

            return product;
        }
    }

    public interface IProduct
    {
        int getCount();
    }

    public class ConcreteProduct : IProduct
    {
        public int count;

        public ConcreteProduct(int count) => this.count = count;

        public int getCount()
        {
            return this.count;
        }
    }

    //Abstract Factory Pattern

    public interface IAbstractCreator
    {
        IAbstractProduct abstractProduct1();
        IAbstractProduct abstractProduct2();
    }

    public class ConcreteAbstractCreator : IAbstractCreator
    {
        private static int count = 0;

        public IAbstractProduct abstractProduct1()
        {
            count++;
            return new ConcreteAbstractProduct1(count);
        }
    
        public IAbstractProduct abstractProduct2()
        {
            return new ConcreteAbstractProduct2(count);
        }
    }

    public interface IAbstractProduct
    {
        int getCount();
    }

    public class ConcreteAbstractProduct1 : IAbstractProduct
    {
        private int count;

        public ConcreteAbstractProduct1(int count) => this.count = count;

        public int getCount()
        {
            return count;
        }
    }

    public class ConcreteAbstractProduct2 : IAbstractProduct
    {
        private int count;

        public ConcreteAbstractProduct2(int count) => this.count = count;

        public int getCount()
        {
            return count;
        }
    }
}
