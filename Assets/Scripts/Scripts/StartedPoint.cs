using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartedPoint : MonoBehaviour
{
    public Point obj;
    public static Vector3 PointPoz;
    
    void Start()
    {
        PointPoz = Vector3Int.RoundToInt(transform.position);
        if (GameManager.AllPoints.ContainsKey(PointPoz) == false) GameManager.AllPoints.Add(PointPoz, obj);
    }
    
    
}
