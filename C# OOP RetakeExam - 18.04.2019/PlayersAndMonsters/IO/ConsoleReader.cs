﻿using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.IO
{
    class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
