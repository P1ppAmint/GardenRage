using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RagebarManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Slider slider;

    private static Slider Slider;

    private void Start()
    {
        //SetMaxRage(gameManager.rageActivationLimit);
    }



    private void SetMaxRage(int maxrage)
    {
        Slider.maxValue = maxrage;
        Slider.value = 0;
    }

    public static void SetRage(int rage)
    {
        Slider.value = rage;
    }
}
