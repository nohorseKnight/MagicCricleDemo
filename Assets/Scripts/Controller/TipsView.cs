using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Example
{
    public class TipsView : BaseController
    {
        public Button ExitButton;

        void Start()
        {
            ExitButton.onClick.AddListener(() =>
            {
                this.GetSystem<UISystem>().CloseUI("UITipsPanel");
            });
        }
    }
}