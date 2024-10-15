using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/* using the following tutorials as reference:
 * Brackeys Turn-Based Combat 
 * https://youtu.be/_1pz_ohupPs?si=on-BEGY1uXQoZPbw
 */

// Keeping track of whose turn it is. Trust me this helps with the ATB System
public enum BattleState
{
    Start,
    Win,
    Lose,
    CharacterTurn1,
    CharacterTurn2,
    CharacterTurn3,
    CharacterTurn4,
    EnemyTurn1,
    EnemyTurn2,
    EnemyTurn3,
    EnemyTurn4,
    EnemyTurn5,
    EnemyTurn6
}

public class BattleManager : MonoBehaviour
{
    // Setup for Battle
    public BattleState battleState;
    public UIManager UIManager;

    // Player Character Variables 
    public Transform[] playerPositions;
    public List<CharacterClass> playerCharacters = new List<CharacterClass>();

    // Enemy Variables
    public Transform[] enemyPositions;
    public List <CharacterClass> enemyCharacters = new List<CharacterClass>();

    // Start is called before the first frame update
    void Start()
    {
        SetupBattle();

        battleState = BattleState.Start;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetupBattle()
    {
        // places Player characters, Calls Object to Set Their UI

        for (int i = 0; i < playerCharacters.Count; i++)

        {
            if (playerCharacters[i] == null)
            {
                break;
            }

            Instantiate(playerCharacters[i], playerPositions[i]);

        }

        UIManager.SetupPlayerUI(playerCharacters);

        // same thing again but for enemy characters
        for (int i = 0; i < enemyCharacters.Count; i++)
        {
            if (enemyCharacters[i] == null)
            {
                break;
            }

            Instantiate(enemyCharacters[i], enemyPositions[i]);

        }

        UIManager.SetEnemyUI(enemyCharacters);
    }


    public void CalculateDamage(int damage, string DamageType, int attackerStrength, int defenderFortitude)
    {
        //if(DamageType == Physical)
    }

    // Roll the rewards from the battle and then display it to the player
    public void BattleRewards()
    {

    }


}
