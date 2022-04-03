using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UITextMeshPro = TMPro.TMP_Text;

namespace QFramework.Example
{
    public class CompletedMagicCricleUnit : BaseController
    {
        public Button DetailButton;
        public Button UseButton;
        public UITextMeshPro DamageText;
        public (Element, Element, Element, Star, Star, int[], int[], float) cricleUnitdata;
        void Start()
        {
            BagModel bagModel = this.GetModel<BagModel>();
            EnemyModel enemyModel = this.GetModel<EnemyModel>();
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();

            DetailButton.onClick.AddListener(() =>
            {
                this.SendCommand(new ShowMagicCricleDetailCommand(cricleUnitdata));
            });

            UseButton.onClick.AddListener(() =>
            {
                if (gameRuntimeModel.GameState != GameRuntimeModel.State.Fighting) return;
                enemyModel.ChangingValue = -cricleUnitdata.Item8;
                enemyModel.AttackedElement.Value = cricleUnitdata.Item1;
                // enemyModel.EnemyHP_value.Value -= cricleUnitdata.Item8;

                bagModel.BagList.Remove(cricleUnitdata);
                Destroy(gameObject);
            });
        }

    }
}