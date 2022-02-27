using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.black;
    
    TextMeshPro coordinateLabel;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    private void Awake()
    {
        coordinateLabel = GetComponent<TextMeshPro>();
        coordinateLabel.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
        ColorCoordinates();
    }
    
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            updateObjectName();
            
        }
        ColorCoordinates();
        ToggleLabels();
    }

  void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            coordinateLabel.enabled = !coordinateLabel.enabled;
        }
    }
    
    
    private void ColorCoordinates()
    {
        if(waypoint.IsPlaceable)
        {
            coordinateLabel.color = defaultColor;
        }
        else
        {
            coordinateLabel.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x =Mathf.RoundToInt(transform.parent.position.x /UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        coordinateLabel.text = coordinates.x +","+coordinates.y;
    }

    void updateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
