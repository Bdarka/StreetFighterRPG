using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyuCharacterScript : CharacterClass, IPlayerTemplate
{ 
    #region Ryu Attacks
    public enum RyuAttacks
    {
        Attack,
        // Special Moves
        Hadoken, 
        Shoryuken,
        Tatsumaki,
        Shakunetsu,
        Denjin,
        KazeNoKobushi,
        // Super Moves
        ShinkuHadoken,
        ShinTatsumaki,
        DenjinHadoken,
        ShinShoryuken,
    }

    public enum SuperMoves
    {

    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetAttributes();
        storedActions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Set Attributes from values saved in PlayerPrefs
    public void SetAttributes()
    {
        maxHealth = PlayerPrefs.GetInt("RyuMaxHealth");
        health = PlayerPrefs.GetInt("RyuCurrentHealth");
        maxMana = PlayerPrefs.GetInt("RyuMaxMana");
        mana = PlayerPrefs.GetInt("RyuMana");
        Attack = PlayerPrefs.GetInt("RyuAttack") + PlayerPrefs.GetInt("RyuEAttack");
        Defense = PlayerPrefs.GetInt("RyuDefense") + PlayerPrefs.GetInt("RyuEDefense");
        Ki = PlayerPrefs.GetInt("RyuKi") + PlayerPrefs.GetInt("RyuEKi");
        KiDefense = PlayerPrefs.GetInt("RyuKiDefense") + PlayerPrefs.GetInt("RyuEKiDefense");
        Speed = PlayerPrefs.GetInt("RyuSpeed") + PlayerPrefs.GetInt("RyuESpeed");
    }

    public void Defend()
    {

    }

    public void PlayerDealDamage(string DamageType)
    {
        if(DamageType == "Physical")
        {
            damageDealt = Attack;
        }
    }

    public void PlayerTakeDamage(int damage, string DamageType)
    {
        // Defense reduces damage by a percentage, but never less than 1
        if(DamageType == "Physical")
        {
            damage = (damage * (100 - Defense) / 101 + 1);
        }

        else if(DamageType == "Ki")
        {
            damage = (damage * (100 - KiDefense) / 101 + 1);
        }

        else
        {
            // damage does not change 
        }

        health -= damage;
        myDamageTaken.gameObject.SetActive(true);
        myDamageTaken.text = damage.ToString();
    }
}
