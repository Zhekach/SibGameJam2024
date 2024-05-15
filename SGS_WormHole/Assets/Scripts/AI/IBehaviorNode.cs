namespace AI
{
    public interface IBehaviorNode
    {
        public IBehaviorNode NextNod { get; }
        public void Construct();
        public bool Condition();
        public void Action();
    }
}