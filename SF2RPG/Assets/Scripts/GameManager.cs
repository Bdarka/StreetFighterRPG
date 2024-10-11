using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Set Up Player UI
    public List<CharacterClass> playerCharacters = new List<CharacterClass>();
    public List<TextMeshProUGUI> playerCharacterNames = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> playerHealth = new List<TextMeshProUGUI>();
    public List<Slider> playerActionTimer = new List<Slider>();

    // Set Up Enemy UI
    public List<Enemy> enemies = new List<Enemy>();
    public List<TextMeshProUGUI> enemyHealth = new List<TextMeshProUGUI>();
    public List<Slider> enemyActionTimer = new List<Slider>();


    // Start is called before the first frame update
    void Start()
    {
        // make sure UI is set up at start of battle
        SetUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region UI Functions
    // Make sure UI reflects Game State
    public void SetUI()
    {
        for (int i = 0; i < playerCharacters.Count; i++)
        {
            playerCharacters[i].myHealth.text = playerHealth[i].ToString();
            playerActionTimer[i].value = playerCharacters[i].turnTimer;
            playerCharacterNames[i].text = playerCharacters[i].gameObject.name;
        }
    }

    public void AttackList()
    {

    }
    #endregion

    public void CalculateDamage(int damage, string DamageType, int attackerStrength, int defenderFortitude)
    {
        //if(DamageType == Physical)
    }

    // Roll the rewards from the battle and then display it to the player
    public void BattleRewards()
    {

    }


}
