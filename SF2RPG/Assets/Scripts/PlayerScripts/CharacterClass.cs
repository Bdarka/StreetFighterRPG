using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

/* The purpose of this script is to make a template for all the player characters. 
 * After that it should be easy to implement the other characters
 * 
 */

public class CharacterClass : MonoBehaviour
{
    // Setting character resources
    public int currentHealth;
    public int maxHealth;
    public int currentMana;
    public int maxMana;

    // Character Attributes 
    public int Strength;
    public int Defense;
    public int Ki;
    public int KiDefense;
    public int Speed;

    // Equipment Attributes 
    public int eStrength;
    public int eDefense;
    public int eKi;
    public int eKiDefense;
    public int eSpeed;

    // Player Action Variables 
    public bool isDefending;
    public int storedActions;
    public int maxStoredActions;
    public int comboCounter;

    // Adapted Street Fighter Mechanics
    public float lastTurnRecovery;
    public float turnTimer;
    [HideInInspector] public bool isEXMove;

    // Calculation Variables
    public int physicalComboDamage;
    public int kiComboDamage;

    // Display Variables
    public string characterName;
    public int characterLevel;
    public TextMeshProUGUI myHealth;
    public TextMeshProUGUI myDamageTaken;
    public List<Sprite> sprites;
    public SpriteRenderer mySprite;

    public void SetCharacter()
    {

    }

    public void CharacterTurn()
    {

    }

    public void SetSprite(string newSprite)
    {
        foreach (Sprite spriteCheck in sprites)
        {
            if(spriteCheck.name  == newSprite)
            {
                mySprite.sprite = spriteCheck;
            }
        }
    }
}
