using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UITextMeshPro = TMPro.TMP_Text;

namespace QFramework.Example
{
    public class ShowingMagicCricleDetail : BaseController
    {
        public Button ExitButton;
        public Transform Cricle_2;
        public Transform Cricle_1;
        public Transform Cricle_0;
        public Transform Star_2;
        public Transform Star_1;
        public Transform MagicCore;
        public UITextMeshPro InfoText;

        void Start()
        {
            ExitButton.onClick.AddListener(() =>
            {
                this.GetSystem<UISystem>().CloseUI("UIMagicCricleDetailPanel");
            });
        }
    }
}