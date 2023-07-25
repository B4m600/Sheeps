using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Scissors : MonoBehaviour, IPointerDownHandler
{
    public Main Main;
    
    public void OnPointerDown(PointerEventData Test)
    {
        // Main.Overlapping.SetValue(null, Array.IndexOf(this.gameObject.GetComponent<>))
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


            Main.Func_Main(tag = this.gameObject.tag, Main.Total[1], this.gameObject);

        }

        
    }



}
