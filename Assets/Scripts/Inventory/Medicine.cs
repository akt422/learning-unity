using UnityEngine;

public class Medicine : ItemInteract
{
    private string interactText = "E - Procure item";
    public override string InteractText()
    {
        return interactText;
    }
}