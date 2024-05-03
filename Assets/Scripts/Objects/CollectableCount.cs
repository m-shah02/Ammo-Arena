using UnityEngine;
using TMPro;

public class CollectableCount : MonoBehaviour
{
    TMP_Text text;
    int count;

    private const string PlayerPrefKey = "PlayerCoins"; // Define a key for PlayerPrefs

    private void Start()
    {
        // Load the count from PlayerPrefs when the game starts
        count = PlayerPrefs.GetInt(PlayerPrefKey, 0);
        UpdateCount();
    }

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        Collectable.OnCollected += OnCollectibleCollected;
    }

    private void OnDisable()
    {
        Collectable.OnCollected -= OnCollectibleCollected;
    }

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
    }

    void UpdateCount()
    {
        text.text = $"Coins: {count}";
        // Save the count to PlayerPrefs whenever it's updated
        PlayerPrefs.SetInt(PlayerPrefKey, count);
        PlayerPrefs.Save();
    }
}

