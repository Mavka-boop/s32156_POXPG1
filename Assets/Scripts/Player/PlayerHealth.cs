using TMPro;
using UnityEngine;

public interface IDamagable
{
    public void DoDamage(int damage);
}

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private HeartBarController heartBarController;
    [SerializeField, Range(0,1000)] private int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        heartBarController.CreateHearts(maxHealth);
    }

    public void DoDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        heartBarController.TakeDamage(damage);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        heartBarController.Heal(amount);
    }
}
