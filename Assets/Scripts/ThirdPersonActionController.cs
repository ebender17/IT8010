using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UI;

public class ThirdPersonActionController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;

    [SerializeField] private Image crossHair;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;

    // Start is called before the first frame update
    void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivty(aimSensitivity);
            crossHair.gameObject.SetActive(true);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivty(normalSensitivity);
            crossHair.gameObject.SetActive(false);
        }
    }
}
