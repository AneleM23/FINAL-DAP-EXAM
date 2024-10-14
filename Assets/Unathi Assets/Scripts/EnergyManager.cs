using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    public float maxEnergy = 100f;      // Maximum energy the player can have
    public float currentEnergy;         // Current energy the player has
    public float energyRegenRate = 5f;  // Rate at which energy refills per second

    // Event to notify when energy changes (useful for updating UI)
    public delegate void OnEnergyChanged(float currentEnergy);
    public static event OnEnergyChanged EnergyChanged;

    public Slider slider;

    private void Start()
    {
        // Initialize the player's energy to the maximum at the start
        currentEnergy = maxEnergy;
        slider.maxValue = maxEnergy;
    }

    private void Update()
    {
        // Regenerate energy over time, up to the maximum limit
        if (currentEnergy < maxEnergy)
        {
            currentEnergy += energyRegenRate * Time.deltaTime;
            currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);

            // Notify listeners (e.g., UI) about the energy update
            EnergyChanged?.Invoke(currentEnergy);
        }

        slider.value = currentEnergy;

        if (currentEnergy >= maxEnergy)
        {
            slider.gameObject.SetActive(false);
        }
        else
        {
            slider.gameObject.SetActive(true);
        }
    }

    // Function to spend energy for a mission or any other action
    public bool SpendEnergy(float amount)
    {
        if (currentEnergy >= amount)
        {
            currentEnergy -= amount;
            EnergyChanged?.Invoke(currentEnergy);
            return true; // Enough energy to perform the action
        }
        else
        {
            return false; // Not enough energy
        }
    }

    // Function to refill energy by a specified amount (e.g., reward or power-up)
    public void RefillEnergy(float amount)
    {
        currentEnergy += amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
        EnergyChanged?.Invoke(currentEnergy);
    }

    // Function to check if the player has enough energy for a mission
    public bool HasEnoughEnergy(float requiredAmount)
    {
        return currentEnergy >= requiredAmount;
    }
}
