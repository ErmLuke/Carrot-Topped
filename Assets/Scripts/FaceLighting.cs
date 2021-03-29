using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceLighting : MonoBehaviour
{
    public GameObject cam;
    public GameObject face;
    private Transform cameraPos;
    private Transform facePos;
    private SpriteRenderer spriteColor;
    //public float startDiff;
    public float gap;
    public float s_vibrance;
    // Start is called before the first frame update
    void Start()
    {
        facePos = face.GetComponent<Transform>();
        cameraPos = cam.GetComponent<Transform>();
        spriteColor = GetComponent<SpriteRenderer>();


        //startDiff = Mathf.Ceil(cameraPos.position.x - facePos.position.x) + 2;


    }

    // Update is called once per frame
    void Update()
    {
        gap = cameraPos.position.x - facePos.position.x + 2;
        s_vibrance = Mathf.Clamp((gap * 12), 20, 100) / 100;
        spriteColor.color = new Color(s_vibrance, s_vibrance, s_vibrance, 1);
    }
}
