using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
    public class HpNumber : BaseController
    {
        void Start()
        {
            StartCoroutine("WaitAndDestory");
        }

        void Update()
        {
            Vector3 pos = this.GetComponent<RectTransform>().anchoredPosition;
            pos += new Vector3(0, 0.1f, 0);
            this.GetComponent<RectTransform>().anchoredPosition = pos;
        }

        IEnumerator WaitAndDestory()
        {
            yield return new WaitForSeconds(1.0f);
            Object.Destroy(this.gameObject);
        }
    }
}