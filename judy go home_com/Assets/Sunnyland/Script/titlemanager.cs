using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlemanager : MonoBehaviour {

    private void Start()
    {
        manager.resetScore();
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("stage1");
    }
    
    public void OnClickQuit()
    {
        Application.Quit();
    }

}
