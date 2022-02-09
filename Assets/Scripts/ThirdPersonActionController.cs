using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UI;

public class ThirdPersonActionController : MonoBehaviour
{
    [Header("Camera Control")]
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;

    [Header("HUD")]
    [SerializeField] private Image crossHair;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;

    [Header("Collision")]
    [SerializeField] private LayerMask layerMask;

    [Header("Colors")]
    public Color selectionColor;
    public Color highlightColor;

    private Transform _currentSelection;
    private WaveObject[] waveObjects;
    public bool aimInputInitial = false; //flag to indicate first frame when aim is started
    public bool aimStopInputInitial = true; //flag to indicate first frame when aim is stopped

    // Start is called before the first frame update
    void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();

        waveObjects = FindObjectsOfType<WaveObject>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleAim();
    }

    private void HandleAim()
    {
        if (starterAssetsInputs.aim)
        {
            SelectInteractable();

            if (aimInputInitial == true) //use this flag to call these functions only one time when input is held
            {
                aimVirtualCamera.gameObject.SetActive(true);
                thirdPersonController.SetSensitivty(aimSensitivity);
                crossHair.gameObject.SetActive(true);

                InteractablesMaterial(highlightColor, 0.4f);

                aimInputInitial = false;
                aimStopInputInitial = true;
            }

        }
        else if(!starterAssetsInputs.aim)
        {
            if(aimStopInputInitial == true) //use this flag to call these functions only one time when input is not held
            {
                aimVirtualCamera.gameObject.SetActive(false);
                thirdPersonController.SetSensitivty(normalSensitivity);
                crossHair.gameObject.SetActive(false);

                InteractablesMaterial(highlightColor, 0);

                aimInputInitial = true;
                aimStopInputInitial = false;
            }
            
        }
    }
    
    private void SelectInteractable()
    {
        //Deselection when move cursor off of target
        if (_currentSelection != null)
        {
            var selectionRenderer = _currentSelection.GetComponent<Renderer>();
            selectionRenderer.material.SetColor("_EmissionColor", highlightColor);
            _currentSelection = null;
        }

        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material.SetColor("_EmissionColor", selectionColor);
            }
            _currentSelection = selection;
        }
    }

    private void InteractablesMaterial(Color color, float amount)
    {
        if(waveObjects != null)
        {
            foreach (WaveObject obj in waveObjects)
            {
                obj.GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
                obj.GetComponent<Renderer>().material.SetFloat("_EmissionAmount", amount);

                Debug.Log("Changing interactables material");
            }

        }
        
    }
}
