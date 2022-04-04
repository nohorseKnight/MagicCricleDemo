using System.Collections;
using System;
using QFramework;
using UnityEngine;

namespace QFramework.Example
{
    public class BagModel : AbstractModel
    {
        public ArrayList BagList = new ArrayList();
        protected override void OnInit()
        {
            AddIntoList(Element.FIRE, Element.FIRE, Element.FIRE, Star.STAR_3, Star.STAR_6, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 4, 6 });
            AddIntoList(Element.THUNDER, Element.LIGHT, Element.THUNDER, Star.STAR_4, Star.STAR_7, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 4, 6, 7 });
            AddIntoList(Element.PLANT, Element.LIGHT, Element.THUNDER, Star.STAR_4, Star.STAR_7, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 4, 6, 7 });

            AddIntoList(Element.LIGHT, Element.LIGHT, Element.THUNDER, Star.STAR_4, Star.STAR_7, new int[] { 4, 4, 4, 4 }, new int[] { 3, 3, 3, 3, 3, 3, 3 });
            AddIntoList(Element.WIND, Element.LIGHT, Element.THUNDER, Star.STAR_4, Star.STAR_7, new int[] { 4, 4, 4, 4 }, new int[] { 3, 3, 3, 3, 3, 3, 3 });
            AddIntoList(Element.FIRE, Element.LIGHT, Element.THUNDER, Star.STAR_4, Star.STAR_7, new int[] { 4, 4, 4, 4 }, new int[] { 3, 3, 3, 3, 3, 3, 3 });
            AddIntoList(Element.MOUNTAIN, Element.LIGHT, Element.THUNDER, Star.STAR_4, Star.STAR_7, new int[] { 4, 4, 4, 4 }, new int[] { 3, 3, 3, 3, 3, 3, 3 });
            AddIntoList(Element.PLANT, Element.LIGHT, Element.THUNDER, Star.STAR_4, Star.STAR_7, new int[] { 4, 4, 4, 4 }, new int[] { 3, 3, 3, 3, 3, 3, 3 });
            AddIntoList(Element.WATER, Element.LIGHT, Element.THUNDER, Star.STAR_4, Star.STAR_7, new int[] { 4, 4, 4, 4 }, new int[] { 3, 3, 3, 3, 3, 3, 3 });
            AddIntoList(Element.THUNDER, Element.LIGHT, Element.THUNDER, Star.STAR_4, Star.STAR_7, new int[] { 4, 4, 4, 4 }, new int[] { 3, 3, 3, 3, 3, 3, 3 });
            AddIntoList(Element.GROUND, Element.LIGHT, Element.THUNDER, Star.STAR_4, Star.STAR_7, new int[] { 4, 4, 4, 4 }, new int[] { 3, 3, 3, 3, 3, 3, 3 });
        }

        public string BagInfo()
        {
            string info = "";
            foreach (var a in BagList)
            {
                info += a.ToString() + "\n";
            }
            return info;
        }

        //for testing
        void AddIntoList(Element c0, Element c1, Element c2, Star s1, Star s2, int[] a1, int[] a2)
        {
            float damage = GetDamageValue(c0, c1, c2, a1, a2);
            BagList.Add((c0, c1, c2, s1, s2, a1, a2, damage));
        }

        //for testing
        float GetDamageValue(Element c0, Element c1, Element c2, int[] arr1, int[] arr2)
        {
            if (c0 == Element.NONE)
            {
                Debug.Log("FirstCricleElement.Value == Element.NONE");
                return 0;
            }

            float damage = 0;

            float m1 = c1 == Element.NONE ? 0 : Util.elementTable[(int)c0, (int)c1];
            float m2 = c2 == Element.NONE ? 1 : Util.elementTable[(int)c0, (int)c2];

            damage = (1 + m1 * (1 + 0.1f * arr1.Length) * Util.CountStarValueByOrder(arr1)) * m2 * (1 + 0.1f * arr2.Length) * Util.CountStarValueByInterval(arr2);

            Debug.Log($"FirstCricleElement:{c0.ToString()}, SecondCricleElement:{c1.ToString()}, ThirdCricleElement:{c2.ToString()}");
            Debug.Log($"m1:{m1}, m2:{m2}, damage:{damage}");

            return damage;
        }
    }
}