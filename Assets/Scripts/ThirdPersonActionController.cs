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

    private Transform _currentSelection = null;
    private Renderer _currentSelectionRenderer = null;
    private WaveObject _currentSelectionWave = null;
    private WaveObject[] waveObjects;
    private bool isAiming = false;
    public bool aimInputInitial = false; //flag to indicate first frame when aim is started
    public bool aimStopInputInitial = true; //flag to indicate first frame when aim is stopped

    [Header("Listening on Channels")]
    [SerializeField] IntEventChannelSO _updateValues = default;

    [Header("Broadcasting on Channels")]
    [SerializeField] IntEventChannelSO _retrieveValues = default;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        playerInput = GetComponent<PlayerInput>();

        waveObjects = FindObjectsOfType<WaveObject>();

    }


    private void OnEnable()
    {
        playerInput.actions["Aim"].performed += AimCameraAndHUD;
        playerInput.actions["CancelAim"].performed += DefaultCameraAndHUD;
        playerInput.actions["Shoot"].performed += HandleObjectSelection;
        playerInput.actions["ExitUI"].performed += CloseWaveUI;

        if(_updateValues != null)
        {
            _updateValues.OnEventRaised += UpdateSelectionAmpltitude;
        }
    }

    private void OnDisable()
    {
        playerInput.actions["Aim"].performed -= AimCameraAndHUD;
        playerInput.actions["CancelAim"].performed -= DefaultCameraAndHUD;
        playerInput.actions["Shoot"].performed -= HandleObjectSelection;
        playerInput.actions["ExitUI"].performed -= CloseWaveUI;
    }
    private void Start()
    {
        aimVirtualCamera.gameObject.SetActive(false);
        thirdPersonController.SetSensitivty(normalSensitivity);
        crossHair.gameObject.SetActive(false);
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
            _currentSelectionWave = selection.GetComponent<WaveObject>();
            if (_currentSelectionRenderer != null && _currentSelectionWave != null)
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

        if (_currentSelection && _currentSelectionWave)
        {
            isAiming = false;
            _currentSelectionRenderer.material.SetColor("_EmissionColor", selectionColor);

            waveToolMenu.gameObject.SetActive(true);

            //todo, send values to UI from current selection
            //might experience issues if the UI is not enabled in time
            _retrieveValues.RaiseEvent(_currentSelectionWave.Amplitude, _currentSelectionWave.Frequency, _currentSelectionWave.VerticalShift);
            
            Cursor.visible = true; //to-do, just use arrows to move to different text boxes?
            Cursor.lockState = CursorLockMode.Confined;
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

    private void UpdateSelectionAmpltitude(int amp, int freq, int vertical)
    {
        if(_currentSelection != null)
        {
            //call function from current selection that updates the values on the object
            _currentSelectionWave.UpdateValues(amp, freq, vertical);
        }
    }

}
