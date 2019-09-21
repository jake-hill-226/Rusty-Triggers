using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitStage : MonoBehaviour {

    Player player;

	// Use this for initialization
	void Start () {

        try
        {
            Object playerResource = Resources.Load("Player\\Player");
            GameObject playerObject = Instantiate(playerResource, new Vector3(0.0f, 0.0f, 0.0f)
                                        , new Quaternion()) as GameObject;
            player = playerObject.GetComponent<Player>().InitFromFile(Player.CharacterDataRoot + "/Test-Character.json");

            Debug.Log("Character Name: " + player.playerData.Name);
            Debug.Log("Character PrimaryWeapon: " + player.playerData.PrimaryWeapon);
        }
        catch
        {
            Debug.Log("could not instantiate object - Player");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
