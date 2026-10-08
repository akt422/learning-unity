using UnityEngine;

public class SaveLoadUI : MonoBehaviour
{
    public void SaveGame()
    {
        SaveManager.Instance.SaveGame();
    }

    public void LoadGame()
    {
        SaveManager.Instance.LoadGame();
    }
}