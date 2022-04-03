using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UITextMeshPro = TMPro.TMP_Text;

namespace QFramework.Example
{
    public class EnemyView : BaseController
    {
        public GameObject BGImage;
        public GameObject ViewImage;
        public GameObject HpImage;
        public UITextMeshPro HpText;
        public GameObject DefeatPopup;
        public Button ForwardButton;

        void Start()
        {
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();
            EnemyModel enemyModel = this.GetModel<EnemyModel>();
            MapModel mapModel = this.GetModel<MapModel>();

            BGImage.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Image/Background/{mapModel.PlayerNode.Value.BGPath}");
            enemyModel.EnemyElement.Value = mapModel.GetPlayerNodeElement();
            enemyModel.EnemyHP_value.Value = 100f;
            HpText.text = $"{enemyModel.EnemyHP_value.Value}";
            DefeatPopup.SetActive(false);
            ForwardButton.onClick.AddListener(() =>
            {
                gameRuntimeModel.GameState.Value = GameRuntimeModel.State.MainMenu;
                this.GetSystem<UISystem>().CloseUI("UIBagPanel");
                this.GetSystem<UISystem>().CloseUI("Enemy");
                this.GetSystem<UISystem>().OpenUI("UIMainMenuPanel");
            });
        }
    }
}