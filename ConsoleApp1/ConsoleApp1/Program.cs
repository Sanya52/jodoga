﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Item
    {
        public string name;
        public string type;
        public int value;
        public  Item(string name, string type, int value)
        {
            this.name = name;
            this.type = type;
            this.value = value;

        }

    }
    class Loot
    {
        public int value;
        public double weight;
        public bool locked=true;
        //public List<Item> items=new List<Item>();
        public Item[] items;
        public int calculateValue()
        {
            int seged = 0;
            for (int i = 0; i < items.Length; i++)
            {
                seged += items[i].value;
                
            }
            return seged;
        }

    }
    class Backpack:Loot
    {
        public Backpack()
        {
            this.value = 10;
            this.weight = 20;
            this.locked = false;
            

        }

    }
    class Chest:Loot
    {
        public string name;
        public int lockpickDifficulty;
        public bool lockpicking()
        {
            Random r = new Random();
            int g = r.Next(0, 101);
            if (lockpickDifficulty < g)
            {
                return  locked=true;
            }
            else
            {
                return locked = false;
            }
        }
    }
    class SmallChest : Chest    
    {
        public SmallChest() {
            this.name = "Szegény ember tartaléka";
            this.items = { new Item("villa", "tárgy", 3); new Item("pisztoly", "fegyver", 7); new Item("szalámi", "étel", 1) }
            this.value = this.calculateValue();
            this.lockpickDifficulty = 1;

        }
    
    }
    class MediumChest : Chest
    {
        public MediumChest()
        {
            this.name = "A keresők találója";
          //  this.items = new Item("tanyer", "asd", 10)
            this.value = this.calculateValue();
            this.lockpickDifficulty = 60;
        }

    }
    class GreatChest : Chest
    {
        public GreatChest()
        {
            this.name = "A szerencsések megmentője";
            //  this.items = new Item("tanyer", "asd", 10)
            this.value = this.calculateValue();
            this.lockpickDifficulty = 85;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Backpack b = new Backpack();
            SmallChest s = new SmallChest();
            GreatChest g = new GreatChest();
            if (s.locked==true)
            {
                foreach (var item in s.items)
                {
                    Console.WriteLine(item.name+" "+item.type+" "+item.value);
                }
            }
            else
            {
                Console.WriteLine("Láda feltörése sikertelen");
            }


            Console.ReadKey();
        }
    }
}
