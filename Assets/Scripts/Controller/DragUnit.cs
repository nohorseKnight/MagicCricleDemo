using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using QFramework;

namespace QFramework.Example
{
    public enum UnitStyle
    {
        NONE,
        CORE_GROUND, CORE_THUNDER, CORE_WATER, CORE_PLANT, CORE_MOUNTAIN, CORE_FIRE, CORE_WIND, CORE_LIGHT,
        LINE_GROUND, LINE_THUNDER, LINE_WATER, LINE_PLANT, LINE_MOUNTAIN, LINE_FIRE, LINE_WIND, LINE_LIGHT,
        NUMBER_1, NUMBER_2, NUMBER_3, NUMBER_4, NUMBER_5, NUMBER_6, NUMBER_7, NUMBER_8, NUMBER_9, NUMBER_10, NUMBER_100, NUMBER_1000,
        STAR_3, STAR_4, STAR_5, STAR_6, STAR_7, STAR_8, STAR_9
    }

    public enum HintImageStyle
    {
        NONE,
        CANNOT_ACT_ON
    }
    public class DragUnit : BaseController, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        [SerializeField] public UnityEngine.UI.Image HintImage;
        [SerializeField] public UnitStyle Style;
        [SerializeField] public CircleNumer ActOnCricleNumber;

        private Vector3 orignalPos;
        private RectTransform canvasRec;
        private Transform orignalParent;
        public GameObject Other;

        private void Awake()
        {

        }

        private void Start()
        {
            canvasRec = this.GetComponentInParent<Canvas>().transform as RectTransform;
            orignalParent = transform.parent;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
            this.transform.SetParent(canvasRec.transform);
            orignalPos = this.transform.position;
            this.GetComponent<BoxCollider2D>().enabled = true;

            ActOnCricleNumber = CircleNumer.NONE;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            this.transform.position = pos;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.transform.position = orignalPos;
            this.transform.SetParent(orignalParent);
            this.GetComponent<BoxCollider2D>().enabled = false;

            if (Style >= UnitStyle.NUMBER_1 && Style <= UnitStyle.NUMBER_1000)
            {
                this.SendCommand(new InputMagicNumberCommand(Style, Other));
            }
            else
            {
                this.SendCommand(new MagicCricleViewUpdateCommand(Style, ActOnCricleNumber));
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            // Debug.Log("DragUnit OnTriggerEnter2D");
        }

        void OnTriggerExit2D(Collider2D other)
        {
            // Debug.Log("DragUnit OnTriggerExit2D");

            this.GetComponent<DragUnit>().HintImage.color = new Color(1, 1, 1, 0);
        }
    }
}