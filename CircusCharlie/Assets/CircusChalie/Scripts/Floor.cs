using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �÷ξ Ŭ�������� ������ 
        // �������� ��Ʈ�� ����, �÷��̾� ��Ʈ�� ��ȿ
        if (other.tag == "Clear")
        {
            Debug.Log("������?");
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
