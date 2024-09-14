using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orientation;
    public Camera playerCamera;
    private float xRotation;
    private float yRotation;
    private float verticalLookRotation;
    public GameObject cameraPos;
    private bool DisabledCamera = false;
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (playerCamera.enabled)
        {
            playerCamera.transform.parent = null;
        }
    }
    void Start()
    {
        GameEventManger.instance.playerEvents.OnChooseMimic += DisableCamera;
    }
    void OnDisable()
    {
        GameEventManger.instance.playerEvents.OnChooseMimic -= DisableCamera;
    }
    private void DisableCamera()
    {
        DisabledCamera = !DisabledCamera;
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        Cursor.visible = !Cursor.visible;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (!DisabledCamera)
        {
            playerCamera.transform.position = cameraPos.transform.position;
            playerCamera.transform.rotation = cameraPos.transform.rotation;

            //look();

            look2();
        }

    }
    public void look()
    {
        orientation.gameObject.transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * sensX);
        cameraPos.gameObject.transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * sensX);


        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * sensY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraPos.gameObject.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }
    public void look2()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        //Kan vara så att man behöver ta bort time.deltatime ifall man får camera problem, eller byta ut det mot fixedtime.deltatime typ

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraPos.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
