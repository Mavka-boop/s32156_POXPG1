using TMPro;
using UnityEngine;

public interface IDamagable
{
    public void DoDamage(int damage);
}

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private TMP_Text display;
    [SerializeField, Range(0,1000)] private int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateDisplay();
    }

    public void DoDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        UpdateDisplay();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        display.text = $"{currentHealth}/{maxHealth}";
    }
}
