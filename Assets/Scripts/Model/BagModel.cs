using System.Collections;
using System;
using QFramework;

namespace QFramework.Example
{
    public class BagModel : AbstractModel
    {
        public ArrayList BagList = new ArrayList();
        protected override void OnInit()
        {
            BagList.Add((MagicCricleModel.Element.FIRE, MagicCricleModel.Element.FIRE, MagicCricleModel.Element.FIRE, MagicCricleModel.Star.STAR_3, MagicCricleModel.Star.STAR_6, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 4, 6 }));
            BagList.Add((MagicCricleModel.Element.WATER, MagicCricleModel.Element.LIGHT, MagicCricleModel.Element.THUNDER, MagicCricleModel.Star.STAR_4, MagicCricleModel.Star.STAR_7, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 4, 6, 7 }));
        }

        public string BagInfo()
        {
            string info = "";
            foreach (var a in BagList)
            {
                info += a.ToString() + "\n";
            }
            return info;
        }
    }
}