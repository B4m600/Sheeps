using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Brush : MonoBehaviour, IPointerDownHandler
{
    public Main Main;
    
    public void OnPointerDown(PointerEventData Test)
    {

        // Debug.Log(this.gameObject.GetComponent<Image>().color);
        if (this.gameObject.GetComponent<Image>().color == Color.white)
        {

            this.gameObject.transform.SetParent(Main.Fence.transform, false);
            for (int i = 0; i < 7; i++)
            {
                if (Main.List[i] == null)
                {
                    Main.List[i] = this.gameObject;
                    break;
                }
            }


            Main.Func_Main(tag = this.gameObject.tag, Main.Total[2], this.gameObject);


        }
        
    }



}
