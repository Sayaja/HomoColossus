using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour {

    private void Start()
    {
        Debug.Log("wawan1");
    }

    private void Update()
    {
        
    }

    
    public void LoadScene()
{
        Debug.Log("wawan");
    //SceneManager.LoadScene("AR");
       
        //SceneManager.LoadScene(1, LoadSceneMode.Single);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("AR"));
    }
}
