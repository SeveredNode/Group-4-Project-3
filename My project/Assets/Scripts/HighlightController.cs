using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{

    public GameObject gunUI;
    public GameObject shotgunUI;
    public GameObject rocketUI;
    public GameObject shieldUI;
    public GameObject droneUI;

    public PlayerController playerScript;
    


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gunUI = GameObject.Find("GunUI");
        shotgunUI = GameObject.Find("ShotgunUI");
        rocketUI = GameObject.Find("RocketUI");
        shieldUI = GameObject.Find("ShieldUI");
        droneUI = GameObject.Find("DroneUI");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.hasGunEquipped)
        {
            transform.position = gunUI.transform.position;
        }
        if (playerScript.hasShotgunEquipped)
        {
            transform.position = shotgunUI.transform.position;
        }
        if (playerScript.hasRocketEquipped)
        {
            transform.position = rocketUI.transform.position;
        }
        if (playerScript.hasShieldEquipped)
        {
            transform.position = shieldUI.transform.position;
        }
        if (playerScript.hasBulletStormEquipped)
        {
            transform.position = droneUI.transform.position;
        }

    }
}
