using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    TextMeshPro coordinateLabel;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        coordinateLabel = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            updateObjectName();
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
