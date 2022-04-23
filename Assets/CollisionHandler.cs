using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] float loadDelay = 0.5f;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{name} ***collided with*** {other.gameObject.name}"); //another way of writing string concats
        startCrashSequence();
    }

    private void startCrashSequence()
    {
        crashParticle.Play();

        GameObject parts = this.transform.GetChild (0).gameObject;
        parts.gameObject.SetActive(false);

        GetComponent<BoxCollider>().enabled = false;        
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curSceneIndex);
    }
}
