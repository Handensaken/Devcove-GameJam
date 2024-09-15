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
    public GameObject interactText;
    private GameObject outlineObject;

    public float RotateSpeed = 2;
    public float reach = 5f;
    private float deltaRotationX;
    private float deltaRotationY;
    [Header("Outline")]
    public int OutlineWidth;
    Color outlineColor = Color.white;
    Outline hitOutline;
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
            if (interactText != null)
            {
                interactText.SetActive(false);
            }
            deltaRotationX = -Input.GetAxis("Mouse X");
            deltaRotationY = Input.GetAxis("Mouse Y");

            if (Input.GetMouseButton(0))
            {
                currentSelected.transform.rotation = Quaternion.AngleAxis(deltaRotationX * RotateSpeed, transform.up) *
                Quaternion.AngleAxis(deltaRotationY * RotateSpeed, transform.right) *
                currentSelected.transform.rotation;
            }
        }
        else
        {

            RaycastHit hit;

            if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, reach, layerMask))
            {
                if (outlineObject != null && outlineObject != hit.transform.gameObject)
                {
                    hitOutline.enabled = false;
                }
                hitOutline = hit.transform.gameObject.GetComponent<Outline>();
                if (interactText != null)
                {
                    interactText.SetActive(true);
                }
                if (hitOutline != null)
                {
                    hitOutline.enabled = true;
                }
                else
                {
                    hitOutline = hit.transform.gameObject.AddComponent<Outline>();
                    hitOutline.enabled = true;
                    hitOutline.OutlineColor = Color.white;
                    hitOutline.OutlineWidth = OutlineWidth;
                }
                outlineObject = hit.transform.gameObject;
            }
            else
            {
                if (interactText != null)
                {
                    interactText.SetActive(false);
                }
                if (hitOutline != null)
                {
                    hitOutline.enabled = false;
                }
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
        currentSelected.transform.position = new Vector3(1000, 1000, 1000);
        GameEventManger.instance.playerEvents.ChooseMimic();
    }
    public void PutDown(bool ShouldKill)
    {
        if (ShouldKill)
        {
            if (currentSelected.GetComponent<Mimic>().isMimic == false)
            {
                GameEventManger.instance.playerEvents.DestroyedNonMimic();
            }
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
