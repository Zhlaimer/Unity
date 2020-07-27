﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : MonoBehaviour
{
    //逻辑：存储成一个文件，所以要设置存储的文件夹
    //Application.persistentDataPath

    public Inventory myInventory;

    public void SaveGame()
    {
        Debug.Log(Application.persistentDataPath);
        if (!Directory.Exists(Application.persistentDataPath+"/game_SaveData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_SaveData");
        }
        BinaryFormatter bf = new BinaryFormatter();//进行二进制转化

        FileStream file = File.Create(Application.persistentDataPath + "/game_SaveData/inventory.txt");

        var json = JsonUtility.ToJson(myInventory);

        bf.Serialize(file, json);

        file.Close();
    }
    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/game_SaveData/inventory.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_SaveData/inventory.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),myInventory);
            file.Close();
        }
    }
}
