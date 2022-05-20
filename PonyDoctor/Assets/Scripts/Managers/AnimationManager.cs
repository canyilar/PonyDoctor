using UnityEngine;
using DG.Tweening;

public class AnimationManager : MonoBehaviour
{
    #region Singleton

    private static AnimationManager instance;
    public static AnimationManager Instance => instance;

    #endregion

    void Awake()
    {
        instance = this;    
    }

    public void PauseAnimation(Animator anim)
    {
        anim.speed = 0;
    }

    public void ResumeAnimation(Animator anim)
    {
        anim.speed = 1;
    }
}
