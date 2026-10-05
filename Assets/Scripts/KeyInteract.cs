using Dialogue;
using UnityEngine;

public class KeyInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DialogueData dialogueData;
    [SerializeField] private string[] dialogueText;
    private GameObject keyObject;
    [SerializeField] private DoorInteract2 door;
    private bool collected = false;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip keyPickClip;
    private string interactText = "E - Pick up";

    public bool CanInteract()
    {
        return !collected;
    }

    public void Interact()
    {
        if (collected)
            return;
        
        audioManager.PlaySound(keyPickClip);
        collected = true;
        dialogueManager.StartDialogue(dialogueData);
        gameObject.SetActive(false);
        door.Unlock();
    }

    public string InteractText()
    {
        return interactText;
    }
}
