using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int currentScore;
    [SerializeField] private TMP_Text display;

    private void Start()
    {
        UpdateDisplay();
    }

    public void Add(int score)
    {
        currentScore += score;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        display.text = currentScore.ToString();
    }
}
