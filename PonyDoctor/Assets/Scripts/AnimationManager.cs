using UnityEngine;
using DG.Tweening;

public class AnimationManager : MonoBehaviour
{
    private static AnimationManager instance;
    public static AnimationManager Instance => instance;

    void Awake()
    {
        instance = this;    
    }

    public void StopAnimation(Animator anim)
    {
        anim.speed = 0;
    }

    public void ResumeAnimation(Animator anim)
    {
        anim.speed = 1;
    }
}
