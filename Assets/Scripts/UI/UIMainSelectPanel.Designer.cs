using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
    // Generate Id:1fc1de33-4dac-4adb-b380-da151804885e
    public partial class UIMainSelectPanel
    {
        public const string Name = "UIMainSelectPanel";

        [SerializeField]
        public UnityEngine.UI.GridLayoutGroup GridLayoutGroup;

        private UIMainSelectPanelData mPrivateData = null;

        protected override void ClearUIComponents()
        {
            GridLayoutGroup = null;

            mData = null;
        }

        public UIMainSelectPanelData Data
        {
            get
            {
                return mData;
            }
        }

        UIMainSelectPanelData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new UIMainSelectPanelData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
    }
}
