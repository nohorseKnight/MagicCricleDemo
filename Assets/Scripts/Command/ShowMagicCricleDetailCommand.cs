using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
    public class ShowMagicCricleDetailCommand : AbstractCommand
    {
        private Element _c0;
        private Element _c1;
        private Element _c2;
        private Star _s1;
        private Star _s2;
        private int[] _a1;
        private int[] _a2;
        private float _damage;
        public ShowMagicCricleDetailCommand((Element, Element, Element, Star, Star, int[], int[], float) data)
        {
            _c0 = data.Item1;
            _c1 = data.Item2;
            _c2 = data.Item3;
            _s1 = data.Item4;
            _s2 = data.Item5;
            _a1 = data.Item6;
            _a2 = data.Item7;
            _damage = data.Item8;
        }
        protected override void OnExecute()
        {
            GameObject obj = this.GetSystem<UISystem>().OpenUI("UIMagicCricleDetailPanel");

            SetSprite(obj.transform.Find("Cricle_2").GetComponent<Image>(), (int)_c2, $"Image/Ring/Cricle_2_00{_c2 - Element.GROUND}");
            SetSprite(obj.transform.Find("Cricle_1").GetComponent<Image>(), (int)_c1, $"Image/Ring/Cricle_1_00{_c1 - Element.GROUND}");
            SetSprite(obj.transform.Find("Cricle_0").GetComponent<Image>(), (int)_c0, $"Image/Ring/Cricle_0_00{_c0 - Element.GROUND}");
            SetSprite(obj.transform.Find("Cricle_1").Find("Star_1").GetComponent<Image>(), (int)_s1, $"Image/Star/star_1_{_s1 - Star.STAR_3 + 3}");
            SetSprite(obj.transform.Find("Cricle_2").Find("Star_2").GetComponent<Image>(), (int)_s2, $"Image/Star/star_2_{_s2 - Star.STAR_3 + 3}");
            SetSprite(obj.transform.Find("Cricle_0").Find("MagicCore").GetComponent<Image>(), (int)_c0, $"Image/ElementIcon/element_0{_c0 - Element.GROUND}");

            SetStarNumber(obj.transform.Find("Cricle_1").Find("Star_1"), _s1, _a1);
            SetStarNumber(obj.transform.Find("Cricle_2").Find("Star_2"), _s2, _a2);

            obj.GetComponent<ShowingMagicCricleDetail>().InfoText.text = $"Damage = (1 + {Util.elementTable[(int)_c0, (int)_c1]} * {1.0f + 0.1f * _a1.Length} * {Util.CountStarValueByOrder(_a1)}) * {Util.elementTable[(int)_c0, (int)_c2]} * {1.0f + 0.1f * _a2.Length} * {Util.CountStarValueByInterval(_a2)} = {_damage}";
        }

        void SetSprite(Image image, int flag, string path)
        {
            if (flag == 0)
            {
                Debug.Log("flag == null");
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                return;
            }
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            image.sprite = Resources.Load<Sprite>($"{path}");
        }

        void SetStarNumber(Transform trans, Star star, int[] arr)
        {
            if (arr.Length != (star - Star.STAR_3 + 3))
            {
                Debug.Log("arr.Length != (star - Star.STAR_3 + 3)");
                return;
            }
            int count = arr.Length;
            switch (star)
            {
                case Star.STAR_3:
                    CreateNumberImage(trans, new Vector3(0, 184f, 0), new Vector3(0, 0, 0), arr[0]);
                    CreateNumberImage(trans, new Vector3(156.4f, -92f, 0), new Vector3(0, 0, -120), arr[1]);
                    CreateNumberImage(trans, new Vector3(-156.4f, -92f, 0), new Vector3(0, 0, 120), arr[2]);
                    break;
                case Star.STAR_4:
                    CreateNumberImage(trans, new Vector3(130f, 130f, 0), new Vector3(0, 0, -45), arr[0]);
                    CreateNumberImage(trans, new Vector3(130f, -130f, 0), new Vector3(0, 0, -135), arr[1]);
                    CreateNumberImage(trans, new Vector3(-130f, -130f, 0), new Vector3(0, 0, 135), arr[2]);
                    CreateNumberImage(trans, new Vector3(-130f, 130f, 0), new Vector3(0, 0, 45), arr[3]);
                    break;
                case Star.STAR_5:
                    CreateNumberImage(trans, new Vector3(0, 184f, 0), new Vector3(0, 0, 0), arr[0]);
                    CreateNumberImage(trans, new Vector3(175f, 57f, 0), new Vector3(0, 0, -72), arr[1]);
                    CreateNumberImage(trans, new Vector3(108, -150f, 0), new Vector3(0, 0, -144), arr[2]);
                    CreateNumberImage(trans, new Vector3(-108, -150f, 0), new Vector3(0, 0, -216), arr[3]);
                    CreateNumberImage(trans, new Vector3(-175f, 57f, 0), new Vector3(0, 0, -288), arr[4]);
                    break;
                case Star.STAR_6:
                    CreateNumberImage(trans, new Vector3(0, 260f, 0), new Vector3(0, 0, 0), arr[0]);
                    CreateNumberImage(trans, new Vector3(225f, 130f, 0), new Vector3(0, 0, -60), arr[1]);
                    CreateNumberImage(trans, new Vector3(225f, -130f, 0), new Vector3(0, 0, -120), arr[2]);
                    CreateNumberImage(trans, new Vector3(0, -260f, 0), new Vector3(0, 0, -180), arr[3]);
                    CreateNumberImage(trans, new Vector3(-225f, -130f, 0), new Vector3(0, 0, -240), arr[4]);
                    CreateNumberImage(trans, new Vector3(-225f, 130f, 0), new Vector3(0, 0, -300), arr[5]);
                    break;
                case Star.STAR_7:
                    CreateNumberImage(trans, new Vector3(0, 260f, 0), new Vector3(0, 0, 0), arr[0]);
                    CreateNumberImage(trans, new Vector3(203f, 162f, 0), new Vector3(0, 0, -360f / 7 * 1), arr[1]);
                    CreateNumberImage(trans, new Vector3(253f, -57f, 0), new Vector3(0, 0, -360f / 7 * 2), arr[2]);
                    CreateNumberImage(trans, new Vector3(113f, -234f, 0), new Vector3(0, 0, -360f / 7 * 3), arr[3]);
                    CreateNumberImage(trans, new Vector3(-113f, -234f, 0), new Vector3(0, 0, -360f / 7 * 4), arr[4]);
                    CreateNumberImage(trans, new Vector3(-253f, -57f, 0), new Vector3(0, 0, -360f / 7 * 5), arr[5]);
                    CreateNumberImage(trans, new Vector3(-203f, 162f, 0), new Vector3(0, 0, -360f / 7 * 6), arr[6]);
                    break;
                case Star.STAR_8:
                    CreateNumberImage(trans, new Vector3(0, 260f, 0), new Vector3(0, 0, 0), arr[0]);
                    CreateNumberImage(trans, new Vector3(185f, 185f, 0), new Vector3(0, 0, -45), arr[1]);
                    CreateNumberImage(trans, new Vector3(260f, 0, 0), new Vector3(0, 0, -90), arr[2]);
                    CreateNumberImage(trans, new Vector3(185f, -185f, 0), new Vector3(0, 0, -135), arr[3]);
                    CreateNumberImage(trans, new Vector3(0, -260f, 0), new Vector3(0, 0, -180), arr[4]);
                    CreateNumberImage(trans, new Vector3(-185f, 185f, 0), new Vector3(0, 0, -225), arr[5]);
                    CreateNumberImage(trans, new Vector3(-260f, 0, 0), new Vector3(0, 0, -270), arr[6]);
                    CreateNumberImage(trans, new Vector3(-185f, 185f, 0), new Vector3(0, 0, -315), arr[7]);
                    break;
                case Star.STAR_9:
                    CreateNumberImage(trans, new Vector3(0, 260f, 0), new Vector3(0, 0, 0), arr[0]);
                    CreateNumberImage(trans, new Vector3(167f, 200f, 0), new Vector3(0, 0, -360f / 9 * 1), arr[1]);
                    CreateNumberImage(trans, new Vector3(256f, 46f, 0), new Vector3(0, 0, -360f / 9 * 2), arr[2]);
                    CreateNumberImage(trans, new Vector3(224f, -130f, 0), new Vector3(0, 0, -360f / 9 * 3), arr[3]);
                    CreateNumberImage(trans, new Vector3(89f, -244f, 0), new Vector3(0, 0, -360f / 9 * 4), arr[4]);
                    CreateNumberImage(trans, new Vector3(89f, -244f, 0), new Vector3(0, 0, -360f / 9 * 5), arr[5]);
                    CreateNumberImage(trans, new Vector3(-224f, -130f, 0), new Vector3(0, 0, -360f / 9 * 6), arr[6]);
                    CreateNumberImage(trans, new Vector3(-256f, 46f, 0), new Vector3(0, 0, -360f / 9 * 7), arr[7]);
                    CreateNumberImage(trans, new Vector3(-167f, 200f, 0), new Vector3(0, 0, -360f / 9 * 8), arr[8]);
                    break;
                default:
                    Debug.Log("switch (CricleStar_1) default");
                    break;
            }
        }

        void CreateNumberImage(Transform parent, Vector3 pos, Vector3 rot, int num)
        {
            Sprite[] spr = Resources.LoadAll<Sprite>("Image/Number/Number_white_hollowed-out");
            GameObject obj = Object.Instantiate(Resources.Load<GameObject>("UIPrefabs/UINumberPanel"), parent);
            obj.transform.localPosition = pos;
            obj.transform.localRotation = Quaternion.Euler(rot);
            obj.transform.Find("NumberImage").GetComponent<Image>().sprite = spr[num];
            Debug.Log("obj.transform.Find(NumberImage).GetComponent<Image>().sprite:" + obj.transform.Find("NumberImage").GetComponent<Image>().sprite.ToString());
        }
    }
}