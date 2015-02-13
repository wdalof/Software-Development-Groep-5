﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Simulator
{
    public class Nodes
    {
        //StartingNodes
        public Node EntryNode1 = new EntryNode(new Position(1200, 0), "s1");
        public Node EntryNode2 = new EntryNode(new Position(1225, 0), "s2");
        public Node EntryNode3 = new EntryNode(new Position(1915, 300), "s3");
        public Node EntryNode4 = new EntryNode(new Position(1915, 325), "s4");
        public Node EntryNode5 = new EntryNode(new Position(450, 1055), "s5");
        public Node EntryNode6 = new EntryNode(new Position(425, 1055), "s6");
        public Node EntryNode7 = new EntryNode(new Position(0, 425), "s7");

        public Node EntryNode8 = new EntryNode(new Position(500, 1055), "s8");

        //Intersection Nodes
        public Node NodeA1 = new Node(new Position(350, 375), "A1");
        public Node NodeA2 = new Node(new Position(325, 350), "A2");
        public Node NodeB1 = new Node(new Position(375, 325), "B1");
        public Node NodeB2 = new Node(new Position(400, 300), "B2");
        public Node NodeC1 = new Node(new Position(350, 450), "C1");
        public Node NodeC2 = new Node(new Position(325, 475), "C2");
        public Node NodeD1 = new Node(new Position(425, 400), "D1");
        public Node NodeD2 = new Node(new Position(450, 425), "D2");
        public Node NodeE1 = new Node(new Position(1200, 325), "E1");
        public Node NodeE2 = new Node(new Position(1175, 300), "E2");
        public Node NodeF1 = new Node(new Position(1275, 275), "F1");
        public Node NodeF2 = new Node(new Position(1300, 250), "F2");
        public Node NodeH1 = new Node(new Position(1275, 350), "H1");
        public Node NodeH2 = new Node(new Position(1300, 375), "H2");
        public Node NodeI = new Node(new Position(550, 425), "I");
        public Node NodeJ = new Node(new Position(620, 425), "J");
        public Node NodeK = new Node(new Position(1475, 425), "K");
        public Node NodeG1 = new Node(new Position(1250, 400), "G1");
        public Node NodeG2 = new Node(new Position(1225, 425), "G2");

        //ExitNodes
        public Node ExitNode1 = new ExitNode(new Position(1275, 0), Direction.Noord, "e1");
        public Node ExitNode2 = new ExitNode(new Position(1300, 0), Direction.Noord, "e2");
        public Node ExitNode3 = new ExitNode(new Position(1915, 400), Direction.Oost, "e3");
        public Node ExitNode4 = new ExitNode(new Position(1915, 425), Direction.Oost, "e4");
        public Node ExitNode5 = new ExitNode(new Position(350, 1055), Direction.Zuid, "e5");
        public Node ExitNode6 = new ExitNode(new Position(325, 1055), Direction.Zuid, "e6");
        public Node ExitNode7 = new ExitNode(new Position(0, 325), Direction.West, "e7");
        public Node ExitNode8 = new ExitNode(new Position(0, 300), Direction.West, "e8");

        //CustomNodes
        public Node Custom1 = new Node(new Position(1200, 100), "1");
        public Node Custom2 = new Node(new Position(1175, 150), "2");
        public Node Custom3 = new Node(new Position(1225, 100), "3");

        public Node Custom20 = new Node(new Position(1700, 300), "20");
        public Node Custom21 = new Node(new Position(1650, 275), "21");
        public Node Custom22 = new Node(new Position(1600, 250), "22");

        public Node Custom30 = new Node(new Position(920, 325), "30");
        public Node Custom31 = new Node(new Position(870, 350), "31");
        public Node Custom32 = new Node(new Position(820, 375), "32");

        public Node Custom10 = new Node(new Position(1200, 318), "10");

        public Node Custom40 = new Node(new Position(870, 400), "40");
        public Node Custom41 = new Node(new Position(920, 375), "41");
        public Node Custom42 = new Node(new Position(970, 350), "42");

        public Node Custom50 = new Node(new Position(50, 425), "50");
        public Node Custom51 = new Node(new Position(100, 450), "51");
        public Node Custom52 = new Node(new Position(150, 475), "52");
        public Node Custom53 = new Node(new Position(100, 400), "53");

        public Node Custom60 = new Node(new Position(425, 950), "60");
        public Node Custom61 = new Node(new Position(400, 900), "61");
        public Node Custom62 = new Node(new Position(375, 850), "62");
        public Node Custom63 = new Node(new Position(450, 950), "63");

        public Node Custom70 = new Node(new Position(500, 500), "70");
        public Node Custom71 = new Node(new Position(690, 475), "71");
        public Node Custom72 = new Node(new Position(1425, 475), "72");

        //BusNodes
        public Node Bus1 = new BusNode(new Position(1250, 150), "b1");
        public Node Bus2 = new BusNode(new Position(475, 900), "b2");
        public Node Bus3 = new BusNode(new Position(475, 525), "b3");
        

        public Nodes()
        {
            
        }
    }
}