using UnityEngine;

public class Key : ItemInteract
{
    private string interactText = "E - Pick up key";
    public override string InteractText()
    {
        return interactText;
    }
}