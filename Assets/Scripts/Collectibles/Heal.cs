using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Collectible<PlayerHealth>
{
    [SerializeField, Range(1,100)] private int healAmount = 10;

    public override void OnPickUp(PlayerHealth picker)
    {
        picker.Heal(healAmount);
    }
}
