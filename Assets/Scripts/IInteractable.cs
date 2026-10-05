using UnityEngine;

public interface IInteractable
{
    bool CanInteract();
    void Interact();
    string InteractText();
}