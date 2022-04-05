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
            MainMenu,
            Fighting,
            Map,
            Drawing,
        }
        public BindableProperty<float> HP_value = new BindableProperty<float>();
        public BindableProperty<float> HP_max = new BindableProperty<float>();
        public BindableProperty<float> MP_value = new BindableProperty<float>();
        public BindableProperty<float> MP_max = new BindableProperty<float>();
        public BindableProperty<State> GameState { get; } = new BindableProperty<State>(State.MainMenu);

        GameObject UIUpsidePanel;
        protected override void OnInit()
        {
            UIUpsidePanel = GameObject.Find("UIUpsidePanel");
            HP_max.Value = Util.MAX_HP;
            HP_value.Value = Util.MAX_HP;
            MP_max.Value = Util.MAX_MP;
            MP_value.Value = Util.MAX_MP;

            HP_value.Register(e =>
            {
                if (HP_value > HP_max)
                {
                    HP_value.Value = HP_max;
                    return;
                }
                RefreshUserHPMP();
            });

            HP_max.Register(e =>
            {
                RefreshUserHPMP();
            });

            MP_value.Register(e =>
            {
                if (MP_value > MP_max)
                {
                    MP_value = MP_max;
                    return;
                }
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
            UIUpsidePanel.transform.Find("HPImage").Find("HPNumText").GetComponent<UITextMeshPro>().text = $"{HP_value.Value.ToString("0.0")}/{HP_max.Value}";
            UIUpsidePanel.transform.Find("MPImage").GetComponent<Image>().fillAmount = MP_value.Value / MP_max.Value;
            UIUpsidePanel.transform.Find("MPImage").Find("MPNumText").GetComponent<UITextMeshPro>().text = $"{MP_value.Value.ToString("0.0")}/{MP_max.Value}";
        }
    }
}