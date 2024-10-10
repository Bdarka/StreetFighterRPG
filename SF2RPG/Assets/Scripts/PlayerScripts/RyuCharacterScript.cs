using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyuCharacterScript : CharacterClass
{
    #region Special and Super Moves
    public enum SpecialMoves
    {
        Hadoken, 
        Shoryuken,
        Tatsumaki,
        Shakunetsu,
        Denjin,
        KazeNoKobushi
    }

    public enum SuperMoves
    {
        ShinkuHadoken,
        ShinTatsumaki,
        DenjinHadoken,
        ShinShoryuken,
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
