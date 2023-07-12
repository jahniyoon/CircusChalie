using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Dead")
        {
            Debug.Log("Á¡¼ö¸¦ È¹µæÇß³ª?");

            //GameManager.instance.DistanceIs();

        }
    }
}
