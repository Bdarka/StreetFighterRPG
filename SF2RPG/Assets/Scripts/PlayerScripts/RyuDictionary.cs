using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyuDictionary : MonoBehaviour
{
    Dictionary<string, string> attackDictionary = new Dictionary<string, string>();

    public void Start()
    {
        attackDictionary.Clear();
        attackDictionary.Add("Attack", "Physical");
        attackDictionary.Add("Hadoken", "Ki");
        attackDictionary.Add("Shoryuken", "Physical");
        attackDictionary.Add("Tatsumaki", "Physical");
        attackDictionary.Add("Shakunetsu", "Ki");
        attackDictionary.Add("Denjin", "Ki");
        attackDictionary.Add("KazeNoKobushi", "Physical");
        attackDictionary.Add("ShinkuHadoken", "Ki");
        attackDictionary.Add("ShinTatsumaki", "Physical");
        attackDictionary.Add("DenjinHadoken", "Ki");
        attackDictionary.Add("ShinShoryuken", "Physical");
    }
} 
