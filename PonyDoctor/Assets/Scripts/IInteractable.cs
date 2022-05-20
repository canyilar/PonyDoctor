using System.ComponentModel;

public interface IInteractable 
{
    void Interact();
    bool CanInteract { get; set; }
}
