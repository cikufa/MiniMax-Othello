using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tokencon : MonoBehaviour
{
    public string curColor;
    // Start is called before the first frame update
    void Start()
    {
        //curColor = gameObject.tag;
       // GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
		//UL
        /*if (gameObject.tag == "UL")
        {
            //y
            if ((gameflow.ULchange == "y") && (curColor == "b"))
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1); //wh
                gameObject.tag = "w";
            }
            else if ((gameflow.ULchange == "y") && (curColor == "w"))
            {
                GetComponent<SpriteRenderer>().color = new Color(0.1886792f, 0.1771093f, 0.1771093f); //black
                gameObject.tag = "b";
            }
            //r
            else if ((gameflow.ULchange == "r") && (curColor == "b"))
            {
                gameObject.tag = "b";
            }
            else if ((gameflow.ULchange == "r") && (curColor == "w"))
            {
                gameObject.tag = "w";
            } 
            //n

        }
		//U
        if (gameObject.tag == "U")
        {
            //y
            if ((gameflow.Uchange == "y") && (curColor == "b"))
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1); //wh
                gameObject.tag = "w";
            }
            else if ((gameflow.Uchange == "y") && (curColor == "w"))
            {
                GetComponent<SpriteRenderer>().color = new Color(0.1886792f, 0.1771093f, 0.1771093f); //black
                gameObject.tag = "b";
            }
            //r
            else if ((gameflow.Uchange == "r") && (curColor == "b"))
            {
                gameObject.tag = "b";
            }
            else if ((gameflow.Uchange == "r") && (curColor == "w"))
            {
                gameObject.tag = "w";
            } 
            //n

        }
		//UR
        if (gameObject.tag == "UR")
        {
            //y
            if ((gameflow.URchange == "y") && (curColor == "b"))
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1); //wh
                gameObject.tag = "w";
            }
            else if ((gameflow.URchange == "y") && (curColor == "w"))
            {
                GetComponent<SpriteRenderer>().color = new Color(0.1886792f, 0.1771093f, 0.1771093f); //black
                gameObject.tag = "b";
            }
            //r
            else if ((gameflow.URchange == "r") && (curColor == "b"))
            {
                gameObject.tag = "b";
            }
            else if ((gameflow.URchange == "r") && (curColor == "w"))
            {
                gameObject.tag = "w";
            } 
            //n

        }
		//R
        if (gameObject.tag == "R")
        {
            //y
            if ((gameflow.Rchange == "y") && (curColor == "b"))
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1); //wh
                gameObject.tag = "w";
            }
            else if ((gameflow.Rchange == "y") && (curColor == "w"))
            {
                GetComponent<SpriteRenderer>().color = new Color(0.1886792f, 0.1771093f, 0.1771093f); //black
                gameObject.tag = "b";
            }
            //r
            else if ((gameflow.Rchange == "r") && (curColor == "b"))
            {
                gameObject.tag = "b";
            }
            else if ((gameflow.Rchange == "r") && (curColor == "w"))
            {
                gameObject.tag = "w";
            } 
            //n

        }
		//DR
        if (gameObject.tag == "DR")
        {
            //y
            if ((gameflow.DRchange == "y") && (curColor == "b"))
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1); //wh
                gameObject.tag = "w";
            }
            else if ((gameflow.DRchange == "y") && (curColor == "w"))
            {
                GetComponent<SpriteRenderer>().color = new Color(0.1886792f, 0.1771093f, 0.1771093f); //black
                gameObject.tag = "b";
            }
            //r
            else if ((gameflow.DRchange == "r") && (curColor == "b"))
            {
                gameObject.tag = "b";
            }
            else if ((gameflow.DRchange == "r") && (curColor == "w"))
            {
                gameObject.tag = "w";
            } 
            //n

        }
		//D
        if (gameObject.tag == "D")
        {
            //y
            if ((gameflow.Dchange == "y") && (curColor == "b"))
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1); //wh
                gameObject.tag = "w";
            }
            else if ((gameflow.Dchange == "y") && (curColor == "w"))
            {
                GetComponent<SpriteRenderer>().color = new Color(0.1886792f, 0.1771093f, 0.1771093f); //black
                gameObject.tag = "b";
            }
            //r
            else if ((gameflow.Dchange == "r") && (curColor == "b"))
            {
                gameObject.tag = "b";
            }
            else if ((gameflow.Dchange == "r") && (curColor == "w"))
            {
                gameObject.tag = "w";
            } 
            //n

        }
		//DL
        if (gameObject.tag == "DL")
        {
            //y
            if ((gameflow.DLchange == "y") && (curColor == "b"))
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1); //wh
                gameObject.tag = "w";
            }
            else if ((gameflow.DLchange == "y") && (curColor == "w"))
            {
                GetComponent<SpriteRenderer>().color = new Color(0.1886792f, 0.1771093f, 0.1771093f); //black
                gameObject.tag = "b";
            }
            //r
            else if ((gameflow.DLchange == "r") && (curColor == "b"))
            {
                gameObject.tag = "b";
            }
            else if ((gameflow.DLchange == "r") && (curColor == "w"))
            {
                gameObject.tag = "w";
            } 
            //n

        }
		//L
        if (gameObject.tag == "L")
        {
            //y
            if ((gameflow.Lchange == "y") && (curColor == "b"))
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1); //wh
                gameObject.tag = "w";
            }
            else if ((gameflow.Lchange == "y") && (curColor == "w"))
            {
                GetComponent<SpriteRenderer>().color = new Color(0.1886792f, 0.1771093f, 0.1771093f); //black
                gameObject.tag = "b";
            }
            //r
            else if ((gameflow.Lchange == "r") && (curColor == "b"))
            {
                gameObject.tag = "b";
            }
            else if ((gameflow.Lchange == "r") && (curColor == "w"))
            {
                gameObject.tag = "w";
            } 
            //n

        }*/
      
    }
}
