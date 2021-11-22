using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KoreaZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        //SceneManager.LoadScene(4);
        LoadingSceneController.LoadScene("South Korea");

    }

    public void Click()
    {
        //SceneManager.LoadScene(4);
        LoadingSceneController.LoadScene("South Korea");

    }
}