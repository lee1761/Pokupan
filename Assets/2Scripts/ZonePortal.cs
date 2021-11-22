using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePortal : MonoBehaviour
{
    public Player player;
    public bool canPlayAus = false, canPlayChina = false, canPlayAmerica = false, isHome = false;
    public int levelSign;
    public SaveManager sManager;

    private void Update()
    {
        if (player.levelNum >= 1)
        {
            canPlayAmerica = true;
        }
        if (player.levelNum >= 2)
        {
            canPlayAus = true;
        }
        if (player.levelNum >= 3)
        {
            canPlayChina = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            if (isHome == true)
            {
                sManager.Save();
                LoadingSceneController.LoadScene("Home");
            }
            else if (this.levelSign == 0)
            {
                sManager.Save();
                LoadingSceneController.LoadScene("Korea");
            }
            else if (this.levelSign == 1 && canPlayAmerica == true)
            {
                sManager.Save();
                LoadingSceneController.LoadScene("America");
            }
            else if (this.levelSign == 2 && canPlayAus == true)
            {
                sManager.Save();
                LoadingSceneController.LoadScene("Australia");
            }
            else if (this.levelSign == 3 && canPlayChina == true)
            {
                sManager.Save();
                LoadingSceneController.LoadScene("China");
            }

        }


    }
}

