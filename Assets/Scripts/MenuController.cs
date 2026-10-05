using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MenuController : MonoBehaviour
{
    [SerializeField] private List<GameObject> menuItems;
    private int currActive = 0;

    void Start()
    {
        menuItems[currActive]?.SetActive(true);
    }
    
    public void SwitchTab(int index)
    {
        menuItems[currActive]?.SetActive(false);
        menuItems[index]?.SetActive(true);
        currActive = index;
    }
}
