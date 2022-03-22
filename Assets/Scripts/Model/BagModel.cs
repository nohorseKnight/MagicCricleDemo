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