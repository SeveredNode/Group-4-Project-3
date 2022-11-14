using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    Slider healthBarSlider;
    public PlayerController playerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        healthBarSlider = GetComponent<Slider>();
        healthBarSlider.maxValue = playerScript.maxHealth;
        healthBarSlider.value = playerScript.health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarSlider.value = playerScript.health;
    }
}
