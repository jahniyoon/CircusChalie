using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStage : MonoBehaviour
{
    private float delayTime = 1f;
    public TMP_Text stageLoadText;



    void Start()
    {
        Invoke("LoadNextScene", delayTime);

        stageLoadText.text = string.Format("STAGE 0{0}", GameInfo.stage);

    }

    void LoadNextScene()
    {

        if (GameInfo.stage == 1)
        {
            GlobalFunc.LoadScene("Stage1Scene");
        }
        if (GameInfo.stage == 2)
        {
            GlobalFunc.LoadScene("Stage2Scene");
        }
    }
}
