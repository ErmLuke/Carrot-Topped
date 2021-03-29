using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    public static AudioClip playerHitSound, playerJumpSound, rollingPinHitNoise, canHitNoise, idlePanting, breadNoise;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {

        playerHitSound = Resources.Load<AudioClip>("playerHit");
        rollingPinHitNoise = Resources.Load<AudioClip>("rollingPinHit");
        playerJumpSound = Resources.Load<AudioClip>("jump");
        canHitNoise = Resources.Load<AudioClip>("canHit");
        idlePanting = Resources.Load<AudioClip>("idleNoise");
        breadNoise = Resources.Load<AudioClip>("Breadnoise");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "rollingPinHit":
                audioSrc.PlayOneShot(rollingPinHitNoise);
                break;
            case "jump":
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "canHit":
                audioSrc.PlayOneShot(canHitNoise);
                break;
            case "idleNoise":
                audioSrc.PlayOneShot(idlePanting);
                break;
            case "Breadnoise":
                audioSrc.PlayOneShot(breadNoise);
                break;
        }
    }
}
