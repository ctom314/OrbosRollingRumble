using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public PlayerController playerController;
    public Maelstrom maelstrom;
    public float rollSpeedIncreaseRate;
    public float maxRollSpeedIncreaseRate;

    // Update is called once per frame
    void Update()
    {
        // Increase player roll speed and max roll speed overtime
        playerController.rollSpeed += rollSpeedIncreaseRate * Time.deltaTime;
        playerController.maxRollSpeed += maxRollSpeedIncreaseRate * Time.deltaTime;

        // Increase maelstrom roll speed and max roll speed overtime
        maelstrom.rollSpeed += rollSpeedIncreaseRate * Time.deltaTime;
        maelstrom.maxRollSpeed += maxRollSpeedIncreaseRate * Time.deltaTime;
    }
}
