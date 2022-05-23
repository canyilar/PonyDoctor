using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pincers : Item
{
    public override void Interact()
    {
        base.Interact();
        UIManager.Instance.DisableFingerImage();
    }

    protected override void InteractWithItem()
    {
        AnimationManager.Instance.PlayItemAnimation(ItemType.Horseshoe, "TakeOut");
    }
}
