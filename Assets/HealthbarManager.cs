using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarManager : MonoBehaviour
{
    [SerializeField]
    private EntityStats stats;
    [SerializeField]
    private Slider slider;

    private static Slider Slider;

    private void Start()
    {
        Slider = slider;
        SetMaxHealth(stats.Health);
    }
    
    private void SetMaxHealth(int maxhealth)
    {
        Slider.maxValue = maxhealth;
        Slider.value = maxhealth;
    }

    public static void SetHealth(int health)
    {
        Slider.value = health;
    }
}
