using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Wool : MonoBehaviour, IPointerDownHandler
{
    public Main Main;

    public string ThisTag;

    public int MyIndex;

    public void OnPointerDown(PointerEventData Test)
    {
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


            Main.Func_Main(tag = ThisTag, Main.Total[0], this.gameObject);

        }

        
    }




}
