using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Set Up Player UI
    public List<CharacterClass> playerCharacters = new List<CharacterClass>();
    public List<TextMeshProUGUI> playerCharacterNames = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> playerLevels = new List<TextMeshProUGUI>();

    // Updated more regualrly than variables above
    public List<TextMeshProUGUI> playerHealth = new List<TextMeshProUGUI>();
    public List<Slider> playerActionTimer = new List<Slider>();

    // Set Up Enemy UI
    public List<CharacterClass> enemies = new List<CharacterClass>();
    public List<TextMeshProUGUI> enemyNames = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> enemyLevels = new List<TextMeshProUGUI>();

    public List<TextMeshProUGUI> enemyHealth = new List<TextMeshProUGUI>();
    public List<Slider> enemyActionTimer = new List<Slider>();

    #region Player UI
    // Setup Initial Player UI
    public void SetupPlayerUI(List<CharacterClass> playerCharacters)
    {
        for (int i = 0; i < playerCharacters.Count; i++)
        {
            playerCharacterNames[i].text = playerCharacters[i].gameObject.name;
            playerLevels[i].text = playerCharacters[i].characterLevel.ToString();
            playerCharacters[i].myHealth.text = playerHealth[i].ToString();
            // if we were doing health bars, this is the line where you'd add
            // playerActionTimer[i].maxValue = playerCharacter.maxHealth
            playerActionTimer[i].value = playerCharacters[i].turnTimer;
        }
    }

    // Make sure Player UI reflects Game State
    public void SetPlayerUI(List<CharacterClass> playerCharacters)
    {
        for (int i = 0; i < playerCharacters.Count; i++)
        {
            playerCharacters[i].myHealth.text = playerHealth[i].ToString();
            playerActionTimer[i].value = playerCharacters[i].turnTimer;
        }
    }

    #endregion

    #region Enemy UI 
    public void SetupEnemyUI(List<CharacterClass> enemyCharacters)
    {
        for (int i = 0; i < enemyCharacters.Count; i++)
        {
            enemyNames[i].text = enemyCharacters[i].gameObject.name;
            enemyLevels[i].text = enemyCharacters[i].characterLevel.ToString();
            enemyCharacters[i].myHealth.text = enemyHealth[i].ToString();
            enemyActionTimer[i].value = enemyCharacters[i].turnTimer;

        }
    }

    public void SetEnemyUI(List<CharacterClass> enemyCharacters)
    {
        for (int i = 0; i < enemyCharacters.Count; i++)
        {
            enemyCharacters[i].myHealth.text = playerHealth[i].ToString();
            playerActionTimer[i].value = enemyCharacters[i].turnTimer;
        }
    }

    #endregion
}
