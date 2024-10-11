using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerTemplate
{
    // Set the attributes of the player character
    public void SetAttributes()
    {}

    public void PlayerDealDamage(int damage, string DamageType)
    { }

    // Take damage
    public void PlayerTakeDamage(int Damage, string DamageType)
    {}

    public void PlayerTurn()
    { }

    public void Defend ()
    { }
}
