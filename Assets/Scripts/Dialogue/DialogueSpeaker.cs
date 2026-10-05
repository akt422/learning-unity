using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue Speaker", menuName = "Dialogue/Dialogue Speaker")]
public class DialogueSpeaker : ScriptableObject
{
    [SerializeField] private string speakerName;
    [SerializeField] private Sprite speakerSprite;
    
    public string SpeakerName => speakerName;   
    public Sprite SpeakerSprite => speakerSprite;
}