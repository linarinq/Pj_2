using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float movementSpeed = 5f;
    float currentSpeed;
    Rigidbody rb;
    Vector3 direction;

    [SerializeField] float shiftSpeed = 10f;
  	[SerializeField] float jumpForce = 7f;
  	bool isGrounded = true;

    // Audio
  	[SerializeField] AudioSource characterSounds;	[SerializeField] AudioClip jump;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
      float moveHorizontal =  Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
      direction = transform.TransformDirection(direction);

      if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
      {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        isGrounded = false;
      }

      if(Input.GetKeyDown(KeyCode.LeftShift))
      {
        currentSpeed = shiftSpeed;
      }

      if(Input.GetKeyUp(KeyCode.LeftShift))
      {
        currentSpeed = movementSpeed;
      }
    }

    void FixedUpdate()
    {
      rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
      isGrounded = true;
    }
}
