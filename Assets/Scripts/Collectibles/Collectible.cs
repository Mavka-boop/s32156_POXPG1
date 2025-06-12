using UnityEngine;

public abstract class Collectible<T> : MonoBehaviour where T : MonoBehaviour
{
    public abstract void OnPickUp(T picker);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out T picker))
        {
            OnPickUp(picker);
            Destroy(gameObject);
        }
    }
}
