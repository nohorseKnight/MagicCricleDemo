using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
    public class UIInfoPopupPanelData : UIPanelData
    {
    }
    public partial class UIInfoPopupPanel : UIPanel
    {
        protected override void ProcessMsg(int eventId, QMsg msg)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as UIInfoPopupPanelData ?? new UIInfoPopupPanelData();
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
