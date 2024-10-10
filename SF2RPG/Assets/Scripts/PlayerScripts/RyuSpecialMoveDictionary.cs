using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyuSpecialMoveDictionary : MonoBehaviour
{
    Dictionary<string, int> SpecialMoves = new Dictionary<string, int>();

    private void Start()
    {
        SpecialMoves.Add("Hadoken", 5);
        SpecialMoves.Add("Shoryuken", 7);
    }


}
