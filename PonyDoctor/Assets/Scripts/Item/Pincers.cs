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

    protected override void InteractWithItem(int itemType)
    {
        if (itemType == 1)
            AnimationManager.Instance.PlayItemAnimation((ItemType)itemType, "TakeOut");
        else if (itemType == 2)
            AnimationManager.Instance.PlayItemAnimation((ItemType)itemType, "NailFall");
    }
}
