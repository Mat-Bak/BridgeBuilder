using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class objectTrigger : MonoBehaviour
{
    public bool finish = false;

    // Show finish windown when user get to the finish

    public void OnTriggerEnter(Collider other)
    {

        finish = true;
        SceneManager.LoadScene("Finish");

    }



}
