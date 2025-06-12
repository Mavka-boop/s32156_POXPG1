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
    public bool isDead;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip damageClip;
    [SerializeField] private AudioClip healClip;

    private void Start()
    {
        currentHealth = maxHealth;
        heartBarController.CreateHearts(maxHealth);
    }

    public void DoDamage(int damage)
    {
        if (isDead) return;
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        heartBarController.TakeDamage(damage);
        audioSource.PlayOneShot(damageClip);
        if (currentHealth <= 0)
        {
            isDead = true;
            animator.SetTrigger("Died");
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;
        audioSource.PlayOneShot(healClip);
        currentHealth += amount;
        heartBarController.Heal(amount);
    }
}
