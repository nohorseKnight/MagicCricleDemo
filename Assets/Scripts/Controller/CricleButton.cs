using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Example
{
    public class CricleButton : BaseController
    {
        public Button ClearCricleButton;
        public Button DoneCricleButton;
        public Button InfoCricleButton;
        public Button BagButton;
        void Start()
        {
            InfoCricleButton.onClick.AddListener(() =>
            {
                MagicCricleModel Model = this.GetModel<MagicCricleModel>();

                string strContent = "Model.StarValue_0: " + Model.StarValue_0 + "\nModel.StarValue_1: " + Model.StarValue_1 + "\nModel.StarValue_2: " + Model.StarValue_2;

                this.GetSystem<UISystem>().OpenUIInfoPopupPanel("Magic Cricle Info", strContent);
            });

            DoneCricleButton.onClick.AddListener(() =>
            {
                MagicCricleModel magicCricleModel = this.GetModel<MagicCricleModel>();
                BagModel bagModel = this.GetModel<BagModel>();

                if (magicCricleModel.IsMagicCricleCompleted())
                {
                    bagModel.BagList.Add(magicCricleModel.GetMagicCricleData());
                    magicCricleModel.ClearMagicCricle();
                    this.GetSystem<UISystem>().OpenUIInfoPopupPanel("Draw Success", "Completed Magic Cricle is put in bag.");
                }
                else
                {
                    this.GetSystem<UISystem>().OpenUIInfoPopupPanel("Error", "Magic Cricle is not Completed.");
                }
            });

            BagButton.onClick.AddListener(() =>
            {
                BagModel Model = this.GetModel<BagModel>();

                this.GetSystem<UISystem>().OpenUIInfoPopupPanel("Bag", Model.BagInfo());
            });
        }
    }
}