using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    private ItemEntry itemEntry;
    private TMP_Text descriptionText;
    private string defaultDesc = "Select item to view details";
    // [SerializeField] private Button useButton;
    // [SerializeField] private Button throwButton;
    private List<ItemAction> actionList;
    [SerializeField] private Button actionPrefab;
    [SerializeField] private GameObject buttonDisplayArea;
    public event Action OnDeleteItem;

    void Awake()
    {
        descriptionText = GetComponent<TMP_Text>();
        descriptionText.text = defaultDesc;
    }

    public void ShowItemDetails(ItemEntry entry)
    {
        itemEntry = entry;
        actionList = entry.Item.Actions;
        descriptionText.text = itemEntry.Item.Description;
        ClearActionButtons();
        foreach (ItemAction action in entry.Item.Actions)
        {
            CreateActionButton(action, entry);
        }
    }
    
    private void ClearActionButtons()
    {
        foreach (Transform child in buttonDisplayArea.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void CreateActionButton(ItemAction action, ItemEntry entry)
    {
        Button button = Instantiate(actionPrefab, buttonDisplayArea.transform);
        button.GetComponent<Image>().color = action.ButtonConfig.ButtonColor;
        button.GetComponentInChildren<TMP_Text>().text = action.ButtonConfig.ButtonText;
        button.onClick.AddListener( () =>
        {
            action.Execute(entry);
        });
    }

    public void RefreshPanel()
    {
        descriptionText.text = defaultDesc;
    }

    public void UseItem()
    {
        if (itemEntry == null)
            return;
        //itemEntry.Item.Action.Execute(itemEntry);
        // if (itemEntry.Item.ItemType == ItemType.Medicine)
        // {
        //     Debug.Log("Item used!");
        //     Bag.RemoveItem(itemEntry);
        //     OnDeleteItem?.Invoke();
        // }

        if (itemEntry == null)
            RefreshPanel();
    }
    
    public void ThrowItem()
    {
        if (itemEntry == null)
            return;

        if (itemEntry.Item.ItemType is ItemType.Medicine or ItemType.Weapon)
        {
            Debug.Log("Item thrown!");
            Bag.RemoveEntry(itemEntry);
        }
        RefreshPanel();
    }
}