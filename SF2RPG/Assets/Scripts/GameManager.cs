using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<CharacterClass> playerCharacters = new List<CharacterClass>();
    public List<TextMeshProUGUI> playerHealth = new List<TextMeshProUGUI>();
    public List<Slider> playerTimer = new List<Slider>();


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerCharacters.Count; i++) 
        {
            playerCharacters[i].myHealth = playerHealth[i];
            playerTimer[i].value = playerCharacters[i].turnTimer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
