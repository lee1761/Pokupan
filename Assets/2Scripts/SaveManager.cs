using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public SaveData activeSave;

    public Player player;

    public bool hasLoaded;

    private void Awake()
    {
        instance = this;

        Load();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save()
    {
        instance.activeSave.playerAmmo = player.ammo;
        instance.activeSave.playerCoin = player.coin;
        instance.activeSave.playerHealth = player.health;
        instance.activeSave.playerScore = player.score;
        instance.activeSave.playerHasWeapons = player.hasWeapons;
        instance.activeSave.playerGrenades = player.hasGrenades;
        instance.activeSave.playerLevelNum = player.levelNum;

        //Using a data path that doesn't change with different computers | according to the unity documentation is %userprofile%\AppData\Local\Packages\<productname>\LocalState
        string dataPath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".poku", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        Debug.Log("Saved");
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".poku"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".poku", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log("Loaded");

            hasLoaded = true;

        }
    }

    public void DeleteSaveData()
    {
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".poku"))
        {
            File.Delete(dataPath + "/" + activeSave.saveName + ".poku");
        }
    }

}

[System.Serializable]
public class SaveData
{
    public string saveName;

    public int playerAmmo;
    public int playerCoin;
    public int playerHealth;
    public int playerScore;
    public int playerLevelNum;

    public bool[] playerHasWeapons;
    public int playerGrenades;
}
