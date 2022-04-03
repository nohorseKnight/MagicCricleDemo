using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace QFramework.Example
{
    public class GameStart : BaseController
    {
        void Start()
        {
            // this.GetSystem<UISystem>().OpenUI("UIMainMenuPanel");

            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();
            EnemyModel enemyModel = this.GetModel<EnemyModel>();

            gameRuntimeModel.GameState.Value = GameRuntimeModel.State.Fighting;
            this.GetSystem<UISystem>().OpenUI("UIBagPanel");
            enemyModel.EnemyObject.Value = this.GetSystem<UISystem>().OpenUI("Enemy");
        }
    }
}