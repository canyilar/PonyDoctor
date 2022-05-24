using UnityEngine;
using DG.Tweening;

public class AnimationManager : MonoBehaviour
{
    #region Singleton

    private static AnimationManager instance;
    public static AnimationManager Instance => instance;

    #endregion

    [SerializeField] private Animator horseShoeAnim;
    [SerializeField] private Animator pincersAnim;
    [SerializeField] private Animator nailAnim;

    void Awake()
    {
        instance = this;    
    }

    public void PlayItemAnimation(ItemType itemType, string animationName)
    {
        switch (itemType)   
        {
            case ItemType.Pincers:
                pincersAnim.Play(animationName);
                break;
            case ItemType.Horseshoe:
                horseShoeAnim.Play(animationName);
                break;
            case ItemType.Nail:
                nailAnim.Play(animationName);
                break;
        }
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
