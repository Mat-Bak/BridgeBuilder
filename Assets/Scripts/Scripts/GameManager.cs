using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Dictionary<Vector3, Point> AllPoints = new Dictionary<Vector3, Point>();
    
    void Awake()
    {
        AllPoints.Clear();
    }
    
   
}

