using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace QFramework.Example
{
    public class SpriteHighLightCommand : AbstractCommand
    {
        private GameObject _obj;
        private float _alphaValue;
        public SpriteHighLightCommand(GameObject obj, float alphaValue)
        {
            _obj = obj;
            _alphaValue = alphaValue;
        }

        protected override void OnExecute()
        {
            if (_obj.GetComponent<SpriteRenderer>() == null)
            {
                Debug.Log("_obj.GetComponent<SpriteRenderer>() == null");
            }
            Color color = _obj.GetComponent<SpriteRenderer>().color;
            color.a = _alphaValue;
            _obj.GetComponent<SpriteRenderer>().color = color;
        }
    }
}