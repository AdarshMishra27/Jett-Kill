using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Genral Setup Settings")]
    [SerializeField] float controlSpeed = 30f;
    [Tooltip("How fast player moves horizontally!")][SerializeField] float xRange = 20f;
    [Tooltip("How fast player moves vertically!")][SerializeField] float yRange = 15f; //tooltip attributes gives information when you hover in that field


    [Header("Laser Gun Array")]
    [SerializeField] GameObject[] lasers;


    [Header("Screen Position based Tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 3f;

    [Header("Player Input based Tuning")]
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -15f;

    float xThrow;
    float yThrow;
    void Update()
    {
        ProcessTransaltion();
        ProcessRotation();
        ProcessFiring();
        ExitGame();
    }

    private void ExitGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Quitting!!!");
            Application.Quit();
        }
    }

    void ProcessTransaltion()
    {
        xThrow = Input.GetAxis("Horizontal");
        // Debug.Log(xThrow);
        yThrow = Input.GetAxis("Vertical");
        // Debug.Log(yThrow);

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, +xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, +yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()

    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl; //x-axis rotation

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition; //y-axis rotation

        float rollDueToControl = xThrow * controlRollFactor;
        float roll = rollDueToControl; //z-axis rotation

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    private void SetLasersActive(bool isActive)
    {
        foreach (GameObject las in lasers)
        {
            var emissionModule = las.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
