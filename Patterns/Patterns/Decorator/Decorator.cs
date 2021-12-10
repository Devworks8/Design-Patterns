//
//  Decorator.cs
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

namespace Patterns.Decorator
{
    public abstract class Beverage
    {
        public abstract decimal cost();
    }

    public abstract class CondimentDecorator : Beverage
    {
        public override abstract decimal cost();

    }

    public class CaramelDecorator : CondimentDecorator
    {
        Beverage beverage;

        public CaramelDecorator(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override decimal cost()
        {
            return this.beverage.cost() + 0.75m;
        }
    }

    public class SoyDecorator : CondimentDecorator
    {
        Beverage beverage;

        public SoyDecorator(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override decimal cost()
        {
            return  this.beverage.cost() + 0.50m;
        }
    }

    public class Espresso : Beverage
    {
        public override decimal cost()
        {
            return 2.50m;
        }
    }

    public class Decaf : Beverage
    {
        public override decimal cost()
        {
            return 2.00m;
        }
    }
}
