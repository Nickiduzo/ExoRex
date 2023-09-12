using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Transform shotPos;
    [SerializeField]
    private GameObject shot;

    private float timerToShot;

    public string wheaponShootSound = "Shot";
    AudioManager audioManager;
    public void Start()
    {
        timerToShot = 0.5f;

        anim = GetComponent<Animator>();

        audioManager = AudioManager.instance; 
        if (audioManager == null)
        {
            Debug.Log("Wheapon sound not found");
        }
    }

    public void Update()
    {
        timerToShot -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.G) && timerToShot <= 0)
        {
            Instantiate(shot, shotPos.position, transform.rotation);
            audioManager.PlaySound(wheaponShootSound);
            anim.SetTrigger("isShot");
            timerToShot = 0.3f;
        }
    }
}
