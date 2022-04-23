using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT TO DESTROY OBJECTS
public class RightCollision : MonoBehaviour
{

    [SerializeField] GameObject deathVFXandSFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 6;
    ScroreBoard scroreBoard;

    GameObject parentGameObject;

    private void Start()
    {
        scroreBoard = FindObjectOfType<ScroreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();
    }

    private void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"{name} I am hit by a {other.gameObject.name}");
        ProcessHit();
        if (hitPoints < 1)
            KillEnemy();
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathVFXandSFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;

        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        GameObject hitvfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        hitvfx.transform.parent = parentGameObject.transform;
        hitPoints--;
        scroreBoard.IncreaseScore(scorePerHit);
    }
}
