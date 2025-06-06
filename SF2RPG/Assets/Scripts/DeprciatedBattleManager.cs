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

// I thought I needed to get fancy with some sort of enum but once I wasn't STRESSED BEYOND BELIEF 
// The solution was far less convoluted. Why do a limited enum for units when an array is easier?
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


public class DeprciatedBattleManager : MonoBehaviour
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
        StartCoroutine(SetupBattle());

       // battleState = BattleState.Start;
    }


    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator SetupBattle()
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

        yield return new WaitForSeconds(2f);

        TimeManager.battleParticipants = battleParticipants;
    }

    // This is called by TimeManager, which is responsible for counting down everyone's recovery
    // Yes I know I could just click on the 1 reference button but this helps future me be less confused when I'm tracing code
    public void WhoseTurn(CharacterClass character)
    {
        // Look I know this could've been prettier but I'm gonna be so real:
        // This is gonna get shit done

        // Basically we're counting down in the timer function, then passing over whichever character's timer reaches zero
        // then setting the battle state to that character's turn. Should also avoid issues with out of range indexes.
        // This could've been done with battleParticipants[turn] but I like it this way as its more readable to me
        int turn = battleParticipants.IndexOf(character);

        switch (turn)
        {
            case 0:
                {
                    battleState = BattleState.CharacterTurn1;
                    playerCharacters[0].CharacterTurn();
                    break;
                }
            case 1:
                {
                    battleState = BattleState.CharacterTurn2;
                    playerCharacters[1].CharacterTurn();
                    break;
                }
            case 2:
                {
                    battleState = BattleState.CharacterTurn3;
                    playerCharacters[2].CharacterTurn();
                    break;
                }
            case 3:
                {
                    battleState = BattleState.CharacterTurn4;
                    playerCharacters[3].CharacterTurn();
                    break;
                }
            case 4:
                {
                    battleState = BattleState.EnemyTurn1;
                    enemyCharacters[0].CharacterTurn();
                    break;
                }
            case 5:
                {
                    battleState = BattleState.EnemyTurn2;
                    enemyCharacters[1].CharacterTurn();
                    break;
                }
            case 6:
                {
                    battleState = BattleState.EnemyTurn3;
                    enemyCharacters[2].CharacterTurn();
                    break;
                }
            case 7:
                {
                    battleState = BattleState.EnemyTurn4;
                    enemyCharacters[3].CharacterTurn();
                    break;
                }
            case 8:
                {
                    battleState = BattleState.EnemyTurn5;
                    enemyCharacters[4].CharacterTurn();
                    break;
                }
            case 9:
                {
                    battleState = BattleState.EnemyTurn6;
                    enemyCharacters[5].CharacterTurn();
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
