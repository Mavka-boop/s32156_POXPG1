using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text display;
    private int currentHealth;

    private void Start()
    {
        UpdateDisplay();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
    }

    public void UpdateDisplay()
    {
        display.text = currentHealth.ToString();
    }
}
