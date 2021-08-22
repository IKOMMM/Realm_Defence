using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;


    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WaypointHandler waypoint;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        waypoint = GetComponentInParent<WaypointHandler>();
        //DisplayCoordinates();

    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            //DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }
                
        LabelColorSetter();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void LabelColorSetter()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }

    }
    /*void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }
    */

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
