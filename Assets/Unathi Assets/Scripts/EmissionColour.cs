using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionColour : MonoBehaviour
{
    public Color emissionColor = Color.yellow;
    public float intensity = 1.0f;

    private Material material;

    void Start()
    {
        // Get the material attached to this object
        material = GetComponent<Renderer>().material;

        // Enable emission
        material.EnableKeyword("_EMISSION");

        // Set the emission color and intensity
        SetEmission(emissionColor * intensity);
    }

    void SetEmission(Color color)
    {
        material.SetColor("_EmissionColor", color);
    }
}
