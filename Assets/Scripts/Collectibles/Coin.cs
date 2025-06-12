using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectible<PlayerInventory>
{
    [SerializeField, Range(1,100)] private int score = 1;

    public override void OnPickUp(PlayerInventory picker)
    {
        picker.Add(score);
    }
}
