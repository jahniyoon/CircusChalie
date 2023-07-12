using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRing : MonoBehaviour
{

    public GameObject scorezone;


    private void OnEnable()
    {
        scorezone.SetActive(true);

        //Debug.Log("스코어존이 생성되었을까?");

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
