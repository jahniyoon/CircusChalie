using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Clear")
        {
            Debug.Log("플로어 클리어 만남");
            PlayerController.isClearArea = true;
            StageController.isClearArea = false; ;
        }
        else
        PlayerController.isClearArea = false;
        StageController.isClearArea = true; ;


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
