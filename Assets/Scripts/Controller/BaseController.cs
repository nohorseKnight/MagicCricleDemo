using QFramework;
using UnityEngine;

namespace QFramework.Example
{
    public class BaseController : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return MagicCricleContext.Interface;
        }
    }
}