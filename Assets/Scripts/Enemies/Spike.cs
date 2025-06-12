using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField, Range(1, 100)] private int damage = 10;
    [SerializeField] private Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable health))
        {
            Attack(health);
        }
    }

    public void Attack(IDamagable health)
    {
        health.DoDamage(damage);
        animator.SetTrigger($"Attack {Random.Range(1, 3)}");
    }
}
