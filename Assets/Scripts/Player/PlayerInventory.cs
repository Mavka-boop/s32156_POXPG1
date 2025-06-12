using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int currentScore;
    [SerializeField] private TMP_Text display;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip scoreClip;
    private void Start()
    {
        UpdateDisplay();
    }

    public void Add(int score)
    {
        audioSource.PlayOneShot(scoreClip);
        currentScore += score;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        display.text = currentScore.ToString();
    }
}
