using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    Image image;
    public Sprite muteOn;
    public Sprite muteOff;
    public GameObject cam;
    AudioListener listen;
    public bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        listen = cam.GetComponent<AudioListener>();
        image = GetComponent<Image>();
        if (PlayerPrefs.GetInt("muted") == 1)
        {
            VolumeOff();
        }
        else
        {
            VolumeOn();
        }
    }

    public void VolumeOn()
    {
        AudioListener.volume = 1;
        ChangeSprite(muteOff);
        muted = false;
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void VolumeOff()
    {
        AudioListener.volume = 0;
        ChangeSprite(muteOn);
        muted = true;
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void VolumeControl()
    {
        if (muted == false)
        {
            VolumeOff();
        }
        else
        {
            VolumeOn();
        }
    }

    void ChangeSprite(Sprite newSprite)
    {
        image.sprite = newSprite;
    }
}
