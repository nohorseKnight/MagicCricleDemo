using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
    public class AddUnitToBagGridCommand : AbstractCommand
    {
        private Transform _gridTrans;
        private (Element, Element, Element, Star, Star, int[], int[], float, int, int) _unit;
        public AddUnitToBagGridCommand(Transform gridTrans, (Element, Element, Element, Star, Star, int[], int[], float, int, int) unit)
        {
            _gridTrans = gridTrans;
            _unit = unit;
        }
        protected override void OnExecute()
        {
            GameObject obj = Object.Instantiate(Resources.Load<GameObject>($"UIPrefabs/UICompletedMagicCricleUnitPanel"), _gridTrans);
            AddElementImage(obj.transform, "CoreImage", _unit.Item1);
            AddElementImage(obj.transform, "MiddleImage", _unit.Item2);
            AddElementImage(obj.transform, "OutImage", _unit.Item3);
            obj.GetComponent<CompletedMagicCricleUnit>().cricleUnitdata = _unit;
            obj.GetComponent<CompletedMagicCricleUnit>().DamageText.text = $"Damage: {_unit.Item8}";
        }

        void AddElementImage(Transform parent, string name, Element c)
        {
            parent.Find(name).GetComponent<Image>().sprite = c == Element.NONE ? null : Resources.Load<Sprite>($"Image/ElementIcon/element_0{c - Element.GROUND}");
        }
    }
}