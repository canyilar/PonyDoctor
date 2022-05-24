public class Hammer : Item
{
    protected override void InteractWithItem(int state)
    {
        AnimationManager.Instance.PlayItemAnimation(state, "HorseshoePut");
    }

    public override void OnAnimationCompleted()
    {
    }
}
