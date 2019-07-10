using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winbox : MonoBehaviour
{
    public int IsPlayer;

    public void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.layer == IsPlayer)
        {
            SceneManager.LoadScene("Maze 1");
        }
    }
}
