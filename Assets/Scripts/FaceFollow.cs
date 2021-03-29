using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    Transform facePos;
    Transform playerPos;
    float playerStartPos;
    float faceStartPos;
    float gap;
    [SerializeField] float speed = 5;
    [SerializeField] float difficulty = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Sets starting position of the face relative to the player
        facePos = GetComponent<Transform>();
        playerPos = player.GetComponent<Transform>();
        playerStartPos = playerPos.position.x;
        faceStartPos = facePos.position.x;
        gap = Mathf.Abs(playerStartPos - faceStartPos) / 2;
        transform.position = new Vector3(playerPos.position.x + gap, 1.76f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        {
            difficulty = Mathf.Clamp(difficulty + (0.05f * Time.deltaTime), 0, 2.5f);
            // moves the face forward relative to the difficulty
            transform.position = transform.position - new Vector3(speed / 10 * difficulty * Time.deltaTime, 0, 0);
            // gives face a max distance so can't be escaped
            if ((facePos.position.x - playerPos.position.x) > 1)
            {
                transform.position = new Vector3(playerPos.position.x + 1, 1.76f, 0f);
            }
        }
    }
}
