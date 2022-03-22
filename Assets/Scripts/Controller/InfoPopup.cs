using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UITextMeshPro = TMPro.TMP_Text;

namespace QFramework.Example
{
    public class InfoPopup : BaseController
    {
        public UITextMeshPro Title;
        public UITextMeshPro Content;
        public Button ExitButton;

        void Start()
        {
            ExitButton.onClick.AddListener(() =>
            {
                Debug.Log("Exit Info Popup");
                this.GetSystem<UISystem>().CloseUI(nameof(UIInfoPopupPanel));
            });
        }
    }
}