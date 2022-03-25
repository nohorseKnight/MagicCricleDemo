using System.Net.Mime;
using System;
using QFramework;
using UnityEngine;
using UnityEngine.UI;
using UITextMeshPro = TMPro.TMP_Text;

namespace QFramework.Example
{
    public class GameRuntimeModel : AbstractModel
    {
        public enum State
        {
            Main,
            Fighting,
            Map,
            Draw,
        }
        public BindableProperty<float> HP_value = new BindableProperty<float>();
        public BindableProperty<float> HP_max = new BindableProperty<float>();
        public BindableProperty<float> MP_value = new BindableProperty<float>();
        public BindableProperty<float> MP_max = new BindableProperty<float>();

        GameObject UIUpsidePanel;
        protected override void OnInit()
        {
            UIUpsidePanel = GameObject.Find("UIUpsidePanel");
            HP_max.Value = 100f;
            HP_value.Value = 100f;
            MP_max.Value = 100f;
            MP_value.Value = 100f;

            HP_value.Register(e =>
            {
                RefreshUserHPMP();
            });

            HP_max.Register(e =>
            {
                RefreshUserHPMP();
            });

            MP_value.Register(e =>
            {
                RefreshUserHPMP();
            });

            MP_max.Register(e =>
            {
                RefreshUserHPMP();
            });
        }

        void RefreshUserHPMP()
        {
            // Debug.Log("RefreshUserMP");
            UIUpsidePanel.transform.Find("HPImage").GetComponent<Image>().fillAmount = HP_value.Value / HP_max.Value;
            UIUpsidePanel.transform.Find("HPImage").Find("HPNumText").GetComponent<UITextMeshPro>().text = $"{HP_value.Value}/{HP_max.Value}";
            UIUpsidePanel.transform.Find("MPImage").GetComponent<Image>().fillAmount = MP_value.Value / MP_max.Value;
            UIUpsidePanel.transform.Find("MPImage").Find("MPNumText").GetComponent<UITextMeshPro>().text = $"{MP_value.Value}/{MP_max.Value}";
        }
    }
}