using DG.Tweening;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [Tooltip("Animation name that should be played.")]
    [SerializeField] private string animationName;

    /// <summary>
    /// Determines if we can interact with this.
    /// </summary>
    public bool CanInteract { get; set; }

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();

        CanInteract = true;
    }

    void OnMouseDown()
    {
        if (CanInteract)
            Interact();
    }

    public void Interact()
    {
        anim.Play(animationName);
        CanInteract = false;
    }

    // Animation Event
    /// <summary>
    /// Does an action when animation completed.
    /// </summary>
    public void OnAnimationCompleted()
    {
        GameManager.Instance.IncrementActionIndex();
        Camera.main.transform.DOMoveX(Camera.main.transform.position.x + 6, 1);
    }
}
