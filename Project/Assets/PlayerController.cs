using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float movementSpeed = 5f;
    float currentSpeed;
    Rigidbody rb;
    Vector3 direction;

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
    }

    void FixedUpdate()
    {
      rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }
}
