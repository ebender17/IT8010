using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UI;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

public class ThirdPersonActionController : MonoBehaviour
{
    [Header("Camera Control")]
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;

    [Header("HUD")]
    [SerializeField] private Image crossHair;
    [SerializeField] private GameObject waveToolMenu;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private PlayerInput playerInput;

    [Header("Collision")]
    [SerializeField] private LayerMask layerMask;

    [Header("Colors")]
    public Color selectionColor;
    public Color highlightColor;

    private Transform _currentSelection;
    private Renderer _currentSelectionRenderer;
    private WaveObject[] waveObjects;
    private bool isAiming = false;
    public bool aimInputInitial = false; //flag to indicate first frame when aim is started
    public bool aimStopInputInitial = true; //flag to indicate first frame when aim is stopped

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        playerInput = GetComponent<PlayerInput>();

        waveObjects = FindObjectsOfType<WaveObject>();

    }

    private void Start()
    {
        aimVirtualCamera.gameObject.SetActive(false);
        thirdPersonController.SetSensitivty(normalSensitivity);
        crossHair.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        playerInput.actions["Aim"].performed += AimCameraAndHUD;
        playerInput.actions["CancelAim"].performed += DefaultCameraAndHUD;
        playerInput.actions["Shoot"].performed += HandleObjectSelection;
        playerInput.actions["ExitUI"].performed += CloseWaveUI;
    }

    private void OnDisable()
    {
        playerInput.actions["Aim"].performed -= AimCameraAndHUD;
        playerInput.actions["CancelAim"].performed -= DefaultCameraAndHUD;
        playerInput.actions["Shoot"].performed -= HandleObjectSelection;
        playerInput.actions["ExitUI"].performed -= CloseWaveUI;
    }

    // Update is called once per frame
    void Update()
    {

        if(isAiming == true)
        {
            SelectInteractable();
        }
    }


    private void AimCameraAndHUD(InputAction.CallbackContext context)
    {
        playerInput.SwitchCurrentActionMap("Tool");

        Debug.Log("Inside AimCameraAndHUD " + playerInput.currentActionMap);

        aimVirtualCamera.gameObject.SetActive(true);
        thirdPersonController.SetSensitivty(aimSensitivity);
        crossHair.gameObject.SetActive(true);

        InteractablesMaterial(highlightColor, 0.4f);

        isAiming = true;
    }

    private void DefaultCameraAndHUD(InputAction.CallbackContext context)
    {
        playerInput.SwitchCurrentActionMap("Player");

        Debug.Log("Inside Default Camera and HUD " + playerInput.currentActionMap);

        aimVirtualCamera.gameObject.SetActive(false);
        thirdPersonController.SetSensitivty(normalSensitivity);
        crossHair.gameObject.SetActive(false);

        InteractablesMaterial(highlightColor, 0);

        isAiming = false;

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
            _currentSelectionRenderer = selection.GetComponent<Renderer>();
            //var selectionRenderer = selection.GetComponent<Renderer>();
            if (_currentSelectionRenderer != null)
            {
                _currentSelectionRenderer.material.SetColor("_EmissionColor", selectionColor);
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
            }

        }
        
    }

    private void HandleObjectSelection(InputAction.CallbackContext context)
    {
        playerInput.SwitchCurrentActionMap("UI");

        Debug.Log("Inside Handle Object Selection " + playerInput.currentActionMap);

        if(_currentSelection)
        {
            isAiming = false;
            _currentSelectionRenderer.material.SetColor("_EmissionColor", selectionColor);

            waveToolMenu.gameObject.SetActive(true);

            Cursor.visible = true; //to-do, how to move cursor around screeen and register orrr do we use cursor at all?
            Cursor.lockState = CursorLockMode.Confined;
            //just use arrows to move to different text boxes?
        }
       
    }

    private void CloseWaveUI(InputAction.CallbackContext context)
    {
        playerInput.SwitchCurrentActionMap("Player");

        InteractablesMaterial(highlightColor, 0);

        waveToolMenu.gameObject.SetActive(false);
        Cursor.visible = false;
        _currentSelection = null;

    }
}
