using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticLoadScene : MonoBehaviour
{
    public static StaticLoadScene Instance { get; private set; }

    private bool isLoading;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    public void LoadScene(string sceneName)
    {
        if (isLoading)
            return;

        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    
    public IEnumerator LoadSceneCoroutine(string sceneName)
    {
        isLoading = true;

        AsyncOperation operation =
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!operation.isDone)
        {
            yield return null;
        }

        isLoading = false;
    }
    
}