using Dialogue;
using UnityEngine;

public class DoorInteract2 : MonoBehaviour, IInteractable
{
    private bool isLocked = true;
    private bool isOpened = false;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DialogueData dialogueData;
    [SerializeField] private DialogueData unlockDoorData;
    [SerializeField] private string[] dialogueText;
    [SerializeField] private Sprite openDoor;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    [SerializeField] private AudioClip lockedDoorClip;
    [SerializeField] private AudioClip openDoorClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ItemData keyToUnlock;
    private string interactText = "E - Try to open";

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }
    public bool CanInteract()
    {
        return !isOpened;
    }

    public void Interact()
    {
        if (isLocked)
        {
            if (isKeyPresent(keyToUnlock))
            {
                isLocked = false;
                audioSource.PlayOneShot(openDoorClip);
                dialogueManager.StartDialogue(unlockDoorData);
                sr.sprite = openDoor;
                bc.isTrigger = true;
                isOpened = true;
            }
            else
            {
                audioSource.PlayOneShot(lockedDoorClip);
                dialogueManager.StartDialogue(dialogueData);
            }
        }
        else
        {
            isOpened = true;
        }
    }

    private bool isKeyPresent(ItemData key)
    {
        return Bag.HasItem(key);
    }

    public string InteractText()
    {
        return interactText;
    }

    public void SetLock(bool val)
    {
        isLocked = val;
    }

    public void Unlock()
    {
        isLocked = false;
    }

    public bool GetLock()
    {
        return isLocked;
    }
}
