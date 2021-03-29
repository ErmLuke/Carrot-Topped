using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float jumpsLeft;
    private Rigidbody rb;
    public Vector3 moveVelocity;
    public bool isGrounded;
    Animator anim;
    public Camera playerCam;
    public float upWCheck;
    float difficulty = 1f;
    public bool m_isAxisInUse = false;
    public GameObject deathUI;
    public GameObject obsSpawner;
    public AudioSource aSRC;
    public AudioSource aSRCI;
    public GameObject scoreScript;
    public bool isAndroid;
    public Vector3 moveInput;
    public int androidHorizontal = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        if (isAndroid)
        {
            moveInput = new Vector3(androidHorizontal, 0, -1);
            if (isGrounded)
            {
                aSRCI.volume = 0;
                aSRC.volume = 1;
            }
            else
            {
                aSRCI.volume = 0;
                aSRC.volume = 0;
            }
        }
        else
        {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            if (isGrounded)
            {
                aSRCI.volume = 0.5f;
                aSRC.volume = 0;
            }
        }

        moveVelocity = moveInput.normalized * speed;
        upWCheck = rb.velocity.y;

        aSRC.pitch = moveVelocity.magnitude + 0.2f;


        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (isGrounded)
            {
                aSRCI.volume = 0;
                aSRC.volume = 1;
            }
            else
            {
                aSRCI.volume = 0;
                aSRC.volume = 0;
            }
        }
        else
        {
            if (isGrounded)
            {
                aSRCI.volume = 0.5f;
                aSRC.volume = 0;
            }
        }
        if (Input.GetAxis("Jump") == 1 && jumpsLeft > 0)
        {
            if (m_isAxisInUse == false)
            {

                m_isAxisInUse = true;
                jumpsLeft -= 1;

                if ((isGrounded) || jumpsLeft == 1)
                {
                    Soundmanager.PlaySound("jump");
                    rb.velocity = Vector3.zero;
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
            }
        }
        if (Input.GetAxis("Jump") == 0)
        {
            m_isAxisInUse = false;
        }

        if (moveVelocity == Vector3.zero)
        {
            anim.SetBool("isFalling", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isRising", false);

            Invoke("CameraZoom", 5);

        }
        else
        {
            if (playerCam.fieldOfView < 50)
            {
                playerCam.fieldOfView += 20 * Time.deltaTime;
            }
            if (isGrounded)
            {
                anim.SetBool("isRising", false);
                anim.SetBool("isFalling", false);
                anim.SetBool("isRunning", true);
            }
            else
            {
                if (rb.velocity.y > 0)
                {
                    anim.SetBool("isRising", true);
                    anim.SetBool("isFalling", false);
                    anim.SetBool("isRunning", false);
                }
                else
                {
                    anim.SetBool("isRising", false);
                    anim.SetBool("isFalling", true);
                    anim.SetBool("isRunning", false);
                }
            }
        }
    }

    void FixedUpdate()
    {
        difficulty = Mathf.Clamp(difficulty + (0.05f * Time.deltaTime), 0, 2.5f);
        rb.position = rb.position + new Vector3(moveVelocity.z * difficulty * Time.fixedDeltaTime, 0, -(moveVelocity.x * Time.fixedDeltaTime));

        if (gameObject.transform.position.y < -1f)
        {
            Invoke("Death", 0f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        float collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;


        if (collision.collider.tag == "Obstacle")
        {
            if (collisionForce > 100f)
            {
                Soundmanager.PlaySound("playerHit");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11) // Slow layer
        {
            speed = speed * 0.35f;
            jumpForce = jumpForce * 0.75f;
            Debug.Log("Slow started");
        }
        if (other.gameObject.tag == "FACE")
        {
            Invoke("Death", 0f);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            speed = (speed / 35) * 100;
            jumpForce = (jumpForce / 75) * 100;
            Debug.Log("Slow ended");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            isGrounded = true;
            jumpsLeft = 2;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            isGrounded = false;
        }
    }

    void CameraZoom()
    {
        if (playerCam.fieldOfView > 30)
        {
            playerCam.fieldOfView -= 8 * Time.deltaTime;
        }
    }

    void Death()
    {
        scoreScript.GetComponent<Score>().onDeath();
        obsSpawner.SetActive(false);
        deathUI.SetActive(true);
        gameObject.SetActive(false);
    }

    public void MoveLeft()
    {
        androidHorizontal = -1;
    }

    public void MoveRight()
    {
        androidHorizontal = 1;
    }
    public void ReleaseDirection()
    {
        androidHorizontal = 0;
    }
    public void Jump()
    {
        if (jumpsLeft > 0)
        {
            jumpsLeft -= 1;

            if ((isGrounded) || jumpsLeft == 1)
            {
                Soundmanager.PlaySound("jump");
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

}
