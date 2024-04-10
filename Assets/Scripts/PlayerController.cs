using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 jump;
    public bool isGrounded;
    public float jumpForce = 1f;

    public float moveSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void FixedUpdate()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 movement = Vector3.right * horizontalInput;

        float verticalInput = Input.GetAxisRaw("Vertical");

        movement += Vector3.forward * verticalInput;
        movement = movement.normalized;
        movement *= Time.deltaTime;
        movement *= moveSpeed;
        transform.Translate(movement);

        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.CompareTag("Ground"))
            isGrounded = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("LevelEnd"))
        {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().OnWin();
        }
       if(other.CompareTag("CameraView"))
        {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().OnLose();
        }
    }
}
