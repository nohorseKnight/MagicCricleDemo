using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UITextMeshPro = TMPro.TMP_Text;

namespace QFramework.Example
{
    public class UpsideButton : BaseController
    {
        public Button TipsButton;
        public Button ReturnButton;
        public UITextMeshPro ReturnButtonText;
        void Start()
        {
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();
            MagicCricleModel magicCricleModel = this.GetModel<MagicCricleModel>();

            TipsButton.onClick.AddListener(() =>
            {
                this.GetSystem<UISystem>().OpenUI("UITipsPanel", "Layout_Top");
            });

            ReturnButton.onClick.AddListener(() =>
            {
                switch (gameRuntimeModel.GameState.Value)
                {
                    case GameRuntimeModel.State.Drawing:
                        this.GetSystem<UISystem>().CloseUI("UIMainSelectPanel");
                        GameObject.Destroy(magicCricleModel.MagicCricleObject);
                        this.GetSystem<UISystem>().OpenUI("UIMainMenuPanel");
                        gameRuntimeModel.GameState.Value = GameRuntimeModel.State.MainMenu;
                        break;
                    case GameRuntimeModel.State.Fighting:
                        this.GetSystem<UISystem>().OpenUIInfoPopupPanel("Error", "Can not return when fighting.");
                        break;
                    case GameRuntimeModel.State.MainMenu:
#if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
#else
                        Application.Quit();
#endif
                        break;
                    case GameRuntimeModel.State.Map:
                        this.GetSystem<UISystem>().CloseUI("UIMapPanel");
                        this.GetSystem<UISystem>().OpenUI("UIMainMenuPanel");
                        gameRuntimeModel.GameState.Value = GameRuntimeModel.State.MainMenu;
                        break;
                    default:
                        Debug.Log("ReturnButton.onClick.AddListener switch default");
                        break;
                }
            });
        }

        void Update()
        {
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();
            if (gameRuntimeModel.GameState.Value == GameRuntimeModel.State.MainMenu)
            {
                ReturnButtonText.text = "Exit";
            }
            else
            {
                ReturnButtonText.text = "Return";
            }
        }
    }
}