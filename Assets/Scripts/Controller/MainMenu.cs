using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UITextMeshPro = TMPro.TMP_Text;

namespace QFramework.Example
{
    public class MainMenu : BaseController
    {
        public Button TurnLeftButton;
        public Button TurnRightButton;
        public Button DrawMagicCricleButton;
        public Button BagButton;
        public Button MapButton;
        void Start()
        {
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();
            MapModel mapModel = this.GetModel<MapModel>();

            TurnLeftButton.onClick.AddListener(() =>
            {
                mapModel.PlayerNode.Value = mapModel.PlayerNode.Value.NextLeftNode;
                EnterFightingState();
            });

            TurnRightButton.onClick.AddListener(() =>
            {
                mapModel.PlayerNode.Value = mapModel.PlayerNode.Value.NextRightNode;
                EnterFightingState();
            });

            DrawMagicCricleButton.onClick.AddListener(() =>
            {
                this.GetSystem<UISystem>().CloseUI("UIMainMenuPanel");

                MagicCricleModel mode = this.GetModel<MagicCricleModel>();
                gameRuntimeModel.GameState.Value = GameRuntimeModel.State.Drawing;
                mode.MagicCricleObject = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/MagicCricle"));
                this.GetSystem<UISystem>().OpenUI("UIMainSelectPanel");
            });

            BagButton.onClick.AddListener(() =>
            {
                this.GetSystem<UISystem>().OpenUI("UIBagPanel");
            });

            MapButton.onClick.AddListener(() =>
            {
                this.GetSystem<UISystem>().CloseUI("UIMainMenuPanel");
                this.GetSystem<UISystem>().OpenUI("UIMapPanel");
                gameRuntimeModel.GameState.Value = GameRuntimeModel.State.Map;
            });
        }

        void EnterFightingState()
        {
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();
            EnemyModel enemyModel = this.GetModel<EnemyModel>();

            gameRuntimeModel.GameState.Value = GameRuntimeModel.State.Fighting;
            this.GetSystem<UISystem>().CloseUI("UIMainMenuPanel");
            this.GetSystem<UISystem>().OpenUI("UIBagPanel");
            enemyModel.EnemyObject.Value = this.GetSystem<UISystem>().OpenUI("Enemy");
        }

    }
}