using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textWon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameflow.wscore + gameflow.bscore == 64){
			if(gameflow.wscore > gameflow.bscore){
				GetComponent<TextMesh>().text = "W Won";
			}
			else{
				GetComponent<TextMesh>().text = "B Won";
			}
		}
		else{
				GetComponent<TextMesh>().text = "";
			}
    }
}
