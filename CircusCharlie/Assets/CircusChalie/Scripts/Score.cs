using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
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


        if (other.tag == "Player" && StageController.isClear == false && StageController.isDead == false)
        {
            //Debug.Log("Á¡¼ö¸¦ È¹µæÇß³ª?");

            Audio audio = FindObjectOfType<Audio>();
            audio.CoinSound();

            GameManager.instance.AddScore(500);
            gameObject.SetActive(false);

        }
    }
}
