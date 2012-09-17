﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackRain.Common.Objects;
using System.Diagnostics;
using System.Threading;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var proc = Process.GetProcessesByName("wow");

            foreach (var p in proc)
            {
                ObjectManager.Initialize(p);

                while (true)
                {
                    Console.Clear();
                    // 16057
                    ObjectManager.Pulse();
                   
                    Console.WriteLine("[LocalPlayer]");
                    Console.WriteLine("Name: " + ObjectManager.Me.Name);
                    Console.WriteLine("Target: " + ObjectManager.Me.Target);

                    

                    foreach (WowGameObject gameObject in ObjectManager.GameObjects)
                    {
                       // Console.WriteLine(gameObject.Name);
                    }

                    foreach (WowUnit unit in ObjectManager.Units)
                    {
                        if (ObjectManager.Me.Target == unit.GUID)
                        {
                            Console.WriteLine(unit.Name);
                        }
                        
                    }

                    //  Console.WriteLine("Health: " + ObjectManager.Me.Health + "/" + ObjectManager.Me.MaximumHealth + " " + ObjectManager.Me.HealthPercentage);
                    Console.WriteLine("X:" + ObjectManager.Me.X + " Y:" + ObjectManager.Me.Y + " Z:" + ObjectManager.Me.Z);
                    Thread.Sleep(100);
                    
                }
            }


            //Console.WriteLine(ObjectManager.GameObjects.Count);


            Console.Read();
        }
    }
}
