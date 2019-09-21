using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class Player : MonoBehaviour {

    public static string CharacterDataRoot = "Assets/Data/CharacterData";
    public static string WeaponDataRoot = "Assets/Data/WeaponData";

    public PlayerData playerData;
    Transform GunMount;
    GameObject PrimaryWeapon;

    public Player Init()
    {
        playerData.Name = "N/A";
        playerData.PrimaryWeapon = "N/A";
        this.setGunMountPoint();
        return this;
    }

    public Player InitFromFile(string PlayerFilePath)
    {
        if (!File.Exists(Directory.GetCurrentDirectory() + PlayerFilePath))
        {           
            try
            {
                // Initialize player data
                StreamReader playerFile = new StreamReader(PlayerFilePath);
                string jsonData = playerFile.ReadToEnd();
                playerData = JsonConvert.DeserializeObject<PlayerData>(jsonData);
                playerFile.Close();
            }
            catch
            {
                Debug.LogError("Failed to read file: " + PlayerFilePath);
                return null;
            }

            // Set weapon properties
            this.setGunMountPoint();
            GameObject WeaponPrefab = Resources.Load("Weapons\\" + this.playerData.PrimaryWeapon) as GameObject;
            if(WeaponPrefab == null)
            {
                Debug.Log("WeaponPrefab is null");
            }
            PrimaryWeapon = Instantiate(WeaponPrefab, GunMount);

            return this;
        }
        else
        {
            Debug.Log("File " + PlayerFilePath + " does not exist");
            return null;
        }
    }

    void setGunMountPoint()
    {
        GunMount = this.gameObject.transform.FindChild("MainCamera").FindChild("GunPosition").transform;
        if (GunMount == null)
        {
            Debug.LogError("GunMount point could not be initialized for player object");
            Application.Quit();
        }
    }
}
