using UnityEngine;

public class Weapon : ItemInteract
{
    private string interactText = "E - Pick up weapon";
    public override string InteractText()
    {
        return interactText;
    }
}