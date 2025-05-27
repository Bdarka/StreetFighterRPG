using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

/* using the following tutorials as reference:
 * Brackeys Turn-Based Combat 
 * https://youtu.be/_1pz_ohupPs?si=on-BEGY1uXQoZPbw
 */


public class BattleManager : MonoBehaviour
{
    // Setup for Battle
    public List<CharacterClass> battleParticipants = new List<CharacterClass>();
    public UIManager UIManager;
    public TimeManager TimeManager;

    // Player Character Variables 
    public Transform[] playerPositions;
    public List<CharacterClass> playerCharacters = new List<CharacterClass>();

    // Enemy Variables
    public Transform[] enemyPositions;
    public List <CharacterClass> enemyCharacters = new List<CharacterClass>();



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupBattle());
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

        battleParticipants = (List<CharacterClass>)battleParticipants.OrderBy(x => x.Speed);
        TimeManager.battleParticipants = battleParticipants;
    }

    // This is called by TimeManager, which is responsible for counting down everyone's recovery
    // Yes I know I could just click on the 1 reference button but this helps future me be less confused when I'm tracing code

    public void CalculateDamage(int damage, string DamageType, int attackerStrength, int defenderFortitude)
    {
        //if(DamageType == Physical)
    }


    // Roll the rewards from the battle and then display it to the player
    public void BattleRewards()
    {

    }


}
