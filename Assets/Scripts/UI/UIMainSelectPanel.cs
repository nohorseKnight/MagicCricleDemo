using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
    public class UIMainSelectPanelData : UIPanelData
    {
    }
    public partial class UIMainSelectPanel : UIPanel
    {
        protected override void ProcessMsg(int eventId, QMsg msg)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as UIMainSelectPanelData ?? new UIMainSelectPanelData();
            // please add init code here
        }

        protected override void OnOpen(IUIData uiData = null)
        {

        }

        protected override void OnShow()
        {
            // Object.Instantiate(Resources.Load("UIPrefab/UIElementSelectPanel") as GameObject, GridLayoutGroup.transform);
        }

        protected override void OnHide()
        {
        }

        protected override void OnClose()
        {
        }
    }
}
