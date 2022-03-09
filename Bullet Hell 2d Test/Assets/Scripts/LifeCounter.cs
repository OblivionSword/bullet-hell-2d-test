using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI lifeCounter;

    // Update is called once per frame
    void Update()
    {
        lifeCounter.text = player.life.ToString();
    }
}
