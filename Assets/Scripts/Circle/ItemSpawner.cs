
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] protected int count;
    [SerializeField] protected float radius;

    [SerializeField] private ItemsForSpawn _items;

    private CircleGO _circle;

    private Vector2 _center;

    private void Start()
    {
        _circle = FindObjectOfType<CircleGO>();
        SpawnItem();
    }

    private void SpawnItem() {

        int angleStep = 360 / count;

        for (int i = 0; i < count; i++)
        {
            var item = Instantiate(_items.applePrefub, _circle.transform.position, Quaternion.identity);

            item.transform.SetParent(_circle.transform);

            item.transform.position = new Vector2(radius * Mathf.Cos(angleStep * i), radius * Mathf.Sin(angleStep * i) + 2);
        }

    }
}
