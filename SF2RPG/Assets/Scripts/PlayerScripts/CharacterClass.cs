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
    public int[] comboDamage;

    // Character Attributes 
    public int Attack;
    public int Defense;
    public int Ki;
    public int KiDefense;
    public int Speed;

    // Equipment Attributes 
    public int eAttack;
    public int eDefense;
    public int eKi;
    public int eKiDefense;
    public int eSpeed;

    // Player Action Variables 
    public bool isDefending;

    // Adapted Street Fighter Mechanics
    public float lastTurnRecovery;
    public float turnTimer;
    [HideInInspector] public bool isEXMove;
    public int comboCounter;

    // Calculation Variables
    public int damageDealt;

    // Display Variables
    public TextMeshProUGUI myHealth;
    public TextMeshProUGUI myDamageTaken;
}
