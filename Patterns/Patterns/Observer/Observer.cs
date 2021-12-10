//
//  Observer.cs
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

namespace Patterns.Observer
{
    public interface IObservable
    {
        void registerObserver(IObserver observer);
        void unregisterObserver(IObserver observer);
        void notifyObserver();

    }

    public interface IObserver
    {
        void update();
    }

    public class ConcreteObserver : IObserver
    {
        ConcreteObservable observable;

        public ConcreteObserver(ConcreteObservable observable)
        {
            this.observable = observable;
        }

        public void update()
        {
            Console.WriteLine("Observer has received update notice");
            Console.WriteLine(observable.getState());
            
        }
    }

    public class ConcreteObservable : IObservable
    {
        private List<IObserver> observers = new List<IObserver>();

        public ConcreteObservable()
        {

        }

        public void registerObserver(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void unregisterObserver(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void notifyObserver()
        {
            foreach (IObserver observer in this.observers)
            {
                observer.update();
            }
        }

        public string getState()
        {
            return "State requested";
        }
    }
}
