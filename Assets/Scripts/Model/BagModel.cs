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
            AddIntoList(Element.WATER, Element.LIGHT, Element.THUNDER, Star.STAR_4, Star.STAR_7, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 4, 6, 7 });
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

            float[,] elementTable = new float[9, 9]{
                {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f},
                {0.0f, 1.5f, 1.4f, 1.2f, 1.2f, 1.4f, 1.0f, 1.0f, 0.5f},
                {0.0f, 0.5f, 1.5f, 1.4f, 1.0f, 1.0f, 1.4f, 0.5f, 1.0f},
                {0.0f, 1.2f, 1.0f, 1.5f, 0.5f, 1.0f, 0.5f, 1.4f, 1.0f},
                {0.0f, 1.4f, 0.5f, 1.4f, 1.5f, 0.5f, 0.5f, 0.5f, 1.4f},
                {0.0f, 1.4f, 1.0f, 0.5f, 0.5f, 1.5f, 1.4f, 0.5f, 1.0f},
                {0.0f, 1.0f, 1.4f, 0.5f, 1.4f, 0.5f, 1.5f, 1.4f, 1.2f},
                {0.0f, 1.4f, 0.5f, 1.2f, 0.5f, 0.5f, 1.4f, 1.5f, 1.0f},
                {0.0f, 0.5f, 1.4f, 1.2f, 1.0f, 1.0f, 1.4f, 1.0f, 1.5f}
            };

            float m1 = c1 == Element.NONE ? 0 : elementTable[(int)c0, (int)c1];
            float m2 = c2 == Element.NONE ? 1 : elementTable[(int)c0, (int)c2];

            damage = (1 + m1 * CountStarValueByOrder(arr1)) * m2 * CountStarValueByInterval(arr2);

            Debug.Log($"FirstCricleElement:{c0.ToString()}, SecondCricleElement:{c1.ToString()}, ThirdCricleElement:{c2.ToString()}");
            Debug.Log($"m1:{m1}, m2:{m2}, damage:{damage}");

            return damage;
        }

        //for testing
        int CountStarValueByInterval(int[] arr)
        {
            int result = 0;
            result = arr[arr.Length - 2] + arr[0];
            if (result > arr[arr.Length - 1] + arr[1])
            {
                result = arr[arr.Length - 1] + arr[1];
            }
            for (int i = 0; i < arr.Length - 2; i++)
            {
                if (result > arr[i] + arr[i + 2])
                {
                    result = arr[i] + arr[i + 2];
                }
            }

            return result;
        }

        //for testing
        int CountStarValueByOrder(int[] arr)
        {
            int result = 0;
            result = arr[arr.Length - 1] + arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (result > arr[i] + arr[i + 1])
                {
                    result = arr[i] + arr[i + 1];
                }
            }

            Debug.Log("CountStarValueByOrder result: " + result);

            return result;
        }
    }
}