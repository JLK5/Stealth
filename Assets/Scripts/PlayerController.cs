using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //silnik fizyczny dla obiektu gracza
    Rigidbody rb;
    //si³a skoku
    public Vector3 jump;
    public bool isGrounded;
    public float jumpForce = 1f;

    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        //przypnij rigidbody gracza do zmiennej rb
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
        //mo¿na proœciej: Vector3.right

        //zczytaj klawiaturê w osi poziomej:
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //wyœwietl w konsoli stan klawiatury
        //Debug.Log(horizontalInput);

        //wylicz przesuniêcie w osi x
        Vector3 movement = Vector3.right * horizontalInput;

        //zczytaj z klawiatury oœ y
        float verticalInput = Input.GetAxisRaw("Vertical");

        //wylicz przesuniêcie w osi y i dodaj do istniej¹cego przesuniêcia w osi x
        movement += Vector3.forward * verticalInput;

        //normalizujemy wektor
        movement = movement.normalized;
        //poprawka na czas od ostatniej klatki
        movement *= Time.deltaTime;
        //pomnó¿ przez prêdkoœæ ruchu
        movement *= moveSpeed;

        //przesuñ gracza w osi x
        //transform.position += movement;
        
        //próbujemy u¿yc translate zamiast dodawac wspó³rzêdne
        transform.Translate(movement);

        
    }
    void OnCollisionEnter()
    {
        isGrounded = true;
    }
    //spróbujmy obejœæ problem z opóŸnieniem wejœcia poprzez przeniesienie go do update
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
