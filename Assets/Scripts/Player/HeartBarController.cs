using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeartBarController : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int heartsCount = 5;
    private int currentHealth = 10;
    private int maxHealth = 10;

    [Header("References")]
    [SerializeField] private GameObject heartPrefab;

    private List<Image> heartImages = new List<Image>();

    public void CreateHearts(int maxHealth)
    {
        currentHealth = maxHealth;
        this.maxHealth = maxHealth;
        foreach (Transform child in transform)
            Destroy(child.gameObject);
        heartImages.Clear();

        for (int i = 0; i < heartsCount; i++)
        {
            GameObject heartGO = Instantiate(heartPrefab, transform);
            RectTransform rt = heartGO.GetComponent<RectTransform>();
            Image img = heartGO.GetComponent<Image>();
            heartImages.Add(img);
        }
    }

    public void UpdateHealth(int health)
    {
        float healthPerHeart = (float)maxHealth / heartsCount;

        for (int i = 0; i < heartImages.Count; i++)
        {
            float heartHealth = Mathf.Clamp(health - i * healthPerHeart, 0, healthPerHeart);
            float fill = heartHealth / healthPerHeart;
            heartImages[i].fillAmount = fill;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount,0,maxHealth);
        UpdateHealth(currentHealth);
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0 ,maxHealth);
        UpdateHealth(currentHealth);
    }
}
