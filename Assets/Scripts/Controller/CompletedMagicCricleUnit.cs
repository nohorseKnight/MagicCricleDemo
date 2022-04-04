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

                this.GetSystem<UISystem>().OpenUI("UIEnemyTurnCoverPanel", "Layout_Bottom");

                enemyModel.ChangingValue = -cricleUnitdata.Item8;
                enemyModel.AttackedElement.Value = cricleUnitdata.Item1;
                enemyModel.AttackValue.Value = UnityEngine.Random.Range(50f, 100f);

                Debug.Log($"CompletedMagicCricleUnit {enemyModel.AttackedElement.Value.ToString()}");
                if (enemyModel.AttackedElement.Value == Element.PLANT)
                {
                    Debug.Log("CompletedMagicCricleUnit enemyModel.AttackedElement.Value == Element.PLANT");
                    gameRuntimeModel.HP_value.Value += (float)cricleUnitdata.Item8 * Util.PLANT_INCREASE_HP;
                }
                else if (enemyModel.AttackedElement.Value == Element.WATER)
                {
                    Debug.Log("CompletedMagicCricleUnit enemyModel.AttackedElement.Value == Element.WATER");
                    gameRuntimeModel.MP_value.Value += (float)cricleUnitdata.Item8 * Util.WATER_INCREASE_MP;
                }

                enemyModel.AttackedElement.Value = Element.NONE;

                bagModel.BagList.Remove(cricleUnitdata);
                Destroy(gameObject);
            });
        }

    }
}