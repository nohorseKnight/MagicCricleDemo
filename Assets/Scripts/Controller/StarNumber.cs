using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example
{
    public class StarNumber : BaseController
    {
        public int Value = 0;
        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("StarNumber OnTriggerEnter2D");
            if (!IsNumber(other)) return;

            other.gameObject.GetComponent<DragUnit>().Other = this.gameObject;

            this.SendCommand(new SpriteHighLightCommand(this.transform.parent.gameObject, 1.0f));
        }

        void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("StarNumber OnTriggerExit2D");
            if (!IsNumber(other)) return;

            this.SendCommand(new SpriteHighLightCommand(this.transform.parent.gameObject, 0.6f));
        }

        bool IsNumber(Collider2D other)
        {
            if (other.tag == "DragUnit" && other.gameObject.GetComponent<DragUnit>().Style >= UnitStyle.NUMBER_1 && other.gameObject.GetComponent<DragUnit>().Style <= UnitStyle.NUMBER_9)
            {
                return true;
            }
            return false;
        }
    }
}