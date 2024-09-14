using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectTurning : MonoBehaviour
{
    public Camera PlayerCam;
    public LayerMask layerMask;
    private GameObject currentSelected;
    private Vector3 SelectedTransform;
    private Quaternion SelectedRotation;
    public Transform inspectPos;

    public float RotateSpeed = 2;
    private float deltaRotationX;
    private float deltaRotationY;
    void Start()
    {
        GameEventManger.instance.playerEvents.OnMenuChoice += PutDown;
    }
    void OnDisable()
    {
        GameEventManger.instance.playerEvents.OnMenuChoice -= PutDown;
    }
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
            RaycastHit hit;

            if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, 20f, layerMask))
            {
                PickUp(hit);
            }
        }
        else
        {
            PutDown(false);
        }
    }
    public void PickUp(RaycastHit hit)
    {
        SelectedTransform = hit.collider.gameObject.transform.position;
        SelectedRotation = hit.collider.gameObject.transform.rotation;
        currentSelected = hit.collider.gameObject;
        currentSelected.transform.position = inspectPos.position;
        GameEventManger.instance.playerEvents.ChooseMimic();
    }
    public void PutDown(bool ShouldKill)
    {
        if (ShouldKill){
            Destroy(currentSelected.gameObject);
        }
        if (currentSelected != null)
        {
            currentSelected.transform.position = SelectedTransform;
            currentSelected.transform.rotation = SelectedRotation;
        }
        currentSelected = null;
        GameEventManger.instance.playerEvents.ChooseMimic();
    }
}
