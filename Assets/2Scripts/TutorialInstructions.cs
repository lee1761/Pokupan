using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInstructions : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject weaponShop, itemShop;
    public GameObject nextZone;
    public GameObject tutorialCoin, tutorialCoinTwo, tutorialCoinThree;
    public GameObject shootText, shootTextTwo;
    public Player player;

    [SerializeField]
    private int popUpIndex = 0;
    private int popUpSteps = 0;
    public float waitTime = 1f;

    //Note to self - if given enough time turn this into an array/list
    [Header("Image References")]
    public Image wKey,
        aKey,
        sKey,
        dKey,
        eKey,
        rKey,
        spaceKey,
        leftClick,
        rightClick,
        wKeyOn,
        aKeyOn,
        sKeyOn,
        dKeyOn,
        eKeyOn,
        rKeyOn,
        spaceKeyOn,
        leftClickOn,
        rightClickOn;

    private bool wPressed = false,
        aPressed = false,
        sPressed = false,
        dPressed = false,
        ePressed = false,
        rPressed = false,
        spacePressed = false,
        leftPressed = false,
        rightPressed = false,
        coinSpawned = false,
        shopSpawned = false;

    // Update is called once per frame
    void Update()
    {

        //Loops through the popUp Array and displays only the pop up that the player is currently up to.
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        //For the first pop up it checks if the player has pressed each of the WASD keys and changes the pop up accordingly
        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) && !wPressed)
            {
                wKey.gameObject.SetActive(false);
                wKeyOn.gameObject.SetActive(true);
                popUpSteps++;
                wPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.A) && !aPressed)
            {
                aKey.gameObject.SetActive(false);
                aKeyOn.gameObject.SetActive(true);
                popUpSteps++;
                aPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.S) && !sPressed)
            {
                sKey.gameObject.SetActive(false);
                sKeyOn.gameObject.SetActive(true);
                popUpSteps++;
                sPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.D) && !dPressed)
            {
                dKey.gameObject.SetActive(false);
                dKeyOn.gameObject.SetActive(true);
                popUpSteps++;
                dPressed = true;
            }

            if (popUpSteps >= 4)
            {
                popUpIndex++;
                popUpSteps = 0;
            }
        }

        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !spacePressed)
            {
                spaceKey.gameObject.SetActive(false);
                spaceKeyOn.gameObject.SetActive(true);
                spacePressed = true;
            }

            if (spacePressed)
            {
                waitTime -= Time.deltaTime;

                if (waitTime <= 0f)
                {
                    popUpSteps++;
                }
            }

            if (popUpSteps >= 1)
            {
                popUpIndex++;
                popUpSteps = 0;
                waitTime = 1f;
            }
        }

        else if (popUpIndex == 2)
        {
            if (!coinSpawned)
            {
                tutorialCoin.SetActive(true);
                coinSpawned = true;
            }
            else if (coinSpawned && player.coin >= 3000)
            {
                popUpIndex++;
                coinSpawned = false;
            }
        }

        else if (popUpIndex == 3)
        {
            if (!shopSpawned)
            {
                weaponShop.SetActive(true);
                shopSpawned = true;
            }
            else if (shopSpawned && !ePressed && Input.GetKeyDown(KeyCode.E))
            {
                eKey.gameObject.SetActive(false);
                eKeyOn.gameObject.SetActive(true);
                ePressed = true;
            }
            else if (shopSpawned && ePressed && waitTime <= 0f)
            {
                popUpIndex++;
                waitTime = 3f;
                shopSpawned = false;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        else if (popUpIndex == 4)
        {
            if (player.hasWeapons[1])
            {
                weaponShop.SetActive(false);
                popUpIndex++;
            }

        }

        else if (popUpIndex == 5)
        {
            if (!coinSpawned)
            {
                tutorialCoinTwo.SetActive(true);
                tutorialCoinThree.SetActive(true);
                coinSpawned = true;
            }
            else if (coinSpawned && player.coin >= 4000)
            {
                popUpIndex++;
                coinSpawned = false;
            }
        }

        else if (popUpIndex == 6)
        {
            if (!shopSpawned)
            {
                itemShop.SetActive(true);
                shopSpawned = true;
            }
            else if (shopSpawned && player.coin < 1000)
            {
                popUpIndex++;
                shopSpawned = false;
            }
        }

        else if (popUpIndex == 7)
        {
            if (waitTime <= 0)
            {
                waitTime = 1f;
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        else if (popUpIndex == 8)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !leftPressed)
            {
                leftClick.gameObject.SetActive(false);
                leftClickOn.gameObject.SetActive(true);
                shootText.SetActive(false);
                shootTextTwo.SetActive(true);
                leftPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1) && leftPressed && !rightPressed)
            {
                rightClick.gameObject.SetActive(false);
                rightClickOn.gameObject.SetActive(true);
                rightPressed = true;
                waitTime = 1f;
            }
            else if (rightPressed && leftPressed && waitTime <= 0f)
            {
                waitTime = 1f;
                popUpIndex++;
            }
            else if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
            }
        }

        else if (popUpIndex == 9)
        {
            if (Input.GetKeyDown(KeyCode.R) && !rPressed)
            {
                rKey.gameObject.SetActive(false);
                rKeyOn.gameObject.SetActive(true);
                rPressed = true;
                waitTime = 1f;
            }
            else if (rPressed && waitTime <= 0)
            {
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        else if (popUpIndex == 10)
        {
            nextZone.SetActive(true);
        }
    }
}
