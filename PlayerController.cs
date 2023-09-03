using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public CharacterController controller;
    public Transform cam;
    public float sensivity;
    public float maxXrot;
    public float minXrot;
    private float currentXrot;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 dir = transform.right * x + transform.forward*z;
        dir.Normalize();
        dir *= speed * Time.deltaTime;
        controller.Move(dir);
    }
    void Look()
    {
        float x = Input.GetAxis("Mouse X") * sensivity;
        float y = Input.GetAxis("Mouse Y") * sensivity;

        transform.eulerAngles += Vector3.up * x;

        currentXrot += y;
        currentXrot = Mathf.Clamp(currentXrot, minXrot, maxXrot);
        cam.localEulerAngles = new Vector3(-currentXrot, 0.0f, 0.0f);
    
    
    }


}
