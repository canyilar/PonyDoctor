using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    #region Singleton

    private static AnimationManager instance;
    public static AnimationManager Instance => instance;

    #endregion

    [SerializeField] private Animator firstStatehorseShoeAnim;
    [SerializeField] private Animator fifthStatehorseShoeAnim;
    [SerializeField] private Animator pincersAnim;
    [SerializeField] private Animator nailAnim;

    void Awake()
    {
        instance = this;    
    }

    public void PlayItemAnimation(int state, string animationName)
    {
        switch (state)   
        {
            case 1:
                pincersAnim.Play(animationName);
                break;
            case 2:
                firstStatehorseShoeAnim.Play(animationName);
                break;
            case 3:
                nailAnim.Play(animationName);
                break;
            case 5:
                fifthStatehorseShoeAnim.Play(animationName);
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
