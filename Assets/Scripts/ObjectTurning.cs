using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectTurning : MonoBehaviour
{
    protected Vector3 lastPos;
    public Camera UICam;
    public Camera PlayerCam;
    public LayerMask layerMask;
    public GameObject currentSelected;
    private Vector3 SelectedTransform;
    private Quaternion SelectedRotation;
    public Transform inspectPos;
    RaycastHit hit;

    public float RotateSpeed = 2;
    public float deltaRotationX;
    public float deltaRotationY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (currentSelected != null)
        {
            deltaRotationX = -Input.GetAxis("Mouse X");
            deltaRotationY = Input.GetAxis("Mouse Y");

            if (Input.GetMouseButton(0))
            {
                currentSelected.transform.rotation = Quaternion.AngleAxis(deltaRotationX * RotateSpeed, transform.up) *
                Quaternion.AngleAxis(deltaRotationY * RotateSpeed, transform.right) *
                currentSelected.transform.rotation;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SelectItem();
        }
    }
    public void SelectItem()
    {

        if (currentSelected == null)
        {
            if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, 20f, layerMask))
            {

                SelectedTransform = hit.collider.gameObject.transform.position;
                SelectedRotation = hit.collider.gameObject.transform.rotation;
                currentSelected = hit.collider.gameObject;
                currentSelected.transform.position = inspectPos.position;
                GameEventManger.instance.playerEvents.ChooseMimic();
            }
        }
        else
        {
            currentSelected.transform.position = SelectedTransform;
            currentSelected.transform.rotation = SelectedRotation;
            currentSelected = null;
            GameEventManger.instance.playerEvents.ChooseMimic();
        }
    }
}
