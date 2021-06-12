using Gameplay;

namespace Collectables
{
    public class Gem : Collectible
    {
        public int value;
        public override void OnCollect(Collect collector)
        {
            // add exp based on value;
            collector.experience.Add(value);
            base.OnCollect(collector);
        }
        public override int GetNumericValue()
        {
            return value;
        }
    }
}
