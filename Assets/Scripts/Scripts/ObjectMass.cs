using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMass : MonoBehaviour
{
    public GameObject Obj;
    public Rigidbody rbd;
    void Update()
    {
        rbd = GetComponent<Rigidbody>();
        float ObjScaleX = Mathf.Round(Obj.transform.localScale.x) * 2;
        rbd.mass = (float)ObjScaleX;
    }
}
