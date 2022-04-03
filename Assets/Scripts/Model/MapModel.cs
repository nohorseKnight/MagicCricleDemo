using System.Collections;
using System;
using QFramework;
using UnityEngine;

namespace QFramework.Example
{
    public class MapNodeData
    {
        public MapNodeData NextRightNode;
        public MapNodeData NextLeftNode;
        public float[] ElementProbabilityArr;
        public Vector3 Pos;
        public string BGPath;

        public MapNodeData(MapNodeData left, MapNodeData right, float[] probailityArr, Vector3 pos, string path)
        {
            NextRightNode = right;
            NextLeftNode = left;
            ElementProbabilityArr = probailityArr;
            Pos = pos;
            BGPath = path;
        }
    }
    public class MapModel : AbstractModel
    {
        public MapNodeData StartNode;
        public MapNodeData EndNode;
        public BindableProperty<MapNodeData> PlayerNode = new BindableProperty<MapNodeData>();
        protected override void OnInit()
        {
            // NONE, GROUND, THUNDER, WATER, PLANT, MOUNTAIN, FIRE, WIND, LIGHT
            EndNode = new MapNodeData(null, null, new float[9] { 0, 0, 20, 0, 0, 20, 20, 20, 20 }, new Vector3(50, 380, 0), "bg_mountain_1");

            MapNodeData Node30 = new MapNodeData(EndNode, EndNode, new float[9] { 0, 0, 0, 60, 0, 40, 0, 0, 0 }, new Vector3(-350, 220, 0), "bg_mountain_0");
            MapNodeData Node29 = new MapNodeData(EndNode, EndNode, new float[9] { 0, 0, 0, 0, 0, 60, 0, 40, 0 }, new Vector3(-250, 220, 0), "bg_mountain_0");
            MapNodeData Node28 = new MapNodeData(EndNode, EndNode, new float[9] { 0, 30, 0, 30, 30, 0, 0, 10, 0 }, new Vector3(-150, 220, 0), "bg_river_0");
            MapNodeData Node27 = new MapNodeData(EndNode, EndNode, new float[9] { 0, 30, 0, 30, 30, 0, 0, 10, 0 }, new Vector3(-50, 220, 0), "bg_river_0");
            MapNodeData Node26 = new MapNodeData(EndNode, EndNode, new float[9] { 0, 30, 0, 30, 40, 0, 0, 0, 0 }, new Vector3(50, 220, 0), "bg_marsh_0");
            MapNodeData Node25 = new MapNodeData(EndNode, EndNode, new float[9] { 0, 30, 0, 30, 40, 0, 0, 0, 0 }, new Vector3(150, 220, 0), "bg_marsh_0");
            MapNodeData Node24 = new MapNodeData(EndNode, EndNode, new float[9] { 0, 30, 0, 30, 40, 0, 0, 0, 0 }, new Vector3(250, 220, 0), "bg_marsh_0");
            MapNodeData Node23 = new MapNodeData(EndNode, EndNode, new float[9] { 0, 30, 0, 30, 40, 0, 0, 0, 0 }, new Vector3(350, 220, 0), "bg_grass_1");

            MapNodeData Node22 = new MapNodeData(Node30, Node29, new float[9] { 0, 30, 0, 30, 0, 0, 0, 40, 0 }, new Vector3(-350, 60, 0), "bg_ocean_0");
            MapNodeData Node21 = new MapNodeData(Node29, Node28, new float[9] { 0, 30, 0, 40, 10, 0, 0, 20, 0 }, new Vector3(-250, 60, 0), "bg_beach_0");
            MapNodeData Node20 = new MapNodeData(Node28, Node27, new float[9] { 0, 20, 0, 0, 30, 50, 0, 0, 0 }, new Vector3(-150, 60, 0), "bg_mountain_0");
            MapNodeData Node19 = new MapNodeData(Node27, Node26, new float[9] { 0, 20, 0, 0, 30, 50, 0, 0, 0 }, new Vector3(-50, 60, 0), "bg_mountain_0");
            MapNodeData Node18 = new MapNodeData(Node26, Node25, new float[9] { 0, 30, 0, 40, 30, 0, 0, 0, 0 }, new Vector3(50, 60, 0), "bg_marsh_0");
            MapNodeData Node17 = new MapNodeData(Node25, Node24, new float[9] { 0, 30, 0, 40, 30, 0, 0, 0, 0 }, new Vector3(150, 60, 0), "bg_marsh_0");
            MapNodeData Node16 = new MapNodeData(Node24, Node23, new float[9] { 0, 30, 0, 40, 30, 0, 0, 0, 0 }, new Vector3(250, 60, 0), "bg_marsh_0");
            MapNodeData Node15 = new MapNodeData(Node24, Node23, new float[9] { 0, 30, 0, 40, 30, 0, 0, 0, 0 }, new Vector3(350, 60, 0), "bg_grass_1");

            MapNodeData Node14 = new MapNodeData(Node22, Node21, new float[9] { 0, 0, 0, 90, 0, 0, 0, 10, 0 }, new Vector3(-350, -100, 0), "bg_beach_0");
            MapNodeData Node13 = new MapNodeData(Node22, Node21, new float[9] { 0, 30, 0, 40, 0, 0, 0, 30, 0 }, new Vector3(-250, -100, 0), "bg_beach_0");
            MapNodeData Node12 = new MapNodeData(Node21, Node20, new float[9] { 0, 30, 0, 40, 0, 0, 0, 30, 0 }, new Vector3(-150, -100, 0), "bg_beach_0");
            MapNodeData Node11 = new MapNodeData(Node20, Node19, new float[9] { 0, 20, 0, 50, 0, 30, 0, 0, 0 }, new Vector3(-50, -100, 0), "bg_river_0");
            MapNodeData Node10 = new MapNodeData(Node19, Node18, new float[9] { 0, 30, 0, 0, 60, 10, 0, 0, 0 }, new Vector3(50, -100, 0), "bg_forest_0");
            MapNodeData Node09 = new MapNodeData(Node18, Node17, new float[9] { 0, 10, 0, 30, 60, 0, 0, 0, 0 }, new Vector3(150, -100, 0), "bg_river_0");
            MapNodeData Node08 = new MapNodeData(Node17, Node16, new float[9] { 0, 10, 0, 30, 60, 0, 0, 0, 0 }, new Vector3(250, -100, 0), "bg_forest_0");
            MapNodeData Node07 = new MapNodeData(Node16, Node15, new float[9] { 0, 30, 0, 0, 60, 0, 0, 10, 0 }, new Vector3(350, -100, 0), "bg_forest_0");

            MapNodeData Node06 = new MapNodeData(Node14, Node13, new float[9] { 0, 0, 0, 90, 0, 0, 0, 10, 0 }, new Vector3(-290, -260, 0), "bg_beach_0");
            MapNodeData Node05 = new MapNodeData(Node12, Node11, new float[9] { 0, 0, 0, 90, 0, 0, 0, 10, 0 }, new Vector3(-83, -260, 0), "bg_beach_0");
            MapNodeData Node04 = new MapNodeData(Node10, Node09, new float[9] { 0, 10, 0, 30, 60, 0, 0, 0, 0 }, new Vector3(124, -260, 0), "bg_forest_0");
            MapNodeData Node03 = new MapNodeData(Node08, Node07, new float[9] { 0, 10, 0, 30, 60, 0, 0, 0, 0 }, new Vector3(310, -260, 0), "bg_forest_0");

            MapNodeData Node02 = new MapNodeData(Node06, Node05, new float[9] { 0, 0, 0, 90, 0, 0, 0, 10, 0 }, new Vector3(-158, -360, 0), "bg_beach_0");
            MapNodeData Node01 = new MapNodeData(Node04, Node03, new float[9] { 0, 30, 0, 60, 0, 0, 0, 10, 0 }, new Vector3(253, -360, 0), "bg_river_0");

            StartNode = new MapNodeData(Node02, Node01, new float[9] { 0, 25, 0, 25, 25, 0, 0, 25, 0 }, new Vector3(147, -460, 0), "bg_grass_0");


            PlayerNode.Value = StartNode;
            PlayerNode.Register(PlayerNode =>
            {
                //
            });

            PlayerNode.Value = StartNode;
        }

        public Element GetPlayerNodeElement()
        {
            if (PlayerNode.Value == null) return Element.NONE;

            Element result = Element.NONE;

            float probaility = UnityEngine.Random.Range(0.1f, 100f);
            Debug.Log($"probaility = {probaility}");

            int i = 0;
            foreach (float value in PlayerNode.Value.ElementProbabilityArr)
            {
                probaility -= value;
                if (probaility <= 0) break;
                i++;
            }

            result += i;
            Debug.Log($"result: {result.ToString()}");
            return result;
        }
    }
}