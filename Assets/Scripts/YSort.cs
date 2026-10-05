using UnityEngine;

public class YSort : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform sortingPoint;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (sortingPoint == null)
        {
            sortingPoint = transform;
        }
    }
    void LateUpdate()
    {
        spriteRenderer.sortingOrder =
            Mathf.RoundToInt(-sortingPoint.position.y * 100);
    }
}
