using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZone : MonoBehaviour
{

    public GameObject saveMenu;
    public GameObject background;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            saveMenu.SetActive(true);
            background.SetActive(true);

            Time.timeScale = 0f;
            PauseMenu.GameIsPaused = true;
        }
    }

    public void Resume()
    {
        saveMenu.SetActive(false);
        background.SetActive(false);

        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
    }
}
