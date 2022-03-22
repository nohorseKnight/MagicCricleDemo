using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace QFramework.Example
{
    public class MagicCricleViewUpdateCommand : AbstractCommand
    {
        private UnitStyle _inputUnitStyle;
        private CircleNumer _actOnCricle;
        public MagicCricleViewUpdateCommand(UnitStyle inputUnitStyle, CircleNumer actOnCricle)
        {
            _inputUnitStyle = inputUnitStyle;
            _actOnCricle = actOnCricle;

        }
        protected override void OnExecute()
        {
            Debug.Log("MagicCricleViewUpdateCommand: " + _inputUnitStyle.ToString() + ", " + _actOnCricle.ToString());

            MagicCricleModel Model = this.GetModel<MagicCricleModel>();

            if (_inputUnitStyle >= UnitStyle.LINE_GROUND && _inputUnitStyle <= UnitStyle.LINE_LIGHT)
            {
                Debug.Log("LINE_FIRE ~ LINE_WIND");
                switch (_actOnCricle)
                {
                    case CircleNumer.Cricle_0:
                        Model.FirstCricleElement.Value = MagicCricleModel.Element.GROUND + (_inputUnitStyle - UnitStyle.LINE_GROUND);
                        break;
                    case CircleNumer.Cricle_1:
                        Model.SecondCricleElement.Value = MagicCricleModel.Element.GROUND + (_inputUnitStyle - UnitStyle.LINE_GROUND);
                        break;
                    case CircleNumer.Cricle_2:
                        Model.ThirdCricleElement.Value = MagicCricleModel.Element.GROUND + (_inputUnitStyle - UnitStyle.LINE_GROUND);
                        break;
                    default:
                        break;
                }
            }

            if (_inputUnitStyle >= UnitStyle.CORE_GROUND && _inputUnitStyle <= UnitStyle.CORE_LIGHT && _actOnCricle == CircleNumer.Cricle_0)
            {
                Debug.Log("CORE_GROUND ~ CORE_LIGHT Cricle_0");
                Model.FirstCricleElement.Value = MagicCricleModel.Element.GROUND + (_inputUnitStyle - UnitStyle.CORE_GROUND);
            }

            if (_inputUnitStyle >= UnitStyle.STAR_3 && _inputUnitStyle <= UnitStyle.STAR_9)
            {
                Debug.Log("STAR_3 ~ STAR_9");
                switch (_actOnCricle)
                {
                    case CircleNumer.Cricle_0:
                        // Model.CricleStar_0.Value = MagicCricleModel.Star.STAR_3 + (_inputUnitStyle - UnitStyle.STAR_3);
                        break;
                    case CircleNumer.Cricle_1:
                        Model.CricleStar_1.Value = MagicCricleModel.Star.STAR_3 + (_inputUnitStyle - UnitStyle.STAR_3);
                        break;
                    case CircleNumer.Cricle_2:
                        Model.CricleStar_2.Value = MagicCricleModel.Star.STAR_3 + (_inputUnitStyle - UnitStyle.STAR_3);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}