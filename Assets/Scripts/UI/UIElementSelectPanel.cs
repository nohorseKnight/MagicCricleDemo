using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
    public class UIElementSelectPanelData : UIPanelData
    {
        public ArrayList GridLayoutList;
    }
    public partial class UIElementSelectPanel : UIPanel
    {
        protected override void ProcessMsg(int eventId, QMsg msg)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as UIElementSelectPanelData ?? new UIElementSelectPanelData();
            // please add init code here
        }

        protected override void OnOpen(IUIData uiData = null)
        {
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }

        protected override void OnClose()
        {
        }
    }
}
