using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	public class UIUpsidePanelData : UIPanelData
	{
	}
	public partial class UIUpsidePanel : UIPanel
	{
		protected override void ProcessMsg(int eventId, QMsg msg)
		{
			throw new System.NotImplementedException();
		}
		
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIUpsidePanelData ?? new UIUpsidePanelData();
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
