using Dialogue;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTriggerListener : MonoBehaviour
{
    [SerializeField] private UnityEvent response;
    [SerializeField] private string eventId;
    
    // Will be OnEnable whenever the object this class is attached to is present and enabled in the scene.
    private void OnEnable()
    {
        DialogueManager.Instance.dialogueActionTriggered += HandleDialogueEvent;
    }

    // If object this class is attached to is disabled(via checkbox in inspector, say) then OnDisable is true.
    private void OnDisable()
    {
        DialogueManager.Instance.dialogueActionTriggered -= HandleDialogueEvent;
    }
    
    private void HandleDialogueEvent(string triggeredEventId)
    {
        Debug.Log("Event will fire since OnEnable is true");
        if (triggeredEventId == eventId)
        {
            response.Invoke();
        }
    }

}