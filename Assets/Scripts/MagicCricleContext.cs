using QFramework;

namespace QFramework.Example
{
    public class MagicCricleContext : Architecture<MagicCricleContext>
    {
        protected override void Init()
        {
            RegisterSystem(new UISystem());
            RegisterModel(new MagicCricleModel());
            RegisterModel(new BagModel());
            RegisterModel(new GameRuntimeModel());
        }
    }
}