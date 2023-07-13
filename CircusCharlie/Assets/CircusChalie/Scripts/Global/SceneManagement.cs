using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public void ChangeTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void ChangeStage1Scene()
    {
        SceneManager.LoadScene("Stage1Scene");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Stage1Scene");
        }

    }

}
