public class Pincers : Item
{
    public override void Interact()
    {
        base.Interact();
        UIManager.Instance.DisableFingerImage();
    }

    protected override void InteractWithItem(int state)
    {
        if (state == 2)
            AnimationManager.Instance.PlayItemAnimation(state, "TakeOut");
        else if (state == 3)
            AnimationManager.Instance.PlayItemAnimation(state, "NailFall");
    }
}
