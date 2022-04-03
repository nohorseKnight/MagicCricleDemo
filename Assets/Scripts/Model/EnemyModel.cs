using QFramework;
using UnityEngine;
using UnityEngine.UI;
using UITextMeshPro = TMPro.TMP_Text;

namespace QFramework.Example
{
    public class EnemyModel : AbstractModel
    {
        public BindableProperty<GameObject> EnemyObject = new BindableProperty<GameObject>();
        public BindableProperty<float> EnemyHP_value = new BindableProperty<float>();
        public BindableProperty<float> EnemyHP_max = new BindableProperty<float>();
        public BindableProperty<Element> EnemyElement = new BindableProperty<Element>();
        public float ChangingValue;
        public BindableProperty<Element> AttackedElement = new BindableProperty<Element>();
        protected override void OnInit()
        {
            EnemyHP_value.Value = 100f;
            EnemyHP_max.Value = 100f;
            ChangingValue = 0;
            EnemyElement.Value = Element.NONE;
            AttackedElement.Value = Element.NONE;

            EnemyHP_max.Register(e =>
            {
                UpdateEnmeyHpView();
            });

            EnemyHP_value.Register(e =>
            {
                UpdateEnmeyHpView();
                EnemyObject.Value.GetComponent<EnemyView>().DefeatPopup.SetActive(EnemyHP_value == 0 ? true : false);
            });

            EnemyElement.Register(e =>
            {
                int imageIndex = UnityEngine.Random.Range(0, 5);
                string path = "";
                switch (EnemyElement.Value)
                {
                    case Element.FIRE:
                        path = $"Image/PokmonEnemy/Fire/fire_monster_{imageIndex}";
                        break;
                    case Element.GROUND:
                        path = $"Image/PokmonEnemy/Ground/ground_monster_{imageIndex}";
                        break;
                    case Element.LIGHT:
                        path = $"Image/PokmonEnemy/Light/light_monster_{imageIndex}";
                        break;
                    case Element.MOUNTAIN:
                        path = $"Image/PokmonEnemy/Mountain/mountain_monster_{imageIndex}";
                        break;
                    case Element.PLANT:
                        path = $"Image/PokmonEnemy/Plant/plant_monster_{imageIndex}";
                        break;
                    case Element.THUNDER:
                        path = $"Image/PokmonEnemy/Thunder/thunder_monster_{imageIndex}";
                        break;
                    case Element.WATER:
                        path = $"Image/PokmonEnemy/Water/water_monster_{imageIndex}";
                        break;
                    case Element.WIND:
                        path = $"Image/PokmonEnemy/Wind/wind_monster_{imageIndex}";
                        break;
                    default:
                        break;
                }
                Debug.Log($"path: {path}");
                EnemyObject.Value.GetComponent<EnemyView>().ViewImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
            });

            AttackedElement.Register(e =>
            {
                ShowValueChangingNumber();
                ClearValue();
            });
        }

        void UpdateEnmeyHpView()
        {
            if (EnemyObject == null)
            {
                Debug.Log("EnemyObject == null");
                return;
            }

            if (EnemyHP_value.Value < 0)
            {
                EnemyHP_value.Value = 0;
            }

            EnemyObject.Value.GetComponent<EnemyView>().HpImage.GetComponent<Image>().fillAmount = EnemyHP_value.Value / EnemyHP_max.Value;
            EnemyObject.Value.GetComponent<EnemyView>().HpText.text = $"{EnemyHP_value.Value}";
        }

        void ShowValueChangingNumber()
        {
            Debug.Log($"ChangingValue : {ChangingValue}");
            if (ChangingValue == 0) return;

            float f = Util.elementTable[(int)EnemyElement.Value, (int)AttackedElement.Value];

            GameObject obj = Object.Instantiate(Resources.Load<GameObject>("UIPrefabs/UIHpNumberPanel"), EnemyObject.Value.transform.Find("Hp"));
            obj.transform.Find("NumberText").gameObject.GetComponent<UITextMeshPro>().text = $"{ChangingValue} * {f}";
            obj.transform.Find("NumberText").gameObject.GetComponent<UITextMeshPro>().color = new Color(1, 1, 1, 1);
            EnemyHP_value.Value += ChangingValue * f;
        }

        void ClearValue()
        {
            ChangingValue = 0;
            AttackedElement.Value = Element.NONE;
        }
    }
}