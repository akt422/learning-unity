using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private ItemDatabase itemDB;
    private SaveData pendingLoadData;
    public static SaveManager Instance { get; private set; }

    void Awake()
    {
        // if (Instance != null && Instance != this) // This is for any obj that has DontDestroyOnLoad(gameObject), since we want only 1 copy across all scenes.
        // {
        //     Destroy(this.gameObject);
        //     return;
        // }
        //
        // Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SaveGame()
    {
        Vector2 position = player.transform.position;
        SaveData data = new SaveData();
        
        data.playerX = position.x;
        data.playerY = position.y;

        List<ItemEntry> entries = Bag.Items;

        foreach (ItemEntry entry in entries)
        {
            SavedItemEntry savedItemEntry = new SavedItemEntry();
            savedItemEntry.itemId = entry.Item.ItemId;
            savedItemEntry.count = entry.Count;
            data.items.Add(savedItemEntry);
        }

        string currScene = SceneManager.GetActiveScene().name;
        data.sceneName = currScene;

        string json = JsonUtility.ToJson(data, true);
        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);

        Debug.Log("Game saved to: " + path);
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        GameStateManager.SetState(GameState.Gameplay);

        string path = Path.Combine(
            Application.persistentDataPath,
            "savefile.json"
        );

        if (!File.Exists(path))
        {
            Debug.Log("No save file found");
            return;
        }
        string json = File.ReadAllText(path);

        pendingLoadData = JsonUtility.FromJson<SaveData>(json);
        
        SceneManager.LoadScene(pendingLoadData.sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindWithTag("Player");
        if (pendingLoadData == null) // this is because OnSceneLoaded will be triggered on every SceneManager.sceneLoaded. That would be bad when we aren't really loading.
            return;
        
        Bag.Clear();
        foreach (SavedItemEntry item in pendingLoadData.items)
        {
            ItemData loadItem = itemDB.GetItemByItemId(item.itemId);
            if (loadItem != null)
            {
                Bag.AddItem(loadItem, item.count);
            }
        }

        player.transform.position = new Vector3(
            pendingLoadData.playerX,
            pendingLoadData.playerY,
            player.transform.position.z //0
        );
        Debug.Log("Game loaded");
        pendingLoadData = null;
    }
    
}