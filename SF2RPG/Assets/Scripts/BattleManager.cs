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
    CharacterTurn1,
    CharacterTurn2,
    CharacterTurn3,
    CharacterTurn4,
    EnemyTurn1,
    EnemyTurn2,
    EnemyTurn3,
    EnemyTurn4,
    EnemyTurn5,
    EnemyTurn6,
    Start,
    Win,
    Lose
}

public class BattleManager : MonoBehaviour
{ 
    // Setup for Battle
    public BattleState battleState;
    public UIManager UIManager;
    public TimeManager TimeManager;

    // Player Character Variables 
    public Transform[] playerPositions;
    public List<CharacterClass> playerCharacters = new List<CharacterClass>();

    // Enemy Variables
    public Transform[] enemyPositions;
    public List <CharacterClass> enemyCharacters = new List<CharacterClass>();

    // I just want a list with all battle characters for certain calculations
    public List<CharacterClass> battleParticipants = new List<CharacterClass>();

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
            battleParticipants.Add(playerCharacters[i]);
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
            battleParticipants[i] = enemyCharacters[i];
        }

        UIManager.SetEnemyUI(enemyCharacters);

        TimeManager.battleParticipants = battleParticipants;
    }

    public void WhoseTurn(CharacterClass character)
    {
        // Look I know this could've been prettier but I'm gonna be so real:
        // This is gonna get shit done

        // Basically we're counting down in the timer function, then passing over whichever character's timer reaches zero
        // then setting the battle state to that character's turn. Should also avoid issues with out of range indexes.
        int turn = battleParticipants.IndexOf(character);

        switch (turn)
        {
            case 0:
                {
                    battleState = BattleState.CharacterTurn1;
                    break;
                }
            case 1:
                {
                    battleState = BattleState.CharacterTurn2;
                    break;
                }
            case 2:
                {
                    battleState = BattleState.CharacterTurn3;
                    break;
                }
            case 3:
                {
                    battleState = BattleState.CharacterTurn4;
                    break;
                }
            case 4:
                {
                    battleState = BattleState.EnemyTurn1;
                    break;
                }
            case 5:
                {
                    battleState = BattleState.EnemyTurn2;
                    break;
                }
            case 6:
                {
                    battleState = BattleState.EnemyTurn3;
                    break;
                }
            case 7:
                {
                    battleState = BattleState.EnemyTurn4;
                    break;
                }
            case 8:
                {
                    battleState = BattleState.EnemyTurn5;
                    break;
                }
            case 9:
                {
                    battleState = BattleState.EnemyTurn6;
                    break;
                }
        }
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
