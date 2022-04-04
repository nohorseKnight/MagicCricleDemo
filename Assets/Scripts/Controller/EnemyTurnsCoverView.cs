using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UITextMeshPro = TMPro.TMP_Text;

namespace QFramework.Example
{
    public class EnemyTurnsCoverView : BaseController
    {
        public Button button;
        public GameObject Image;
        void Start()
        {
            Image.SetActive(false);
            button.onClick.AddListener(() =>
            {
                Image.SetActive(true);
                ShowValueChangingNumber();
                StartCoroutine("DelayClose");
            });
        }

        IEnumerator DelayClose()
        {
            yield return new WaitForSeconds(2.5f);
            this.GetSystem<UISystem>().CloseUI("UIEnemyTurnCoverPanel");
        }

        void ShowValueChangingNumber()
        {
            EnemyModel enemyModel = this.GetModel<EnemyModel>();
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();

            GameObject numberObj = Object.Instantiate(Resources.Load<GameObject>("UIPrefabs/UIHpNumberPanel"), this.transform);
            numberObj.transform.Find("NumberText").GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 120, 0);
            numberObj.transform.Find("NumberText").GetComponent<RectTransform>().sizeDelta = new Vector2(400, 300);
            numberObj.transform.Find("NumberText").gameObject.GetComponent<UITextMeshPro>().text = $"-{enemyModel.FinalAttackValue}";
            Debug.Log($"enemyDamage : -{enemyModel.FinalAttackValue}");
            gameRuntimeModel.HP_value.Value -= enemyModel.FinalAttackValue;
            numberObj.transform.Find("NumberText").gameObject.GetComponent<UITextMeshPro>().color = new Color(1, 0, 0, 1);
        }
    }
}