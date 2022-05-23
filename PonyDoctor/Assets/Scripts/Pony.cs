using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pony : MonoBehaviour, IAnimated
{
    public void OnAnimationCompleted()
    {
        GameManager.Instance.actionAvaible = true;
    }
}
