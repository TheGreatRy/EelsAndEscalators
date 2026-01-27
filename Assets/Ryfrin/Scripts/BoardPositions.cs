using System.Collections.Generic;
using UnityEngine;

public class BoardPositions : MonoBehaviour
{
    public List<Transform> AllPositions = new List<Transform>();
    
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
