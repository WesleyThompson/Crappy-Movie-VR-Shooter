using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Purpose: Output the bounding box measurement of an object's mesh renderer to the console.
/// </summary>
public class MeshMeasurer : MonoBehaviour {

    public enum Unit { METERS, CENTIMETERS, MILLIMETERS};
    [SerializeField] private Unit measurementUnits = Unit.METERS;

	private void Start () {
        Measure();
    }

    private void Update()
    {
        if(transform.hasChanged)
        {
            Measure();
        }
    }

    private void Measure()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.LogError("No mesh renderer attached to object.");
            this.enabled = false;
            return;
        }

        float multiplier = 0;
        string measurementString = "";
        switch (measurementUnits)
        {
            case Unit.METERS:
                multiplier = 1;
                measurementString = "m";
                break;

            case Unit.CENTIMETERS:
                multiplier = 100;
                measurementString = "cm";
                break;

            case Unit.MILLIMETERS:
                multiplier = 1000;
                measurementString = "mm";
                break;
        }

        Debug.Log(gameObject.name
            + " x:" + GetComponent<MeshRenderer>().bounds.size.x * multiplier + measurementString
            + " y:" + GetComponent<MeshRenderer>().bounds.size.y * multiplier + measurementString
            + " z:" + GetComponent<MeshRenderer>().bounds.size.z * multiplier + measurementString);
    }
}
