using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    [Header("Tune values - Movement")]
    [Tooltip ("How Fast Ship moving up and Down")][SerializeField] float tuneControlValue = 10f;
    [Tooltip("Tune the borders for Ship to stay within screen canvas")][SerializeField] float tuneXScreenRange = 10f;

    [Header("Tune values - Rotation")]
    [Tooltip("Value to tune Pitch")][SerializeField] float tunePitchValue = 2f;
    [Tooltip("Value to tune Roll")][SerializeField] float tuneRollValue = -15f;

    [Header("Rotation Factors")]
    [Tooltip("How strong Ship pitching during changing height")][SerializeField] float pitchFactor = -2.2f;
    [Tooltip("How strong Ship yaw during moving left / right")][SerializeField] float yawFactor = -3f;

    [Header("Depended Game Objects")]
    [Tooltip("Lazer been VFX Object")][SerializeField] GameObject lazer;



    float horizontalAxe, verticalAxe;

    void Update()
    {
        StarShipTranslation();
        StarShipRotation();
        Shooting();
    }

    void StarShipTranslation()
    {
        horizontalAxe = Input.GetAxis("Horizontal");
        verticalAxe = Input.GetAxis("Vertical");


        float xOffset = horizontalAxe * Time.deltaTime * tuneControlValue;
        float yOffset = verticalAxe * Time.deltaTime * tuneControlValue;

        float newXPos = Mathf.Clamp((transform.localPosition.x + xOffset),
                                    -tuneXScreenRange, tuneXScreenRange);
        float newYPos = Mathf.Clamp((transform.localPosition.y + yOffset),
                                    -4, 7);


        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

    void StarShipRotation()
    {
        float pitch = transform.localPosition.y * pitchFactor + verticalAxe * tunePitchValue;
        //float yaw = transform.localPosition.x * yawFactor;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = horizontalAxe * tuneRollValue; ;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    void Shooting()
    {
        lazer.SetActive(Input.GetButton("Fire1"));
            
    }
   
}
