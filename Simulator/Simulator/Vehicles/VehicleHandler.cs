﻿using Simulator.Dijkstra;
using Simulator.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulator
{
    public class VehicleHandler
    {
        public static readonly VehicleHandler Instance = new VehicleHandler();
        public static readonly List<Vehicle> CurrentVehicles = new List<Vehicle>();
        public static readonly Random RandomNumberGenerator = new Random();

        private Thread UpdateVehicleThread;

        private VehicleHandler()
        {
            
        }

        public void StartVehicleHandler()
        {
            this.UpdateVehicleThread = new Thread(UpdateVehicles);
            this.UpdateVehicleThread.Name = "UpdateVehicleThread";
            this.UpdateVehicleThread.Start();
        }

        public void SpawnVehicle(Direction StartDirection, Direction EndDirection, VehicleType Vehicle)
        {
            List<Node> SuitableStartNodes = new List<Node>();

            foreach (EntryNode n in Map.Instance.EntryPoints)
            {
                if (n.StartDirection == StartDirection)
                {
                    SuitableStartNodes.Add(n);
                }
            }

            if (SuitableStartNodes.Count == 0)
            {
                LogHandler.Instance.Write("Invalid StartDirection for this vehicle", LogType.Warning);
                return;
            }

            if (Vehicle == VehicleType.Auto)
            {
                int DefaultRotation = (StartDirection == Direction.Noord || StartDirection == Direction.Zuid || StartDirection == Direction.Ventweg) ? 90 : 0;

                new Car(SuitableStartNodes[RandomNumberGenerator.Next(0, SuitableStartNodes.Count)], DefaultRotation, EndDirection); 
            }
        }

        private void UpdateVehicles()
        {
            LogHandler.Instance.Write("Now updating vehicles", LogType.Info);

            while (true)
            {
             //   LogHandler.Instance.Write("Updating vehicles", LogType.Info);

                try
                {
                    foreach (Vehicle v in CurrentVehicles)
                    {
                        v.Update();
                    }
                }
                catch(Exception)
                {

                }

                Thread.Sleep(25);
            }
        }

    }
}