using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UITextMeshPro = TMPro.TMP_Text;

namespace QFramework.Example
{
    // Generate Id:399ebd5a-417f-440b-b115-5f982665ec04
    public partial class UIElementSelectPanel
    {
        public const string Name = "UIElementSelectPanel";

        [SerializeField]
        public UnityEngine.UI.GridLayoutGroup GridLayoutGroup;
        public UITextMeshPro TextMesh;

        private UIElementSelectPanelData mPrivateData = null;

        protected override void ClearUIComponents()
        {
            GridLayoutGroup = null;
            TextMesh = null;

            mData = null;
        }

        public UIElementSelectPanelData Data
        {
            get
            {
                return mData;
            }
        }

        UIElementSelectPanelData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new UIElementSelectPanelData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
    }
}
