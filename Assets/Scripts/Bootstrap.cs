using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string startingScene = "TestOutside";

    void Start()
    {
        SceneManager.LoadScene(startingScene);
    }
}
