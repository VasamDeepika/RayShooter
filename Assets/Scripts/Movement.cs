using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed;
    float xRange = 16.0f;
    float yRange = 5.0f;
    [SerializeField]
    float positionpitchFactor = 5.0f;
    [SerializeField]
    float controlpitchFactor = 5f;
    float pitchControlValue = 5f;
    [SerializeField]
    float positionyawFactor = 5f;
    [SerializeField]
    float controlrollFactor = 5f;

    float xOffset, yOffset;
    // Update is called once per frame
    void Update()
    {
        playerPosition();
        playerRotation();
    }
     private void playerRotation()
    {
        //float xRotation = transform.localPosition.x * rotationFactor;
        float yRotation = transform.localPosition.y * positionpitchFactor;
        float pitchControlValue = yOffset * controlpitchFactor;
        float pitch = yRotation + pitchControlValue;
        

        float yaw = transform.localPosition.x * positionyawFactor;

        float roll = xOffset * controlrollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    private void playerPosition()
    {
        float horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal");

        float xOffset = horizontalMove * speed * Time.deltaTime;

        float verticalMove = CrossPlatformInputManager.GetAxis("Vertical");

        float yOffset = verticalMove * speed * Time.deltaTime;

        float XrawPos = transform.localPosition.x + xOffset;

        float YrawPos = transform.localPosition.y + yOffset;

        float clampedXpos = Mathf.Clamp(XrawPos, -xRange, xRange);

        float clampedYpos = Mathf.Clamp(YrawPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
}