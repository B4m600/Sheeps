using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


public class Card : MonoBehaviour, IPointerDownHandler
{
    public Main Main;

    public int MyIndex;

    public void OnPointerDown(PointerEventData Test)
    {
        Main.source.Play();
        if (this.gameObject.GetComponent<Image>().color == Color.white && this.gameObject.GetComponent<RectTransform>().parent.tag == "SquareParent")
        {
            // Debug.Log(this.gameObject.GetComponent<RectTransform>().parent.tag);
            // this.gameObject.transform.SetParent(Main.Fence.transform, false);
            Move(this.gameObject);
            
            for (int i = 0; i < 7; i++)
            {
                if (Main.List[i] == null)
                {
                    Main.List[i] = this.gameObject;
                    break;
                }
            }


            // Main.Func_Main(this.gameObject.tag, Main.Total[MyIndex], this.gameObject);

        }


    }


    public void Move(GameObject Object)
    {
        int nullCount = 0;
        foreach (GameObject i in Main.List)
        {
            if (i == null)
            {
                nullCount++;
            }
        }
        float Len = 7 - nullCount;
        float Gap = Main.Test_2.transform.position.x - Main.Test_1.transform.position.x;
        // Debug.Log($"Len:{Len};Gap:{Gap};");

        Vector3 Pos_Raw = Object.transform.position;
        // Debug.Log($"Row: {Pos_Raw} / {Object.transform.position.x}");
        // Object.SetActive(false);

        // Object.transform.SetParent(Main.Fence.transform, false);
        
        
        // Vector3 Pos_Aft = Object.GetComponent<RectTransform>().position;
        // int CellX, CellY;
        // Vector3 Pos_End = Main.Grid.CellToWorld(new Vector3Int(0, 0, 0));

        // Main.Grid.GetCell(transform, out CellX, out CellY);

        // Vector3 Pos_End = new Vector3(CellX, CellY, 0f);
        // Debug.Log($"----------------{Pos_Aft} == {Pos_End}---:----{Pos_Aft == Pos_End}------------------------");



        // Vector3 Pos_Aft = new Vector3(162f, -181f, 0f);

        // Pos_Temp = Pos_Raw;

        // Debug.Log($"Aft: {Pos_Aft} / LocalX:{Object.GetComponent<RectTransform>().localPosition.x}");


        Object.transform.position = Pos_Raw;

        // Object.SetActive(true);
        iTween.MoveTo(Object, iTween.Hash("position", new Vector3(Main.Test_1.transform.position.x + Len * Gap, Main.Test_1.transform.position.y, 0f), "time", 0.5f, "easetype", iTween.EaseType.linear, "oncomplete", "OnMoveFinished", "oncompleteparams", Object));

        

        // Object.transform.SetParent(Main.Fence.transform, false);

    }



    void OnMoveFinished(GameObject Object)
    {
        Object.transform.SetParent(Main.Fence.transform, false);
        Debug.Log("Îßºþ~");
        GameObject[] Storage = Main.Total[MyIndex];
        for (int i = 0; i < 7; i++)
        {
            if (Main.List[i] != null) if (Main.List[i].tag == tag)
                {

                    for (int j = 0; j < 3; j++)
                    {
                        if (Storage[j] == null)
                        {
                            Storage[j] = Main.List[i];
                            // Debug.Log("Filled;");
                            break;
                        }
                    }
                }
        }
        if (!Array.Exists(Storage, e => e == null))
        {

            int a = Array.IndexOf(Main.List, Storage[0]);
            int b = Array.IndexOf(Main.List, Storage[1]);
            int c = Array.IndexOf(Main.List, Storage[2]);
            Main.List.SetValue(null, a);
            Main.List.SetValue(null, b);
            Main.List.SetValue(null, c);
            Storage[0].SetActive(false);
            Storage[1].SetActive(false);
            Storage[2].SetActive(false);

            /*
            Timer timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler((object source, ElapsedEventArgs e) => 
            {
                Debug.Log(0);
                Storage[0].SetActive(false);
                Storage[1].SetActive(false);
                Storage[2].SetActive(false);
                Debug.Log(1);
                // RemoveThreeCard(Storage); 
            });
            timer.AutoReset = false;
            timer.Enabled = true;
            */





            // Invoke("RemoveThreeCard", 1f);
            // RemoveThreeCard(Storage);
            // Debug.Log("Cleared;");
            Array.Fill(Storage, null);
            // Debug.Log($"Condition1 [0]:{Storage[0]}---[1]:{Storage[1]}---[2]:{Storage[2]}");
        }
        else
        {
            // Debug.Log($"Condition2 [0]:{Storage[0]}---[1]:{Storage[1]}---[2]:{Storage[2]}");
            Array.Fill(Storage, null);
        }


        if (!Array.Exists(Main.List, e => e == null)) Main.Reset();


        Main.Grid.enabled = false;
        Main.Grid.enabled = true;

        Main.Refresh();
        Main.Fresh();
    }






}
