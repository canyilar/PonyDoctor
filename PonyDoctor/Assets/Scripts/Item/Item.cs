using UnityEngine;

public class Item : MonoBehaviour, IInteractable, IAnimated
{
    [Tooltip("Animation name that should be played.")]
    [SerializeField] private string animationName;

    /// <summary>
    /// Determines if we can interact with this.
    /// </summary>
    public bool CanInteract { get; set; }

    private Animator anim;
    private GameManager gameManager;

    void Awake()
    {
        anim = GetComponent<Animator>();

        CanInteract = true;
    }

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void OnMouseDown()
    {
        if (CanInteract && gameManager.actionAvaible)
        {
            Interact();
        }
    }

    public virtual void Interact()
    {
        anim.Play(animationName);
        CanInteract = false;
    }

    #region Animation Events

    /// <summary>
    /// Does an action when animation completed.
    /// </summary>
    public virtual void OnAnimationCompleted()
    {
        gameManager.IncrementActionIndex();
        gameManager.SlideCamera(2);
    }

    protected virtual void InteractWithItem()
    {
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    #endregion

}
