using UnityEngine;

// todo: it could get costly maintaining assets, would rather have this Serializable and populate in inspector for each DialogueData
[CreateAssetMenu(fileName = "Dialogue Choice", menuName = "Dialogue/Dialogue Choice")]
public class DialogueChoice : ScriptableObject
{
    [SerializeField] private string choice;
    [SerializeField] private DialogueData nextDialogue;
    
    public DialogueData NextDialogue => nextDialogue;
    public string Choice => choice;
}