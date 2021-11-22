using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TutorialManager : MonoBehaviour
{
    public Player player;

    public Text playerHealthTxt;
    public Text playerAmmoTxt;
    public Text playerCoinTxt;

    public Image Weapon1Img;
    public Image Weapon2Img;
    public Image Weapon3Img;
    public Image Weapon4Img;


    public void Click()
    {
        SceneManager.LoadScene(2);
    }


    public void StageStart()
    {
        SceneManager.LoadScene(5);

    }


    void LateUpdate()
    {
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

    }


}
