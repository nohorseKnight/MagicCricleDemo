using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example
{
    public class MapView : BaseController
    {
        public Transform PlayerNodeTrans;
        void Start()
        {
            MapModel mapModel = this.GetModel<MapModel>();

            PlayerNodeTrans.localPosition = new UnityEngine.Vector3(mapModel.PlayerNode.Value.Pos.x, mapModel.PlayerNode.Value.Pos.y + 30, 0);
        }
    }
}