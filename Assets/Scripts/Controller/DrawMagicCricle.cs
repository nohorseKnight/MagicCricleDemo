using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace QFramework.Example
{
    public class DrawMagicCricle : BaseController
    {
        // Start is called before the first frame update
        void Start()
        {
            this.GetSystem<UISystem>().OpenUI(nameof(UIMainSelectPanel));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
