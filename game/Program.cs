﻿namespace game;

class Program
{
    static void Main(string[] args)
    {
        Monster m = new Monster(1, "Goblin", 3, 0, 10);
        World.LocationByID(1).MonsterLivingHere = m;
        World.LocationByID(1).DisplayOptions();
    }
}
