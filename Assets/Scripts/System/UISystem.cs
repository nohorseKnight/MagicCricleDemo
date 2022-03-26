using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace QFramework.Example
{
    public class UISystem : AbstractSystem
    {
        private Transform canvasTrans;
        private Dictionary<string, GameObject> openedWindow = new Dictionary<string, GameObject>();
        protected override void OnInit()
        {
            canvasTrans = Object.FindObjectOfType<Canvas>().transform;
        }

        public GameObject OpenUI(string name, string layoutName = "Layout_Middle")
        {
            if (openedWindow.ContainsKey(name)) return null;
            var go = Object.Instantiate(Resources.Load<GameObject>($"UIPrefabs/{name}"), canvasTrans.Find(layoutName));
            openedWindow[name] = go;

            return (GameObject)go;
        }

        public void OpenUIInfoPopupPanel(string strTitle, string strContent)
        {
            if (openedWindow.ContainsKey(nameof(UIInfoPopupPanel))) return;
            var go = Object.Instantiate(Resources.Load<GameObject>($"UIPrefabs/{nameof(UIInfoPopupPanel)}"), canvasTrans);
            openedWindow[nameof(UIInfoPopupPanel)] = go;

            go.GetComponent<InfoPopup>().Title.text = strTitle;
            go.GetComponent<InfoPopup>().Content.text = strContent;
        }

        public void CloseUI(string name)
        {
            if (!openedWindow.TryGetValue(name, out var window)) return;
            Object.Destroy(window);
            openedWindow.Remove(name);
        }

    }
}