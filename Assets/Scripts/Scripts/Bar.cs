using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class Bar : MonoBehaviour
{
    public float maxLength = 4f;
    public Vector3 StartPosition;
    public MeshRenderer barSpriteRenderer;
    public BoxCollider boxCollider;
    public HingeJoint StartJoint;
    public HingeJoint EndJoint;

    private MeshRenderer my_renderer;

    private  Material startColor;
    public Material mouseOverColor;
    public Material barMaterialForce;
    public static bool enableDelete = false;
    private Rigidbody fristPoint;

    private Vector3 startPointPosition;
    private Vector3 endPointPosition;
    public static int barLength;
    public Rigidbody barRB;

    private float forceX;
    private float forceY;
    private float forceZ;
    public int materialNumber;
    public static BarCreator getBalance;

    public Text myText;


    /*
        Code which change material if mouse is over on object (only if delete mode is active)
        and when current break force is equal or greater then object break force
     
     */


    void Start()
    {
        startColor = GetComponent<Renderer>().material;
    }

    void OnMouseEnter()
    { 
        if (enableDelete)
        {
            GetComponent<Renderer>().material = mouseOverColor;
        }
    }

    void OnMouseExit()
    { 
        if (enableDelete)
        {
            GetComponent<Renderer>().material = startColor;
        }
    }
    void OnMouseDown()
    {
        if (enableDelete)
        {

            Vector3 test = this.gameObject.transform.localScale;
            Destroy(this.gameObject);
            
            if(this.materialNumber == 1)
            {
                BarCreator.backCoinsToBalance = (int)this.gameObject.transform.localScale.x * MoneyAndStats.roadCost;
            }
            else
            {
                BarCreator.backCoinsToBalance = (int)this.gameObject.transform.localScale.x * MoneyAndStats.metalCost;
            }
        }
    }


    //public GameObject test;
    public void UpdateCreatingBar(Vector3 ToPosition)
    {
        Vector3 boxColliderGetSize = boxCollider.size;
        Vector3 boxColliderGetPosition = boxCollider.center;

        Vector3 dir = ToPosition - StartPosition;
        dir.z = 0;

        float angle = Vector2.SignedAngle(Vector2.right, dir);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float length = dir.magnitude;

        barSpriteRenderer.transform.localScale = new Vector3(length, barSpriteRenderer.transform.localScale.y, barSpriteRenderer.transform.localScale.z);
        boxCollider.size = boxColliderGetSize;
        boxCollider.center = boxColliderGetPosition;
    }

    void Update()
    {
        try
        {
            if(enableDelete == false)
            {
                if (StartJoint.currentForce.magnitude >= StartJoint.breakForce / 2)
                {
                    GetComponent<Renderer>().material = barMaterialForce;
                }
                else
                {
                    GetComponent<Renderer>().material = startColor;
                }
            }
           
        }
        catch (IOException e)
        {
            Console.WriteLine("IOException source: {0}", e.Source);
        }
    }
}
