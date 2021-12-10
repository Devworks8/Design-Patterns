// Name: Christian Lachapelle
//  Student #: A00230066
//
//  Title: 
//  Version: 
//
//  Description: 
//
//
// Command.cs
//
//  Author:
//       Christian Lachapelle <lachapellec@gmail.com>
//
//  Copyright (c) 2021 
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

namespace Patterns.Command
{
    public interface ICommand
    {
        void Execute();
        void Unexecute();
    }

    public class HelloCommand : ICommand
    {
        private Receiver receiver;

        public HelloCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            Console.WriteLine("Hello");
        }

        public void Unexecute()
        {
            Console.WriteLine("olleH");
        }
    }

    public class WorldCommand : ICommand
    {
        private Receiver receiver;

        public WorldCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            Console.WriteLine("World");
        }

        public void Unexecute()
        {
            Console.WriteLine("dlroW");
        }
    }

    public class Receiver
    {
        void Action()
        {

        }
    }

    public class Invoker
    {
        ICommand hello;
        ICommand world;

        public Invoker(ICommand hello, ICommand world)
        {
            this.hello = hello;
            this.world = world;
        }

        public void helloCommand()
        {
            this.hello.Execute();
        }

        public void worldCommand()
        {
            this.world.Execute();
        }
    }

    public class Sender
    {
        public Sender()
        {
        }
    }
}
