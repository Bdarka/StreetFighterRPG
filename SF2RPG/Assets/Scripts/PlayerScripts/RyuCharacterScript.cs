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

    public RyuAttacks ryuAttack;
    public List<RyuAttacks> currentAttackCombo;

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
        currentHealth = PlayerPrefs.GetInt("RyuCurrentHealth");
        maxMana = PlayerPrefs.GetInt("RyuMaxMana");
        currentMana = PlayerPrefs.GetInt("RyuMana");
        Strength = PlayerPrefs.GetInt("RyuStrength") + PlayerPrefs.GetInt("RyuEStrength");
        Defense = PlayerPrefs.GetInt("RyuDefense") + PlayerPrefs.GetInt("RyuEDefense");
        Ki = PlayerPrefs.GetInt("RyuKi") + PlayerPrefs.GetInt("RyuEKi");
        KiDefense = PlayerPrefs.GetInt("RyuKiDefense") + PlayerPrefs.GetInt("RyuEKiDefense");
        Speed = PlayerPrefs.GetInt("RyuSpeed") + PlayerPrefs.GetInt("RyuESpeed");
        maxStoredActions = PlayerPrefs.GetInt("RyuTurns");
    }

    public void Defend()
    {

    }

    public void PlayerDealDamage()
    {
        List<RyuAttacks> checkedAttacks = new List<RyuAttacks>();

        foreach(RyuAttacks attack in currentAttackCombo)
        {
            if(checkedAttacks.Contains(attack))
            {
                // do nothing
            }
            
            else
            {
                ActionSwitch(attack); 
            }
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

        currentHealth -= damage;
        myDamageTaken.gameObject.SetActive(true);
        myDamageTaken.text = damage.ToString();
    }

    // Force players to use multiple moves by lowering damage each time they
    // use the same move it does less damage in the combo
    public int SameAttackCheck(RyuAttacks check, int baseDamage)
    {
        int sameAttackCount = 0;
        int scaledComboDamage = 0;

        foreach(RyuAttacks attack in currentAttackCombo)
        {
            if(attack == check)
            {
                sameAttackCount++;
            }
        }

        for(int i = 0; i < sameAttackCount;i++)
        {
            scaledComboDamage += baseDamage - (int)(sameAttackCount * .60f);
        }

        return scaledComboDamage;
    }

    public int ActionSwitch(RyuAttacks currentAttack)
    {
        int baseDamage = 0;

        switch(currentAttack)
        {
            case RyuAttacks.Attack:
                {
                    break;
                }
            case RyuAttacks.Hadoken:
                {
                    baseDamage = Hadoken();
                    break;
                }
        }

        return baseDamage;
    }

    #region Ryu Special Moves

    public int Hadoken()
    {
        int damageDealt = (int)Mathf.Round(Ki * 1.5f);
        return damageDealt;
    }

    public int Shoryuken()
    {
        int damageDealt = (int)Mathf.Round(Strength * 1.5f);
        return damageDealt;
    }

    #endregion
}
