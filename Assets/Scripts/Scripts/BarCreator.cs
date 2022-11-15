using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class BarCreator : MonoBehaviour, IPointerDownHandler
{
    bool BarCreationStarted = false;
    public Bar CurrentBar;
    public GameObject RoadInstance;
    public GameObject Road;
    public GameObject Beam;
    public Transform roadParent;
    public Point CurrentStartPoint;
    public Point CurrentEndPoint;
    public GameObject PointInstance;
    public Transform pointParent;
    public static bool BuildMode = true;
    public int price = 50;
    public Text myText;
    public Text minusMoney;
    public AudioSource RoadSound;
    public AudioSource MetalSound;
    public AudioSource music;
    public int minX;
    public int maxX;

    public static int backCoinsToBalance;

    public Rigidbody barRB;

    /*
        Main code to create constructions.
        This code create object like bar and road on mouse coordinates,
        change their position, rotationand, size
        and check if selected coordinates are correctly and free (doesn't exisit any object in selected position,  if exist then delete created bar) 
     */

    //Get coordinates from mouse position on click and create objects
    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left && BarCreationStarted == false && BuildMode == true){
            BarCreationStarted = true;
            Vector3 mousePosition = new Vector3(
                Mathf.RoundToInt(eventData.pointerCurrentRaycast.worldPosition.x),
                Mathf.RoundToInt(eventData.pointerCurrentRaycast.worldPosition.y),
                -4);
            if(mousePosition.x < minX){
                mousePosition.x = minX;
            }else if(mousePosition.x > maxX){
                mousePosition.x = maxX;
            }
            StartBarCreation(Vector3Int.RoundToInt(mousePosition));            
        }else{
            if (eventData.button == PointerEventData.InputButton.Left && BuildMode == true){                
                if (RoadInstance == Road){
                    RoadSound.Play();
                }else if (RoadInstance == Beam){
                    MetalSound.Play();
                } 
                FinishBarCreation(); 
            }
            else if (eventData.button == PointerEventData.InputButton.Left && BuildMode == false){
                BarCreationStarted = false;
                DeleteCurrentBar();
            }else if(eventData.button == PointerEventData.InputButton.Right){
                BarCreationStarted = false;
                DeleteCurrentBar();
            }
        }
    }

    //Create object in current position
    void StartBarCreation(Vector3 StartPosition) 
    {
        CurrentBar = Instantiate(RoadInstance, roadParent).GetComponent<Bar>();
        CurrentBar.transform.position = StartPosition;
        if (GameManager.AllPoints.ContainsKey(StartPosition)){
            CurrentStartPoint = GameManager.AllPoints[StartPosition];
        }else{
            CurrentStartPoint = Instantiate(PointInstance, StartPosition, Quaternion.identity, pointParent).GetComponent<Point>();
        }
        Vector3 testPosition = new Vector3(0, 0, 0);
        CurrentEndPoint = Instantiate(PointInstance, testPosition, Quaternion.identity, pointParent).GetComponent<Point>();
    }

    //Finish creating object 
    void FinishBarCreation() 
    {
        if (GameManager.AllPoints.ContainsKey(Vector3Int.RoundToInt(CurrentEndPoint.transform.position))) {
            Destroy(CurrentEndPoint.gameObject);
            CurrentEndPoint = GameManager.AllPoints[Vector3Int.RoundToInt(CurrentEndPoint.transform.position)];
        } else {
            GameManager.AllPoints.Add(Vector3Int.RoundToInt(CurrentEndPoint.transform.position), CurrentEndPoint);
        }
        Vector3 firstPosition = CurrentBar.StartPosition;
        Vector3 secondPosition = CurrentEndPoint.transform.position;
        if(secondPosition.x < minX){
            secondPosition.x = minX;
        }else if(secondPosition.x > maxX){
            secondPosition.x = maxX;
        }
        int positionX = (int)Math.Abs(firstPosition.x - secondPosition.x);
        int positionY = (int)Math.Abs(firstPosition.y - secondPosition.y);
        int length = (int)Math.Sqrt(Math.Pow(positionX, 2) + Math.Pow(positionY, 2));
        int balance = Int32.Parse(myText.text);
        int barPrice = price * length;
        int testprice = balance - barPrice;
        myText.text = testprice.ToString();
        CurrentBar.barRB.mass *= length;
        CurrentStartPoint.ConnectedBars.Add(CurrentBar);
        CurrentEndPoint.ConnectedBars.Add(CurrentBar);
        CurrentBar.StartJoint.connectedBody = CurrentStartPoint.rbd;
        CurrentBar.StartJoint.anchor = CurrentBar.transform.InverseTransformPoint(CurrentBar.StartPosition);
        CurrentBar.EndJoint.connectedBody = CurrentEndPoint.rbd;
        CurrentBar.EndJoint.anchor = CurrentBar.transform.InverseTransformPoint(Vector3Int.RoundToInt(CurrentEndPoint.transform.position));
        StartBarCreation(Vector3Int.RoundToInt(CurrentEndPoint.transform.position));
    }

    //Delete unnecessary objects
    void DeleteCurrentBar()
    {
        Destroy(CurrentBar.gameObject);
        Destroy(CurrentEndPoint.gameObject);
        if (CurrentStartPoint.ConnectedBars.Count == 0){
            Destroy(CurrentStartPoint.gameObject);
        }
    }


    // On start, set time to 0 and set sound volume
    void Start()
    {
         Time.timeScale = 0;
        RoadSound.volume = MoneyAndStats.musicVolume;
        MetalSound.volume = MoneyAndStats.musicVolume;
        music.volume = MoneyAndStats.musicVolume;
    }


    // In every frame, when create objects, change position and scale in real time 
    // and check that the length of the road is not greater than previously established
    private void Update()
    {    
        if(Bar.enableDelete == true){
            int balance = Int32.Parse(myText.text);
            balance += backCoinsToBalance;
            myText.text = balance.ToString();
            backCoinsToBalance = 0;
        }

        if(Time.timeScale == 1){
            BuildMode = false;
        }
       // Okreœlenie d³ugoœci drogi w czasie rzeczywistym
        if (BarCreationStarted == true){
            Vector3 test = (Vector3)Vector3Int.RoundToInt(CurrentStartPoint.transform.position);
            CurrentBar.StartPosition = test;
            Vector3 StartPositionPoint = (Vector3)Vector3Int.RoundToInt(CurrentBar.StartPosition);
            Vector3 firstPoint = (Vector3)Vector3Int.RoundToInt(CurrentBar.StartPosition);
            Vector3 EndPosition = (Vector3)Vector3Int.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (EndPosition.x < minX){
                EndPosition.x = minX;
            }else if(EndPosition.x > maxX){
                EndPosition.x = maxX;
            }
            EndPosition.z = -4;
            EndPosition.y -= 1;
            
            Vector3 Dir = EndPosition - StartPositionPoint;
            Vector3 ClampedPosition = CurrentBar.StartPosition + Vector3.ClampMagnitude(Dir, CurrentBar.maxLength);
            ClampedPosition.z = -4;
            StartPositionPoint = (Vector3)Vector3Int.RoundToInt(ClampedPosition);
            Vector3 testTwo = (Vector3)Vector3Int.FloorToInt(ClampedPosition);

            int positionX = (int)Math.Abs(firstPoint.x - testTwo.x);
            int positionY = (int)Math.Abs(firstPoint.y - testTwo.y);
            int length = (int)Math.Sqrt(Math.Pow(positionX, 2) + Math.Pow(positionY, 2));
            int balance = Int32.Parse(myText.text);
            if (price * length <= balance){
                CurrentEndPoint.transform.position = (Vector3)Vector3Int.FloorToInt(ClampedPosition);
                CurrentEndPoint.PointID = CurrentEndPoint.transform.position;
                CurrentBar.UpdateCreatingBar(testTwo);
                test.z = -4;
                CurrentBar.transform.position = test;
                if (length == 0){
                    minusMoney.text = "0";
                }else{
                    String minusPrice = "-" + (price * length).ToString();
                    minusMoney.text = minusPrice;
                }
            }
        }
        else{
            minusMoney.text = "0";
        }
    }
}


