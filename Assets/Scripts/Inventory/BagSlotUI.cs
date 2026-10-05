using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class BagSlotUi : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemCount;
    [SerializeField] private Button deleteButton;
    private ItemEntry entry;
    public event Action OnDeleteItem;
    public event Action<ItemEntry> OnShowDescription;

    public void SetUp(ItemEntry itemEntry)
    {
        itemSprite.sprite = itemEntry.Item.Icon;

        itemCount.text = itemEntry.Count.ToString();
        itemName.text = itemEntry.Item.ItemName;
        
        entry = itemEntry;

        deleteButton.onClick.AddListener(() =>
        {
            DeleteItem(itemEntry);
        });
    }
    
    public void DeleteItem(ItemEntry item)
    {
        Bag.RemoveItem(item);
        OnDeleteItem?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnShowDescription?.Invoke(entry);
    }
}