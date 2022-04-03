using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example
{
    public enum CircleNumer
    {
        NONE,
        Cricle_0,
        Cricle_1,
        Cricle_2
    }
    public class Cricle : BaseController
    {
        [SerializeField] public CircleNumer CurrentCircleNumer;

        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Cricle OnTriggerEnter2D");
            if (IsNeededTriggerIgnore(other)) return;

            if (other.tag == "DragUnit")
            {
                DragUnitTriggerEnter(other);
                this.SendCommand(new SpriteHighLightCommand(this.gameObject, 1.0f));
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("Cricle OnTriggerExit2D");
            if (IsNeededTriggerIgnore(other)) return;

            if (other.tag == "DragUnit")
            {
                this.SendCommand(new SpriteHighLightCommand(this.gameObject, 0.6f));
            }
        }

        void DragUnitTriggerEnter(Collider2D other)
        {
            // other.gameObject.GetComponent<DragUnit>().ActOnCricleNumber = CurrentCircleNumer;
            if (other.gameObject.GetComponent<DragUnit>().Style >= UnitStyle.CORE_GROUND && other.gameObject.GetComponent<DragUnit>().Style <= UnitStyle.CORE_LIGHT)
            {
                if (CurrentCircleNumer == CircleNumer.Cricle_0)
                {
                    other.gameObject.GetComponent<DragUnit>().ActOnCricleNumber = CurrentCircleNumer;
                }
                else
                {
                    other.gameObject.GetComponent<DragUnit>().HintImage.color = new Color(1, 1, 1, 1);
                }
            }

            if (other.gameObject.GetComponent<DragUnit>().Style >= UnitStyle.LINE_GROUND && other.gameObject.GetComponent<DragUnit>().Style <= UnitStyle.LINE_LIGHT)
            {
                other.gameObject.GetComponent<DragUnit>().ActOnCricleNumber = CurrentCircleNumer;
            }

            if (other.gameObject.GetComponent<DragUnit>().Style >= UnitStyle.STAR_3 && other.gameObject.GetComponent<DragUnit>().Style <= UnitStyle.STAR_9)
            {
                other.gameObject.GetComponent<DragUnit>().ActOnCricleNumber = CurrentCircleNumer;
            }
        }

        bool IsNeededTriggerIgnore(Collider2D other)
        {
            if (other.tag == "DragUnit")
            {
                if (other.gameObject.GetComponent<DragUnit>().Style >= UnitStyle.NUMBER_1 && other.gameObject.GetComponent<DragUnit>().Style <= UnitStyle.NUMBER_9)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

