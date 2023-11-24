using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCamera : MonoBehaviour
{

      //players sensitivity
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

      //transform that we use to set the new orientation
    [SerializeField] private Transform orientation;

      //current rotation
    private float xRotation = 0;
    private float yRotation = 0;

      //the change between this frame and last frame
    float mouseX;
    float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        //mouse input code
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
          //confusing but let me break it down: mouse x and y are 2d space so y is up and down. rotation is 3d space so x is up and down. therefore xrot + mouseY bc they are both up and down!
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        
    }
}
