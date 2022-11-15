using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

//[ExecuteInEditMode]
public class Point : MonoBehaviour
{
    public bool Runtime = true;
    public Rigidbody rbd;
    public Vector3 PointID;
    public List<Bar> ConnectedBars;
    private Vector3 firstPoint;
    private Vector3 secondPoint;
    

    private void Start()
    {
        PointID = Vector3Int.RoundToInt(transform.position);
        if (GameManager.AllPoints.ContainsKey(PointID) == false) GameManager.AllPoints.Add(PointID, this);
        if (MoneyAndStats.selectMap == 0)
        {
            firstPoint = new Vector3(11, 6, -4);
            secondPoint = new Vector3(30, 6, -4);
        }else if (MoneyAndStats.selectMap == 1)
        {
            firstPoint = new Vector3(11, 10, -4);
            secondPoint = new Vector3(30, 9, -4);
        }


    }
    
    
    private void Awake()
    {
        
        PointID = Vector3Int.RoundToInt(transform.position);
        if (GameManager.AllPoints.ContainsKey(PointID) == false) GameManager.AllPoints.Add(PointID, this);
       
    }
    
       

    void Update()
    {
        for (int i = 0; i < ConnectedBars.Count; ++i)
        {
            
            if (ConnectedBars[i] == null)
            {
                ConnectedBars.RemoveAt(i);
            }
        }

        if (transform.hasChanged == true)
        {
            transform.hasChanged = false;

        }

        if (ConnectedBars.Count == 0 && Bar.enableDelete == true && PointID != firstPoint && PointID != secondPoint)
        {
            GameManager.AllPoints.Remove(Vector3Int.RoundToInt(PointID));
            Destroy(this.gameObject);
        }

    }
}
