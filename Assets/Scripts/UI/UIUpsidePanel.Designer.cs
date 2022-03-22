using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UITextMeshPro = TMPro.TMP_Text;

namespace QFramework.Example
{
    // Generate Id:9dd12398-6b9c-4c8d-bb26-d3c3576ca1e3
    public partial class UIUpsidePanel
    {
        public const string Name = "UIUpsidePanel";

        [SerializeField]
        public Image HPImage;
        public UITextMeshPro HPNumText;
        public Image MPImage;
        public UITextMeshPro MPNumText;
        public Button TipsButton;
        public Button ExitButton;

        private UIUpsidePanelData mPrivateData = null;

        protected override void ClearUIComponents()
        {

            mData = null;
        }

        public UIUpsidePanelData Data
        {
            get
            {
                return mData;
            }
        }

        UIUpsidePanelData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new UIUpsidePanelData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
    }
}
