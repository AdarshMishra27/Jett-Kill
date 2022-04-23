using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int noOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if(noOfMusicPlayers > 1) {
            Destroy(gameObject);
        }else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
