using System.Collections;
using QFramework;
using UnityEngine;

namespace QFramework.Example
{
    public class MagicCricleModel : AbstractModel
    {
        public enum Element
        {
            NONE, GROUND, THUNDER, WATER, PLANT, MOUNTAIN, FIRE, WIND, LIGHT
        }

        public enum Star
        {
            NONE, STAR_3, STAR_4, STAR_5, STAR_6, STAR_7, STAR_8, STAR_9
        }
        public GameObject MagicCricleObject;
        public BindableProperty<Element> FirstCricleElement = new BindableProperty<Element>();
        public BindableProperty<Element> SecondCricleElement = new BindableProperty<Element>();
        public BindableProperty<Element> ThirdCricleElement = new BindableProperty<Element>();
        // public BindableProperty<Star> CricleStar_0 = new BindableProperty<Star>();
        public BindableProperty<Star> CricleStar_1 = new BindableProperty<Star>();
        public BindableProperty<Star> CricleStar_2 = new BindableProperty<Star>();
        // public ArrayList CricleStarArray_0 = new ArrayList();
        public ArrayList CricleStarArray_1 = new ArrayList();
        public ArrayList CricleStarArray_2 = new ArrayList();
        public int StarValue_0;
        public int StarValue_1;
        public int StarValue_2;
        protected override void OnInit()
        {
            MagicCricleObject = GameObject.Find("MagicCricle");

            FirstCricleElement.Value = Element.NONE;
            SecondCricleElement.Value = Element.NONE;
            ThirdCricleElement.Value = Element.NONE;
            // CricleStar_0.Value = Star.NONE;
            CricleStar_1.Value = Star.NONE;
            CricleStar_2.Value = Star.NONE;
            StarValue_0 = 1;
            StarValue_1 = 0;
            StarValue_2 = 0;

            FirstCricleElement.Register(FirstCricleElement =>
            {
                Sprite spr;
                if (FirstCricleElement == Element.NONE)
                {
                    Debug.Log("Clear FirstCricleElement");
                    spr = Resources.Load<Sprite>("Image/Ring/Cricle_0_base");
                    MagicCricleObject.transform.Find("Cricle_0").GetComponent<SpriteRenderer>().sprite = spr;
                    MagicCricleObject.transform.Find("Cricle_0").Find("MagicCore").GetComponent<SpriteRenderer>().sprite = null;
                    return;
                }
                Debug.Log($"Image/Ring/Circle_1_00{(FirstCricleElement - Element.GROUND)}");
                spr = Resources.Load<Sprite>($"Image/Ring/Cricle_0_00{(FirstCricleElement - Element.GROUND)}");
                MagicCricleObject.transform.Find("Cricle_0").GetComponent<SpriteRenderer>().sprite = spr;
                spr = Resources.Load<Sprite>($"Image/ElementIcon/element_0{(FirstCricleElement - Element.GROUND)}");
                MagicCricleObject.transform.Find("Cricle_0").Find("MagicCore").GetComponent<SpriteRenderer>().sprite = spr;
            });

            SecondCricleElement.Register(SecondCricleElement =>
            {
                Sprite spr;
                if (SecondCricleElement == Element.NONE)
                {
                    Debug.Log("Clear SecondCricleElement");
                    spr = Resources.Load<Sprite>("Image/Ring/Cricle_1_base");
                    MagicCricleObject.transform.Find("Cricle_1").GetComponent<SpriteRenderer>().sprite = spr;
                    return;
                }
                Debug.Log($"Image/Ring/Circle_1_00{(SecondCricleElement - Element.GROUND)}");
                spr = Resources.Load<Sprite>($"Image/Ring/Cricle_1_00{(SecondCricleElement - Element.GROUND)}");
                MagicCricleObject.transform.Find("Cricle_1").GetComponent<SpriteRenderer>().sprite = spr;
            });

            ThirdCricleElement.Register(ThirdCricleElement =>
            {
                Sprite spr;
                if (ThirdCricleElement == Element.NONE)
                {
                    Debug.Log("Clear ThirdCricleElement");
                    spr = Resources.Load<Sprite>("Image/Ring/Cricle_2_base");
                    MagicCricleObject.transform.Find("Cricle_2").GetComponent<SpriteRenderer>().sprite = spr;
                    return;
                }
                Debug.Log($"Image/Ring/Circle_2_00{(ThirdCricleElement - Element.GROUND)}");
                spr = Resources.Load<Sprite>($"Image/Ring/Cricle_2_00{(ThirdCricleElement - Element.GROUND)}");
                MagicCricleObject.transform.Find("Cricle_2").GetComponent<SpriteRenderer>().sprite = spr;
            });

            /*
            * no need to add star on cricle_0
            CricleStar_0.Register(CricleStar_0 =>
            {
            });
            */

            CricleStar_1.Register(CricleStar_1 =>
            {
                if (CricleStar_1 != Star.NONE && CricleStar_1 != Star.STAR_3 && CricleStar_1 != Star.STAR_4 && CricleStar_1 != Star.STAR_5) return;

                foreach (Transform item in MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"))
                {
                    if (item.tag == "StarNumber") Object.Destroy(item.gameObject);
                }
                CricleStarArray_1.Clear();

                if (CricleStar_1 == Star.NONE)
                {
                    MagicCricleObject.transform.Find("Cricle_1").Find("Star_1").GetComponent<SpriteRenderer>().sprite = null;
                    return;
                }

                // Debug.Log($"Image/Star/star_1_{(CricleStar_1 - Star.STAR_3 + 3)}");
                Sprite spr = Resources.Load<Sprite>($"Image/Star/star_1_{(CricleStar_1 - Star.STAR_3 + 3)}");
                MagicCricleObject.transform.Find("Cricle_1").Find("Star_1").GetComponent<SpriteRenderer>().sprite = spr;

                switch (CricleStar_1)
                {
                    case Star.STAR_3:
                        CricleStarArray_1.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"), new Vector3(0, 1.7f, 0), new Vector3(0, 0, 0)));
                        CricleStarArray_1.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"), new Vector3(1.47f, -0.85f, 0), new Vector3(0, 0, -120)));
                        CricleStarArray_1.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"), new Vector3(-1.47f, -0.85f, 0), new Vector3(0, 0, 120)));
                        break;
                    case Star.STAR_4:
                        CricleStarArray_1.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"), new Vector3(1.21f, 1.21f, 0), new Vector3(0, 0, -45)));
                        CricleStarArray_1.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"), new Vector3(1.21f, -1.21f, 0), new Vector3(0, 0, -135)));
                        CricleStarArray_1.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"), new Vector3(-1.21f, -1.21f, 0), new Vector3(0, 0, 135)));
                        CricleStarArray_1.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"), new Vector3(-1.21f, 1.21f, 0), new Vector3(0, 0, 45)));
                        break;
                    case Star.STAR_5:
                        CricleStarArray_1.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"), new Vector3(0, 1.7f, 0), new Vector3(0, 0, 0)));
                        CricleStarArray_1.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"), new Vector3(1.62f, 0.53f, 0), new Vector3(0, 0, -72)));
                        CricleStarArray_1.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"), new Vector3(1, -1.38f, 0), new Vector3(0, 0, -144)));
                        CricleStarArray_1.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"), new Vector3(-1, -1.38f, 0), new Vector3(0, 0, -216)));
                        CricleStarArray_1.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_1").Find("Star_1"), new Vector3(-1.62f, 0.53f, 0), new Vector3(0, 0, -288)));
                        break;
                    default:
                        Debug.Log("switch (CricleStar_1) default");
                        break;
                }
            });

            CricleStar_2.Register(CricleStar_2 =>
            {
                if (CricleStar_2 != Star.NONE && CricleStar_2 != Star.STAR_6 && CricleStar_2 != Star.STAR_7 && CricleStar_2 != Star.STAR_8 && CricleStar_2 != Star.STAR_9) return;

                foreach (Transform item in MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"))
                {
                    if (item.tag == "StarNumber") Object.Destroy(item.gameObject);
                }
                CricleStarArray_2.Clear();

                if (CricleStar_2 == Star.NONE)
                {
                    MagicCricleObject.transform.Find("Cricle_2").Find("Star_2").GetComponent<SpriteRenderer>().sprite = null;
                    return;
                }

                Sprite spr = Resources.Load<Sprite>($"Image/Star/star_2_{(CricleStar_2 - Star.STAR_3 + 3)}");
                MagicCricleObject.transform.Find("Cricle_2").Find("Star_2").GetComponent<SpriteRenderer>().sprite = spr;

                switch (CricleStar_2)
                {
                    case Star.STAR_6:
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(0, 2.4f, 0), new Vector3(0, 0, 0)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(2.08f, 1.2f, 0), new Vector3(0, 0, -60)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(2.08f, -1.2f, 0), new Vector3(0, 0, -120)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(0, -2.4f, 0), new Vector3(0, 0, -180)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(-2.08f, -1.2f, 0), new Vector3(0, 0, -240)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(-2.08f, 1.2f, 0), new Vector3(0, 0, -300)));
                        break;
                    case Star.STAR_7:
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(0, 2.4f, 0), new Vector3(0, 0, 0)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(1.88f, 1.5f, 0), new Vector3(0, 0, -360f / 7 * 1)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(2.34f, -0.54f, 0), new Vector3(0, 0, -360f / 7 * 2)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(1.04f, -2.16f, 0), new Vector3(0, 0, -360f / 7 * 3)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(-1.04f, -2.16f, 0), new Vector3(0, 0, -360f / 7 * 4)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(-2.34f, -0.54f, 0), new Vector3(0, 0, -360f / 7 * 5)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(-1.88f, 1.5f, 0), new Vector3(0, 0, -360f / 7 * 6)));
                        break;
                    case Star.STAR_8:
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(0, 2.4f, 0), new Vector3(0, 0, 0)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(1.7f, 1.7f, 0), new Vector3(0, 0, -45)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(2.4f, 0, 0), new Vector3(0, 0, -90)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(1.7f, -1.7f, 0), new Vector3(0, 0, -135)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(0, -2.4f, 0), new Vector3(0, 0, -180)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(-1.7f, 1.7f, 0), new Vector3(0, 0, -225)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(-2.4f, 0, 0), new Vector3(0, 0, -270)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(-1.7f, 1.7f, 0), new Vector3(0, 0, -315)));
                        break;
                    case Star.STAR_9:
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(0, 2.4f, 0), new Vector3(0, 0, 0)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(1.54f, 1.84f, 0), new Vector3(0, 0, -360f / 9 * 1)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(2.36f, 0.41f, 0), new Vector3(0, 0, -360f / 9 * 2)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(2.08f, -1.2f, 0), new Vector3(0, 0, -360f / 9 * 3)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(0.82f, -2.25f, 0), new Vector3(0, 0, -360f / 9 * 4)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(-0.82f, -2.25f, 0), new Vector3(0, 0, -360f / 9 * 5)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(-2.08f, -1.2f, 0), new Vector3(0, 0, -360f / 9 * 6)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(-2.36f, 0.41f, 0), new Vector3(0, 0, -360f / 9 * 7)));
                        CricleStarArray_2.Add(CreateStarNumberObject(MagicCricleObject.transform.Find("Cricle_2").Find("Star_2"), new Vector3(-1.54f, 1.84f, 0), new Vector3(0, 0, -360f / 9 * 8)));
                        break;
                    default:
                        Debug.Log("switch (CricleStar_2) default");
                        break;
                }
            });
        }

        GameObject CreateStarNumberObject(Transform parent, Vector3 pos, Vector3 rot)
        {
            GameObject obj = Object.Instantiate(Resources.Load<GameObject>("Prefabs/StarNumber"), parent);
            obj.transform.localPosition = pos;
            obj.transform.localRotation = Quaternion.Euler(rot);
            return obj;
        }

        int[] ObjectArrToIntArr(ArrayList cricleStarArray)
        {
            int[] arr = new int[cricleStarArray.Count];
            GameObject obj;
            int i = 0;
            foreach (var a in cricleStarArray)
            {
                obj = (GameObject)a;
                arr[i++] = obj.GetComponent<StarNumber>().Value;
            }
            return arr;
        }

        int CountStarValueByOrder(ArrayList cricleStarArray)
        {
            return CountStarValueByOrder(ObjectArrToIntArr(cricleStarArray));
        }

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

        int CountStarValueByInterval(ArrayList cricleStarArray)
        {
            return CountStarValueByInterval(ObjectArrToIntArr(cricleStarArray));
        }

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

        public float CountCoreStarValue()
        {
            return StarValue_0;
        }

        public float CountMiddleStarValue()
        {
            return StarValue_1 = CountStarValueByOrder(CricleStarArray_1);
        }

        public float CountOutStarValue()
        {
            return StarValue_2 = CountStarValueByInterval(CricleStarArray_2);
        }

        public bool IsMagicCricleCompleted()
        {
            // Debug.Log("FirstCricleElement.Value:" + FirstCricleElement.Value.ToString() + ",SecondCricleElement.Value:" + SecondCricleElement.Value.ToString() + ",ThirdCricleElement.Value:" + ThirdCricleElement.Value.ToString());
            // Debug.Log("CricleStar_1.Value:" + CricleStar_1.Value.ToString() + ",CricleStar_2.Value:" + CricleStar_2.Value.ToString());

            if (MagicCricleObject == null) return false;
            if (FirstCricleElement.Value == Element.NONE || SecondCricleElement.Value == Element.NONE || ThirdCricleElement.Value == Element.NONE) return false;
            if (CricleStar_1.Value == Star.NONE || CricleStar_2.Value == Star.NONE) return false;

            return true;
        }

        public (Element c0, Element c1, Element c2, Star s1, Star s2, int[] a1, int[] a2) GetMagicCricleData()
        {
            var c0 = FirstCricleElement.Value;
            var c1 = SecondCricleElement.Value;
            var c2 = ThirdCricleElement.Value;
            var s1 = CricleStar_1.Value;
            var s2 = CricleStar_2.Value;
            var a1 = ObjectArrToIntArr(CricleStarArray_1);
            var a2 = ObjectArrToIntArr(CricleStarArray_2);
            return (c0, c1, c2, s1, s2, a1, a2);
        }

        public void ClearMagicCricle()
        {
            FirstCricleElement.Value = Element.NONE;
            SecondCricleElement.Value = Element.NONE;
            ThirdCricleElement.Value = Element.NONE;
            CricleStar_1.Value = Star.NONE;
            CricleStar_2.Value = Star.NONE;
        }

        public float AnalyzeDamage()
        {
            if (FirstCricleElement.Value == Element.NONE)
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

            float a1 = SecondCricleElement.Value == Element.NONE ? 0 : elementTable[(int)FirstCricleElement.Value, (int)SecondCricleElement.Value];
            float a2 = ThirdCricleElement.Value == Element.NONE ? 1 : elementTable[(int)FirstCricleElement.Value, (int)ThirdCricleElement.Value];

            damage = (CountCoreStarValue() + a1 * CountMiddleStarValue()) * a2 * CountOutStarValue();

            Debug.Log($"FirstCricleElement:{FirstCricleElement.Value.ToString()}, SecondCricleElement:{SecondCricleElement.Value.ToString()}, ThirdCricleElement:{ThirdCricleElement.Value.ToString()}");
            Debug.Log($"a1:{a1}, a2:{a2}, damage:{damage}");

            return damage;
        }
    }
}