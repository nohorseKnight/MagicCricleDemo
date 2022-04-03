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
        void Start()
        {
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();
            MagicCricleModel magicCricleModel = this.GetModel<MagicCricleModel>();

            TipsButton.onClick.AddListener(() =>
            {
                switch (gameRuntimeModel.GameState.Value)
                {
                    case GameRuntimeModel.State.Drawing:

                        break;
                    case GameRuntimeModel.State.Fighting:
                        this.GetSystem<UISystem>().OpenUI("UITipsPanel", "Layout_Top");
                        break;
                    case GameRuntimeModel.State.MainMenu:
                        break;
                    case GameRuntimeModel.State.Map:

                        break;
                    default:
                        Debug.Log("TipsButton.onClick.AddListener switch default");
                        break;
                }
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
                        this.GetSystem<UISystem>().CloseUI("UIBagPanel");
                        this.GetSystem<UISystem>().CloseUI("Enemy");
                        this.GetSystem<UISystem>().OpenUI("UIMainMenuPanel");
                        gameRuntimeModel.GameState.Value = GameRuntimeModel.State.MainMenu;
                        break;
                    case GameRuntimeModel.State.MainMenu:
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
    }
}