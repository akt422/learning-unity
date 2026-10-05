using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BagController : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private ItemDescription itemDescription;
    
    private void OnEnable()
    {
        Bag.OnBagChanged += RefreshBag;
        RefreshBag();
    }

    private void OnDisable()
    {
        Bag.OnBagChanged -= RefreshBag;
    }
    
    public void RefreshBag()
    {
        ClearBag();
        foreach (ItemEntry item in Bag.Items)
        {
            CreateItem(item);
        }
    }
    
    public void CreateItem(ItemEntry item)
    {
        GameObject obj = Instantiate(itemPrefab, transform);
        BagSlotUi slot = obj.GetComponent<BagSlotUi>();
        slot.SetUp(item);
        slot.OnDeleteItem += RefreshBag;
        slot.OnShowDescription += ShowItemDetails;
        itemDescription.OnDeleteItem += RefreshBag;
    }
    
    private void ClearBag()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void ShowItemDetails(ItemEntry entry)
    {
        itemDescription.ShowItemDetails(entry);
    }
}