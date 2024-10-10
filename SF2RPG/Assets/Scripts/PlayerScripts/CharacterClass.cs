using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/* The purpose of this script is to make a template for all the player characters. 
 * After that it should be easy to implement the other characters
 * 
 */

public class CharacterClass : MonoBehaviour
{
    // Setting character resources
    public int health;
    public int maxHealth;
    public int mana;
    public int maxMana;
    public int storedActions;
    public int maxStoredActions;

    // Character Attributes 
    public int Attack;
    public int Defense;
    public int Ki;
    public int KiDefense;
    public int Speed;


    // Adapted Street Fighter Mechanics
    public float lastTurnRecovery;
    public float turnTimer;
    [HideInInspector] public bool isEXMove;

    // Calculation Variables
    public int damageDealt;

    // Display Variables
    public TextMeshProUGUI myHealth;
    public TextMeshProUGUI myDamageTaken;

    #region Turn Functions
    public void PlayerTurn(string[] actions)
    {

    }

    public void NewTurnTimer(float recovery)
    {

    }

    #endregion

    public void TakeDamage(int damage)
    {
        health -= damage;
        myHealth.text = health.ToString();

        myDamageTaken.gameObject.SetActive(true);
        myDamageTaken.text = damage.ToString();
    }
}
