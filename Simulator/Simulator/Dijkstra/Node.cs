﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Simulator.UserControls;

namespace Simulator.Dijkstra
{
    public class Node : DynamicObject
    {
        private int _ID;
        public int ID
        {
            get
            {
                if (this._ID == 0)
                {
                    _ID = Node.GenerateID();
                }

                return _ID;
            }
        }

        public DateTime LastPassed { get; private set; }
        public Vehicle LastPassedVehicle { get; internal set; }
        public Vehicle LastPassedSecondLaneVehicle { get; internal set; }
        private Canvas MapCanvas = Map.Instance;
        public Position CurrentPosition { get; private set; }
        public List<Path> Paths { get; private set; }
        private string Label = "";
        private bool DrawnOnCanvas = false;
        public Color NodeColor { get; protected set; }
        public VehicleType[] AllowedVehicles = new VehicleType[] { VehicleType.Auto, VehicleType.Bus };
        protected Shape NodeEllipse = new System.Windows.Shapes.Ellipse();
        public int ExtraCost { get; protected set; }

        //Local variables
        protected Color FillColor = Colors.White;

        public Node(Position CurrentPosition, string Label = "", VehicleType[] AllowedVehicles = null, int ExtraCost = 0)
            : base()
        {
            this.NodeColor = Colors.Red;
            this.Paths = new List<Path>();
            this.CurrentPosition = CurrentPosition;
            this.NodeColor = NodeColor;
            this.Label = Label;
            this.ExtraCost = ExtraCost;

            if (AllowedVehicles != null)
            {
                this.AllowedVehicles = AllowedVehicles;
            }
        }

        public Node AddNode(Node DestinationNode)
        {
            if (this is BusNode || this is BicycleNode)
            {
                this.Paths.Add(new Path(this, DestinationNode, this.NodeColor));
            }
            else
            {
                this.Paths.Add(new Path(this, DestinationNode, DestinationNode.NodeColor));
            }

            return DestinationNode;
        }

        public void Draw()
        {
            if (!this.DrawnOnCanvas)
            {
                this.DrawnOnCanvas = true;
                NodeEllipse.Height = 20;
                NodeEllipse.Width = 20;
                NodeEllipse.StrokeThickness = 2;
                NodeEllipse.Stroke = new SolidColorBrush(this.NodeColor);
                NodeEllipse.Fill = new SolidColorBrush(this.FillColor);

                NodeEllipse.Margin = new Thickness(CurrentPosition.X - 10, CurrentPosition.Y - 10, 0, 0);

                TextBlock IDNumberTextblock = new TextBlock();
                IDNumberTextblock.Text = this.Label;
                IDNumberTextblock.FontWeight = FontWeight.FromOpenTypeWeight(500);
                IDNumberTextblock.Margin = new Thickness(CurrentPosition.X - 5, CurrentPosition.Y - 8, 0, 0);



                foreach (Path p in this.Paths)
                {
                    p.Draw();
                }
                if (Config.DisplayNodes || this is TrafficLight)
                {
                    if (this is TrafficLight)
                    {
                        NodeEllipse.Margin = new Thickness(CurrentPosition.X - 7, CurrentPosition.Y - 7, 0, 0);
                        NodeEllipse.StrokeThickness = 0;
                        NodeEllipse.Height = 14;
                        NodeEllipse.Width = 14;
                    }

                    this.MapCanvas.Children.Add(NodeEllipse);
                    Map.SetZIndex(NodeEllipse, 253);
                }
                else if (this.AllowedVehicles.Contains(VehicleType.Auto) || this.AllowedVehicles.Contains(VehicleType.Bus))
                {
                    NodeEllipse.Height = 14;
                    NodeEllipse.Width = 14;
                    NodeEllipse.Margin = new Thickness(CurrentPosition.X - 7, CurrentPosition.Y - 7, 0, 0);
                    NodeEllipse.Stroke = new SolidColorBrush(Colors.LightGray);
                    NodeEllipse.Fill = new SolidColorBrush(Colors.LightGray);
                    this.MapCanvas.Children.Add(NodeEllipse);
                    Map.SetZIndex(NodeEllipse, 10);
                }
                else if (this.AllowedVehicles.Contains(VehicleType.Fiets))
                {
                    NodeEllipse.Height = 6;
                    NodeEllipse.Width = 6;
                    NodeEllipse.Margin = new Thickness(CurrentPosition.X - 3, CurrentPosition.Y - 3, 0, 0);
                    NodeEllipse.Stroke = new SolidColorBrush(Colors.Orange);
                    NodeEllipse.Fill = new SolidColorBrush(Colors.Orange);
                    this.MapCanvas.Children.Add(NodeEllipse);
                    Map.SetZIndex(NodeEllipse, 10);
                }

                if (Config.DisplayNodes)
                {
                    this.MapCanvas.Children.Add(IDNumberTextblock);
                    Map.SetZIndex(IDNumberTextblock, 254);
                }
            }
        }

        public void SetLabel(string Label)
        {
            this.Label = Label;
        }

        public override string ToString()
        {
            return Label;
        }

        private static int CurrentIDCount = 0;
        private static int GenerateID()
        {
            return ++CurrentIDCount;
        }

        /// <summary>
        /// Dijkstra implementation
        /// </summary>
        /// <param name="TargetDirection"></param>
        /// <returns></returns>
        internal int CalculateCostOfRoute(Direction TargetDirection, int CurrentCost, Vehicle vehicle, List<Path> VisitedPaths)
        {
            int LowestCost = int.MaxValue;
            CurrentCost += this.ExtraCost;

            if (!this.VehicleAllowed(vehicle))
            {
                return Int32.MaxValue;
            }

            if (this is ExitNode && (this as ExitNode).ExitDirection != TargetDirection)
            {
                LowestCost = Int32.MaxValue;
            }
            else
            {
                if (this is ExitNode)
                {
                    LowestCost = CurrentCost;
                }

                foreach (Path p in this.Paths)
                {
                    if (VisitedPaths.Contains(p))
                    {
                        continue;
                    }

                    int CurrentPathCost = p.CalculateCostOfRoute(TargetDirection, CurrentCost, vehicle, VisitedPaths);

                    if (CurrentPathCost < LowestCost)
                    {
                        LowestCost = CurrentPathCost;
                    }
                }
            }

            return LowestCost;
        }

        public virtual Node GetNodeWithLowestCost(Direction TargetDirection, Vehicle vehicle)
        {
            this.LastPassed = DateTime.Now;

            int LowestCost = Int32.MaxValue;
            Node NodeWithLowestCost = null;
            

            foreach (Path p in this.Paths)
            {
                List<Path> VisitedPaths = new List<Path>();

                int CurrentPathCost = p.CalculateCostOfRoute(TargetDirection, 0, vehicle, VisitedPaths);

                if (CurrentPathCost < LowestCost)
                {
                    LowestCost = CurrentPathCost;
                    NodeWithLowestCost = p.Destination;
                }
            }

            if (NodeWithLowestCost == null)
            {
                if (vehicle.CurrentNode is EntryNode)
                {
                    try
                    {
                        VehicleHandler.InvalidDirections.Add((vehicle.CurrentNode as EntryNode).StartDirection, TargetDirection);
                    }
                    catch
                    {

                    }
                }

                vehicle.Dispose();
                return null;
            }

            if (this.Paths.First().Destination != NodeWithLowestCost)
            {
                this.LastPassedSecondLaneVehicle = vehicle;
            }
            else
            {
                this.LastPassedVehicle = vehicle;
            }

            return NodeWithLowestCost;
        }

        protected bool VehicleAllowed(Vehicle vehicle)
        {
            foreach (VehicleType v in this.AllowedVehicles)
            {
                if (vehicle.VehicleType == v)
                {
                    return true;
                }
            }

             return false;
        }

        public Path GetPathByDestinationNode(Node node)
        {
            foreach (Path p in this.Paths)
            {
                if (p.Destination == node)
                {
                    return p;
                }
            }

            LogHandler.Instance.Write("Destination node was not found in current node.", LogType.Critical);
            return null;
        }
    }
}
