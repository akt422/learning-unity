using Dialogue;
using UnityEngine;

public class NpcInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DialogueData dialogueData;
    [SerializeField] private DialogueData notEnoughCostDialogue;
    [SerializeField] private ItemData priceItem;
    [SerializeField] private string eventId;
    private string interactText = "E - Talk";
    
    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        if (StoryStateManager.HasFlag(eventId))
        {
            dialogueManager.StartDialogue(dialogueData);
            return;
        }
        if (Bag.RemoveItems(priceItem, 1))
        {
            Debug.Log("Meat taken");
            StoryStateManager.SetFlag(eventId);
            dialogueManager.StartDialogue(dialogueData);
        }
        else
        {
            dialogueManager.StartDialogue(notEnoughCostDialogue);
            Debug.Log("Not enough meat.");
        }
    }
    
    public string InteractText()
    {
        return interactText;
    }
}
