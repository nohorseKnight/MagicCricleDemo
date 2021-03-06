using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Example
{
    public class Bag : BaseController
    {
        public Button ExitButton;
        public Transform GridLayoutTranform;

        void Start()
        {
            GameRuntimeModel gameRuntimeModel = this.GetModel<GameRuntimeModel>();

            if (gameRuntimeModel.GameState == GameRuntimeModel.State.Fighting)
            {
                this.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, -340, 0);
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(720, 600);
                ExitButton.gameObject.SetActive(false);
            }
            else
            {
                this.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(650, 600);
                ExitButton.gameObject.SetActive(true);
            }

            ExitButton.onClick.AddListener(() =>
            {
                Debug.Log("Exit Bag");
                this.GetSystem<UISystem>().CloseUI("UIBagPanel");
            });

            BagModel Model = this.GetModel<BagModel>();
            Debug.Log(Model.BagInfo());
            foreach ((Element, Element, Element, Star, Star, int[], int[], float, int, int) unit in Model.BagList)
            {
                this.SendCommand(new AddUnitToBagGridCommand(GridLayoutTranform, unit));
            }
        }
    }
}