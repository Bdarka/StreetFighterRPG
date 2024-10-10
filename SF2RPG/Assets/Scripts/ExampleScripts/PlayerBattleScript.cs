/*
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static EnemyScript;

/* To Do:
 * More Feedback 
 * Change Enemy Sprite based on Type
 */

/* What Did I Learn:
 *  How to make turn based combat 
 *  How to make a fishing mechanic 
 *  How to set sprites and animations through code
 *  
 */

/*
public class PlayerBattleScript : MonoBehaviour
{
    //this just helps me keep track of which code should be executing and when
    public enum whoseTurn
    {
        PlayerTurn,
        EnemyTurn
    }
    public whoseTurn currentTurn;

    public EnemyScript enemy;
    public int damageToEnemy;

    public GameObject player;
    public int playerHealth, playerStrength, playerMagic, playerDefence;
    public Slider playerHealthSlider;
    private bool isDefending, isAbsoluteDefending;

    public GameObject FishingWindow;
    public GameObject viewPort;
    public Transform FishParent;
    public Transform FishSpawnerParent;

    public TextMeshProUGUI BattleText;
    public TextMesh playerDamageText, enemyDamageText;
    public TextMesh playerHealText, enemyHealText;
    private bool playerHeal, enemyHeal;
    private int healAmount;

    public Transform treasureParent;
    public int coins;
    public TextMesh coinDisplay;

    public GameObject EndScreen;
    private bool endScreenActive;
    public int killCount = 0;
    public TextMeshProUGUI EndText;

    public GameObject FailScreen;
    public TextMeshProUGUI FailText;

    public NumberTracking playerInfo;

    private AudioSource myMusic;
    public AudioClip[] audioClips; 

    // Start is called before the first frame update
    void Start()
    {
        FishingSaveData.Load();
        StartFishing();
        BattleText.gameObject.SetActive(false);
        myMusic = GetComponent<AudioSource>();
        StartMusic();
        coinDisplay.text = "Coins: " + coins.ToString();

        playerHealth = playerInfo.loadedPlayerHealth;
        Debug.Log(playerInfo.loadedPlayerHealth);
        SetHealth(playerHealth);
    }

    // Update is called once per frame
    void Update()
    {

        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }

        /*
        if(Input.GetKeyDown(KeyCode.C) && endScreenActive == true)
        {
            Continue();
        }

        if(Input.GetKeyDown(KeyCode.R) && endScreenActive == true)
        {
            Restart();
        }

        if(Input.GetKeyDown(KeyCode.Q) && endScreenActive == true)
        {
            Quit();
        */
/*
        if(Input.anyKey && endScreenActive == true)
        {
            playerInfo.SetPlayerHealth(playerHealth);
            SceneManager.LoadScene(0);
        }
    }

  

    public void PlayerActionSelected(PlayerActions passedAction)
    {
        StopFishing();
        BattleText.gameObject.SetActive(true);
        BattleText.text = ActionDictionary.actionNames[passedAction];

        StartCoroutine(PlayerAttackSequence());
        StartCoroutine(BattleTextWait());

        // Debug.Log(passedAction);
        PlayerEffect(passedAction);   
    }

    public IEnumerator PlayerAttackSequence()
    {
        player.transform.Translate(1, 0, 0);
        yield return new WaitForSeconds(1);
        player.transform.Translate(-1, 0, 0);

        currentTurn = whoseTurn.EnemyTurn;

        if (enemy.health <= 0)
        {
            EndGame();
        }

        enemy.enemyAction();
    }

    public void PlayerEffect(PlayerActions action)
    {
        switch (action)
        {
            case PlayerActions.Attack:
                {
                    damageToEnemy = playerStrength;
                    break;
                }

            case PlayerActions.Critical:
                {
                    damageToEnemy = playerStrength * 4;
                    break;
                }

            case PlayerActions.Defend:
                {
                    isDefending = true;
                    damageToEnemy = 0;
                    break;
                }

            case PlayerActions.AbsoluteDefence:
                {
                    isAbsoluteDefending = true;
                    damageToEnemy = 0;
                    break;
                }

            case PlayerActions.DoNothing:
                {
                    damageToEnemy = 0;
                    break;
                }

            case PlayerActions.Vulnerable:
                {
                    damageToEnemy = 0;
                    break;
                }

            case PlayerActions.Special:
                {
                    damageToEnemy = playerMagic;
                    break;
                }

            case PlayerActions.SuperSpecial:
                {
                    damageToEnemy = playerMagic * 2;
                    break;
                }

            case PlayerActions.Ultimate:
                {
                    damageToEnemy = playerMagic * 4;
                    break;
                }

            case PlayerActions.Fire:
                {
                    damageToEnemy = playerMagic;

                    if (enemy.enemyType == EnemyType.Ice)
                    {
                        damageToEnemy *= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Ground)
                    {
                        damageToEnemy /= 2;
                    }
                    else if(enemy.enemyType == EnemyType.Fire)
                    {
                        damageToEnemy = 0;
                    }

                    break;
                }

            case PlayerActions.GreatFire:
                {
                    damageToEnemy = playerMagic * 2;

                    if (enemy.enemyType == EnemyType.Ice)
                    {
                        damageToEnemy *= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Ground)
                    {
                        damageToEnemy /= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Fire)
                    {
                        damageToEnemy = 0;
                    }

                    break;
                }

            case PlayerActions.MassiveFire:
                {
                    damageToEnemy = playerMagic * 4;

                    if (enemy.enemyType == EnemyType.Ice)
                    {
                        damageToEnemy *= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Ground)
                    {
                        damageToEnemy /= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Fire)
                    {
                        damageToEnemy = 0;
                    }

                    break;
                }

            case PlayerActions.Ice:
                {
                    damageToEnemy = playerMagic;

                    if (enemy.enemyType == EnemyType.Ground)
                    {
                        damageToEnemy *= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Fire)
                    {
                        damageToEnemy /= 2;
                    }
                
                    else if (enemy.enemyType != EnemyType.Ice)
                {
                    damageToEnemy = 0;
                }

                break;
                }

            case PlayerActions.GreatIce:
                {
                    damageToEnemy = playerMagic * 2;

                    if (enemy.enemyType == EnemyType.Ground)
                    {
                        damageToEnemy *= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Fire)
                    {
                        damageToEnemy /= 2;
                    }
                    else if (enemy.enemyType != EnemyType.Ice)
                    {
                        damageToEnemy = 0;
                    }

                    break;
                }

            case PlayerActions.MassiveIce:
                {
                    damageToEnemy = playerMagic * 4;

                    if (enemy.enemyType == EnemyType.Ground)
                    {
                        damageToEnemy *= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Fire)
                    {
                        damageToEnemy /= 2;
                    }
                
                    else if (enemy.enemyType != EnemyType.Ice)
                    {
                        damageToEnemy = 0;
                    }

                break;

                }

            case PlayerActions.Ground:
                {
                    damageToEnemy = playerMagic;

                    if (enemy.enemyType == EnemyType.Fire)
                    {
                        damageToEnemy *= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Ice)
                    {
                        damageToEnemy /= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Ground)
                    {
                        damageToEnemy = 0;
                    }

                    break;
                }

            case PlayerActions.GreatGround:
                {
                    damageToEnemy = playerMagic * 2;

                    if (enemy.enemyType == EnemyType.Fire)
                    {
                        damageToEnemy *= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Ice)
                    {
                        damageToEnemy /= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Ground)
                    {
                        damageToEnemy = 0;
                    }    

                    break;
                }

            case PlayerActions.MassiveGround:
                {
                    damageToEnemy = playerMagic * 4;

                    if (enemy.enemyType == EnemyType.Fire)
                    {
                        damageToEnemy *= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Ice)
                    {
                        damageToEnemy /= 2;
                    }
                    else if (enemy.enemyType == EnemyType.Ground)
                    {
                        damageToEnemy = 0;
                    }

                    break;
                }

            case PlayerActions.Heal:
                {
                    playerHealth += 25;
                    healAmount = 25;
                    playerHeal = true;

                    damageToEnemy = 0;
                    break;
                }

            case PlayerActions.GreatHeal:
                {
                    playerHealth += 50;
                    healAmount = 50;
                    playerHeal = true;

                    damageToEnemy = 0;
                    break;
                }

            case PlayerActions.MassiveHeal:
                {
                    playerHealth += 100;
                    healAmount = 100;
                    playerHeal = true;

                    damageToEnemy = 0;
                    break;
                }

            case PlayerActions.Summon:
                {
                    damageToEnemy = playerMagic * 6;

                    break;
                }

            case PlayerActions.HealEnemy:
                {
                    damageToEnemy = -20;
                    healAmount = 20;
                    enemyHeal = true;
                    break;
                }

            case PlayerActions.GetMoney:
                {
                    damageToEnemy = 0;
                    coinDisplay.text = "Coins: " + coins.ToString();
                    break;
                }
        }

        if(playerHealth > 100)
        {
            playerHealth = 100;
        }


        if(damageToEnemy > 0)
        {
            enemy.TakeDamage(damageToEnemy);
            StartCoroutine(ShowDamage(enemyDamageText, damageToEnemy));
        }

        else if(playerHeal == true)
        {
            SetHealth(playerHealth);
            StartCoroutine(ShowDamage(playerHealText, healAmount));
            playerHeal = false;
        }

        else if(enemyHeal == true)
        {
            enemy.health += healAmount;
            enemy.SetHealth(enemy.health);
            StartCoroutine(ShowDamage(enemyHealText, healAmount));
            enemyHeal = false;
        }

        healAmount = 0;
    }
    public void EnemyActionSelected(int damage, string action)
    {
        if(isDefending == true)
        {
            damage /= 2;
            isDefending = false;
        }
        else if(isAbsoluteDefending == true)
        {
            damage = 0;
            isAbsoluteDefending = false;
        }

        playerHealth -= damage;
        BattleText.gameObject.SetActive(true);
        BattleText.text = action;

        StartCoroutine(ShowDamage(playerDamageText, damage));
        StartCoroutine(EnemyAttackSequence());
        StartCoroutine(BattleTextWait());
    }

    public IEnumerator EnemyAttackSequence()
    {
        enemy.transform.Translate(-1, 0, 0);
        yield return new WaitForSeconds(2);
        enemy.transform.Translate(1, 0, 0);
        SetHealth(playerHealth);
        currentTurn = whoseTurn.PlayerTurn;

        if(playerHealth <= 0)
        {
            GameOver();
        }

        else if (endScreenActive == false) 
        {
            StartFishing();
        }
        
    }

    public IEnumerator ShowDamage(TextMesh display, int damage)
    {
        if(damage > 0)
        {
            display.gameObject.SetActive(true);
            display.text = damage.ToString();

            yield return new WaitForSeconds(1);
            display.gameObject.SetActive(false);
        }
    }

    public void StartFishing()
    {
        FishingWindow.SetActive(true);
        viewPort.SetActive(true);
        foreach(Transform spawner in FishSpawnerParent)
        {
            spawner.gameObject.GetComponent<FishSpawner>().makeFish();
        }

        foreach(Transform child in treasureParent)
        {
            Treasure t = child.GetComponent<Treasure>();
            t.makeTreasure();
        }
    }

    public void StopFishing()
    {
        FishingWindow.SetActive(false);
        viewPort.SetActive(false);
        foreach (Transform fish in FishParent)
        {
            Destroy(fish.gameObject);
        }
    }

    public void SetHealth(int health)
    {
        playerHealthSlider.value = health;
    }

    public IEnumerator BattleTextWait()
    {
        yield return new WaitForSeconds(3);
        BattleText.gameObject.SetActive(false);
    }

    private void EndGame()
    {
        StopFishing();

        playerDamageText.gameObject.SetActive(false);
        enemyDamageText.gameObject.SetActive(false);
        BattleText.gameObject.SetActive(false);
        enemy.gameObject.SetActive(false);

        playerInfo.SetPlayerHealth(playerHealth);

        EndScreen.gameObject.SetActive(true);
        endScreenActive = true;
      //  EndText.text = "Congrats! You've defeated " + enemy.enemyType.ToString() + "\n" + "You have " + coins + " coins" + "\n" + "Press Any Key to Continue";
    }

    private void GameOver()
    {
        StopFishing();
        StopAllCoroutines();

        playerDamageText.gameObject.SetActive(false);
        enemyDamageText.gameObject.SetActive(false);
        BattleText.gameObject.SetActive(false);

        FailScreen.gameObject.SetActive(true);
       FailText.text = "Oh no you died! You defeated " + killCount + " fish. Your life savings was " + coins + " coins";

    }

    /*
    public void Continue()
    {
        enemy.gameObject.SetActive(true);
        enemy.health = 200;
        enemy.SetHealth(enemy.health);
        enemy.RollEnemyType();

        EndScreen.gameObject.SetActive(false);
        endScreenActive = false;

        StartMusic();
        StartFishing();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    */
/*
    public void Quit()
    {
        Application.Quit();
    }
    

    private void StartMusic()
    {
        int rollMusic = UnityEngine.Random.Range(0, audioClips.Length);
        myMusic.clip = audioClips[rollMusic]; 
        myMusic.Play();
    }
}
*/