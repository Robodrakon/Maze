using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Winner : MonoBehaviour
{
    public int IsPlayer;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == IsPlayer)
        {
            SceneManager.LoadScene("main menu 1");
        }
    }








}
