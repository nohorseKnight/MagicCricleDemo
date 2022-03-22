using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UITextMeshPro = TMPro.TMP_Text;

namespace QFramework.Example
{
    // Generate Id:87336497-9b81-4f99-8dbf-ad79a916adb7
    public partial class UIInfoPopupPanel
    {
        public const string Name = "UIInfoPopupPanel";

        private UIInfoPopupPanelData mPrivateData = null;

        protected override void ClearUIComponents()
        {
            mData = null;
        }

        public UIInfoPopupPanelData Data
        {
            get
            {
                return mData;
            }
        }

        UIInfoPopupPanelData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new UIInfoPopupPanelData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
    }
}
