using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void onButtonClick(string level) { 
        SceneManager.LoadScene(level); 
    } 
}
