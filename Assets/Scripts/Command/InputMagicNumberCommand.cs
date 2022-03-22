using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace QFramework.Example
{
    public class InputMagicNumberCommand : AbstractCommand
    {
        private UnitStyle _unitStyle;
        private GameObject _other;
        public InputMagicNumberCommand(UnitStyle unitStyle, GameObject other)
        {
            _unitStyle = unitStyle;
            _other = other;
        }
        protected override void OnExecute()
        {
            MagicCricleModel Model = this.GetModel<MagicCricleModel>();

            Debug.Log("InputMagicNumberCommand");
            if (_other == null || _other.tag != "StarNumber")
            {
                Debug.Log("_other == null || _other.tag != StarNumber");
                return;
            }
            Sprite[] spr = Resources.LoadAll<Sprite>($"Image/Number/Number_white_0");
            Debug.Log(spr.ToString());
            _other.GetComponent<SpriteRenderer>().sprite = spr[_unitStyle - UnitStyle.NUMBER_1];
            _other.GetComponent<StarNumber>().Value = _unitStyle - UnitStyle.NUMBER_1 + 1;

            if (_other.transform.parent.name == "Star_1")
            {
                Model.CountMiddleStarValue();
            }
            else if (_other.transform.parent.name == "Star_2")
            {
                Model.CountOutStarValue();
            }
            else
            {
                Debug.Log(_other.transform.parent.name + " _other.transform.parent.ToString() != Star_1 or Star_2");
            }
        }
    }
}