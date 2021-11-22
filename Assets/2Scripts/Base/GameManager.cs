using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject menuCam;
    public GameObject gameCam;
    public Player player;

    public Boss boss;

    public Tiger tiger;
    public Eagle eagle;
    public Kangaroo kangaroo;
    public Panda panda;


    public GameObject itemShop;
    public GameObject weaponShop;
    public GameObject startZone;

    public GameObject homeZone;
    public GameObject chinaZone;
    public GameObject japanZone;
    public GameObject americaZone;



    public int stage;
    public float playTime;
    public bool isBattle;
    public int enemyCntA;
    public int enemyCntB;
    public int enemyCntC;
    public int enemyCntD;

    public int enemyCntE;
    public int enemyCntF;
    public int enemyCntG;
    public int enemyCntH;



    public Transform[] enemyZones;
    public GameObject[] enemies;
    public List<int> enemyList;


    public GameObject menuPanel;
    public GameObject gamePanel;
    public GameObject overPanel;

    //public Text maxScoreTxt;
    //public Text scoreTxt;
    public Text stageTxt;
   // public Text playTimeTxt;

    public Text playerHealthTxt;
    public Text playerAmmoTxt;
    public Text playerCoinTxt;

    public Image Weapon1Img;
    public Image Weapon2Img;
    public Image Weapon3Img;
    public Image Weapon4Img;

    public Text enemyATxt;
    public Text enemyBTxt;
    public Text enemyCTxt;

    public RectTransform bossHealthGroup;
    public RectTransform bossHealthBar;
    //public Text curScoreText;
    //public Text bestText;


    void Awake()
    {
        instance = this;

        SaveManager.instance.Load();

        enemyList = new List<int>();
        /*maxScoreTxt.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));

        if (PlayerPrefs.HasKey("MaxScore"))
            PlayerPrefs.SetInt("MaxScore", 0);
            */
    }

    private void Start()
    {
        if (SaveManager.instance.hasLoaded)
        {
            player.ammo = SaveManager.instance.activeSave.playerAmmo;
            player.coin = SaveManager.instance.activeSave.playerCoin;
            player.health = SaveManager.instance.activeSave.playerHealth;
            player.score = SaveManager.instance.activeSave.playerScore;
            player.hasWeapons = SaveManager.instance.activeSave.playerHasWeapons;
            player.hasGrenades = SaveManager.instance.activeSave.playerGrenades;
            player.levelNum = SaveManager.instance.activeSave.playerLevelNum;
        }
        else
        {
            SaveManager.instance.activeSave.playerAmmo = player.ammo;
            SaveManager.instance.activeSave.playerCoin = player.coin;
            SaveManager.instance.activeSave.playerHealth = player.health;
            SaveManager.instance.activeSave.playerScore = player.score;
            SaveManager.instance.activeSave.playerHasWeapons = player.hasWeapons;
            SaveManager.instance.activeSave.playerGrenades = player.hasGrenades;
            SaveManager.instance.activeSave.playerLevelNum = player.levelNum;
        }
    }

    public void GameStart()
    {
        menuCam.SetActive(false);
        gameCam.SetActive(true);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);

        player.gameObject.SetActive(true); 
    }

     
    public void GameOver()
    {
        gamePanel.SetActive(false);
        overPanel.SetActive(true);
        //curScoreText.text = scoreTxt.text;

        /*int maxScore = PlayerPrefs.GetInt("MaxScore");
        if(player.score > maxScore)
        {
            bestText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("MaxScore", player.score);
        }
        */
    }



    public void Restart()
    {
        SceneManager.LoadScene(0); 
    }


    public void StageStart()
    {
        homeZone.SetActive(false);
        itemShop.SetActive(false);
        weaponShop.SetActive(false);
        startZone.SetActive(false);

        foreach (Transform zone in enemyZones)
            zone.gameObject.SetActive(true);

        isBattle = true;
        StartCoroutine(InBattle());


    }

    public void StageEnd() 
    {

        player.transform.position = Vector3.up * 0.8f;
        itemShop.SetActive(true);
        weaponShop.SetActive(true);

        if(stage ==5)
        {
            homeZone.SetActive(true);
            americaZone.SetActive(true);
            player.levelNum = 1;
            //chinaZone.SetActive(true);


        }
        else if(stage == 10)
        {
            homeZone.SetActive(true);
            japanZone.SetActive(true);
            player.levelNum = 2;
        }

        else if(stage == 15)
        {
            homeZone.SetActive(true);
            chinaZone.SetActive(true);
            //americaZone.SetActive(true);
            player.levelNum = 3;
        }
        else
        {
            chinaZone.SetActive(false);
            japanZone.SetActive(false);
            americaZone.SetActive(false);

            homeZone.SetActive(true);
            startZone.SetActive(true);

        }

        foreach (Transform zone in enemyZones)
            zone.gameObject.SetActive(false);
        isBattle = false;
        stage++;
        
    }

    IEnumerator InBattle()
    {

        if(stage ==5)
        {
            //enemyCntD++;
            enemyCntE++;
            GameObject instantEnemy = Instantiate(enemies[4],
                                                      enemyZones[0].position,
                                                      enemyZones[0].rotation);

            Enemy enemy = instantEnemy.GetComponent<Enemy>();
            enemy.target = player.transform;
            enemy.manager = this;
            tiger = instantEnemy.GetComponent<Tiger>();
        }

        if(stage == 10)
        {
            //enemyCntD++;
            enemyCntF++;
            GameObject instantEnemy = Instantiate(enemies[5],
                                                      enemyZones[0].position,
                                                      enemyZones[0].rotation);

            Enemy enemy = instantEnemy.GetComponent<Enemy>();
            enemy.target = player.transform;
            enemy.manager = this;
            eagle = instantEnemy.GetComponent<Eagle>();
        }

        if(stage == 15)
        {
            //enemyCntD++;
            enemyCntG++;
            GameObject instantEnemy = Instantiate(enemies[6],
                                                      enemyZones[0].position,
                                                      enemyZones[0].rotation);

            Enemy enemy = instantEnemy.GetComponent<Enemy>();
            enemy.target = player.transform;
            enemy.manager = this;
            kangaroo = instantEnemy.GetComponent<Kangaroo>();
        }
        if(stage == 20)
        {
            //enemyCntD++;
            enemyCntH++;
            GameObject instantEnemy = Instantiate(enemies[7],
                                                      enemyZones[0].position,
                                                      enemyZones[0].rotation);

            Enemy enemy = instantEnemy.GetComponent<Enemy>();
            enemy.target = player.transform;
            enemy.manager = this;
            panda = instantEnemy.GetComponent<Panda>();
        }





        
            for (int index = 0; index < stage; index++)
            {
                int ran = Random.Range(0, 3);
                enemyList.Add(ran);

                switch (ran)
                {
                    case 0:
                        enemyCntA++;
                        break;
                    case 1:
                        enemyCntB++;
                        break;
                    case 2:
                        enemyCntC++;
                        break;

                }
            }


            while (enemyList.Count > 0)
            {
                int ranZone = Random.Range(0, 4);
                GameObject instantEnemy = Instantiate(enemies[enemyList[0]],
                                                      enemyZones[ranZone].position,
                                                      enemyZones[ranZone].rotation);

                Enemy enemy = instantEnemy.GetComponent<Enemy>();
                enemy.target = player.transform;
                enemy.manager = this;

                enemyList.RemoveAt(0);
                yield return new WaitForSeconds(4f);

            }
        
        

        while(enemyCntA + enemyCntB + enemyCntC + enemyCntD + enemyCntE + enemyCntF + enemyCntG + enemyCntH > 0)
        {
            yield return null;
        }

        yield return new WaitForSeconds(4f);
        boss = null;
        tiger = null;
        eagle = null;
        kangaroo = null;
        panda = null;
        StageEnd();


    }



    void Update()
    {
        if (isBattle)
            playTime += Time.deltaTime;
    }

    void LateUpdate()
    {

        //상단 UI
        //scoreTxt.text = string.Format("{0:n0}", player.score);
        stageTxt.text = "STAGE" + stage;



      

/*
         playTimeTxt.text = string.Format("{0:00}", hour) +
                                        " : " + string.Format("{0:00}", min) +
                                        " : " + string.Format("{0:00}", second);
*/

        //플레이어 UI
        playerHealthTxt.text = player.health + " / " + player.maxHealth;
        playerCoinTxt.text = string.Format("{0:n0}", player.coin);

        if (player.equipWeapon == null)
            playerAmmoTxt.text = "- / " + player.ammo;
        else if (player.equipWeapon.type == Weapon.Type.Melee)
            playerAmmoTxt.text = "- / " + player.ammo;
        else
            playerAmmoTxt.text = player.equipWeapon.curAmmo + " / " + player.ammo;


        //무기 UI
        Weapon1Img.color = new Color(1, 1, 1, player.hasWeapons[0] ? 1 : 0);
        Weapon2Img.color = new Color(1, 1, 1, player.hasWeapons[1] ? 1 : 0);
        Weapon3Img.color = new Color(1, 1, 1, player.hasWeapons[2] ? 1 : 0);
        Weapon4Img.color = new Color(1, 1, 1, player.hasGrenades > 0 ? 1 : 0);


        //몬스타 숫자 UI
        enemyATxt.text = enemyCntA.ToString();
        enemyBTxt.text = enemyCntB.ToString();
        enemyCTxt.text = enemyCntC.ToString();

        //보스 체력 UI
        /*
        if (boss != null)
        {
            bossHealthGroup.anchoredPosition = Vector3.down * 30;

            bossHealthBar.localScale = new Vector3((float)boss.curHealth / boss.maxHealth, 1, 1);
        }
        */
        

        if (tiger != null && stage == 5)
        {
            bossHealthGroup.anchoredPosition = Vector3.down * 30;

            bossHealthBar.localScale = new Vector3((float)tiger.curHealth / tiger.maxHealth, 1, 1);
        }

        else if (eagle != null && stage == 10)
        {
            bossHealthGroup.anchoredPosition = Vector3.down * 30;

            bossHealthBar.localScale = new Vector3((float)eagle.curHealth / eagle.maxHealth, 1, 1);
        }
        

        else if (kangaroo != null && stage == 15)
        {
            bossHealthGroup.anchoredPosition = Vector3.down * 30;

            bossHealthBar.localScale = new Vector3((float)kangaroo.curHealth / kangaroo.maxHealth, 1, 1);
        }

        else if (panda != null && stage == 20)
        {
            bossHealthGroup.anchoredPosition = Vector3.down * 30;

            bossHealthBar.localScale = new Vector3((float)panda.curHealth / panda.maxHealth, 1, 1);
        }


        else
        {
            bossHealthGroup.anchoredPosition = Vector3.up * 200;
        }

    }


}
