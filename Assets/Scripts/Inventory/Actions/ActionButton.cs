using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item Action", menuName = "Item Action/Action button")]
public class ActionButton : ScriptableObject
{
    [SerializeField] private string buttonText;
    [SerializeField] private Color buttonColor;
    [SerializeField] private Image buttonSprite;
    
    public string ButtonText => buttonText;
    public Color ButtonColor => buttonColor;
    public Image ButtonSprite => buttonSprite;
}