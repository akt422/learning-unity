// using UnityEngine;
// using UnityEngine.Audio;
// using UnityEngine.Events;
//
// public class BagTriggerListener : MonoBehaviour
// {
//     [SerializeField] private UnityEvent<ItemData> response;
//     private void OnEnable()
//     {
//         Bag.bagActionTriggered += BagHandleEvent;
//     }
//
//     private void OnDisable()
//     {
//         Bag.bagActionTriggered -= BagHandleEvent;
//     }
//
//     public void BagHandleEvent(ItemData item)
//     {
//         // Debug.Log("Bag action trigger reached");
//         response.Invoke(item);
//     }
// }