using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:ddf49640-4f4c-4588-b332-8865cef7d91a
	public partial class UIHomePanel
	{
		public const string Name = "UIHomePanel";
		
		
		private UIHomePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public UIHomePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIHomePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIHomePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
