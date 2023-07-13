using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플로어가 클리어존을 만나면 
        // 스테이지 컨트롤 해제, 플레이어 컨트롤 유효
        if (other.tag == "Clear")
        {
            Debug.Log("만났나?");
            PlayerController.isClearArea = true;
            StageController.isClearZone = false; 
        }


        //else
        //    PlayerController.isClearArea = false;
        //     StageController.isClearZone = true; ;


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
