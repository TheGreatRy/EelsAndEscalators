using System.Collections.Generic;
using UnityEngine;

public class BoardPositions : MonoBehaviour
{
    public List<Transform> AllPositions = new List<Transform>();
    public Dictionary<int, string> TileCoordinates = new Dictionary<int, string>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform transform in GetComponentsInChildren<Transform>())
        {
            if (transform.CompareTag("Space"))
            {
                AllPositions.Add(transform);
            }
        }

        TileCoordinates.Add(6, "ES_Base");
        TileCoordinates.Add(15, "ES_Top");
        TileCoordinates.Add(2, "EL_Head");
        TileCoordinates.Add(7, "EL_Tail");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
