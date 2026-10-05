using UnityEngine;

[System.Serializable]
public class DialogueEntry
{
    [SerializeField] [TextArea(2,5)] private string dialogue;
    [SerializeField] private DialogueSpeaker dialogueSpeaker;

    public DialogueSpeaker DialogueSpeaker => dialogueSpeaker;
    public string Text => dialogue;
}

[CreateAssetMenu(fileName = "Dialogue Data", menuName = "Dialogue/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    [SerializeField] private DialogueEntry[] entries;
    [SerializeField] private DialogueChoice[]  choices;
    [SerializeField] private string eventId;
    public DialogueEntry[] Entries => entries;
    public DialogueChoice[] Choices => choices;
    public string EventId => eventId;
}
