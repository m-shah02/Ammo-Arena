using UnityEngine;
using TMPro;

public class CollectableCount : MonoBehaviour
{
    TMP_Text text;
    int count;
    private void Start() => UpdateCount();
    private void Awake()
    {
        text = GetComponent<TMP_Text>();

    }
    private void OnEnable() => Collectable.OnCollected += OnCollectibleCollected;
    private void OnDisable() => Collectable.OnCollected -= OnCollectibleCollected;
    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
    }

    void UpdateCount()
    {
        text.text = $"Coins: {count} / {Collectable.total}";
    }
}
