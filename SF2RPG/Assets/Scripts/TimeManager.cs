using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public BattleManager battleManager;
    public List<CharacterClass> battleParticipants = new List<CharacterClass>();
    public CharacterClass currentCharacterTurn;
    public bool counting;

    // Update is called once per frame
    void Update()
    {
        // you need this bool or its just gonna keep counting down even when the turn is being done

        if ((counting == true))
        {
            foreach (CharacterClass c in battleParticipants)
            {
                if (c == null)
                {
                    break;
                }

                c.lastTurnRecovery -= Time.deltaTime;

                if (c.lastTurnRecovery < 0)
                {
                    currentCharacterTurn = c;
                    counting = false;
                }
            }
        }
       
    }
}
