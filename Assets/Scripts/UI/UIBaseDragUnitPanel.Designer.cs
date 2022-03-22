using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
    // Generate Id:c8e62cca-afa9-4ab6-ab49-5e4860b9f8c5
    public partial class UIBaseDragUnitPanel
    {
        public const string Name = "UIBaseDragUnitPanel";

        private UIBaseDragUnitPanelData mPrivateData = null;

        protected override void ClearUIComponents()
        {
            mData = null;
        }

        public UIBaseDragUnitPanelData Data
        {
            get
            {
                return mData;
            }
        }

        UIBaseDragUnitPanelData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new UIBaseDragUnitPanelData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
    }
}
