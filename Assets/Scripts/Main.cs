using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Timers;

public static class RectTransformExtensions
{

    public static bool Overlaps(this RectTransform a, RectTransform b)
    {
        return a.WorldRect().Overlaps(b.WorldRect());
    }
    public static bool Overlaps(this RectTransform a, RectTransform b, bool allowInverse)
    {
        return a.WorldRect().Overlaps(b.WorldRect(), allowInverse);
    }

    public static Rect WorldRect(this RectTransform rectTransform)
    {
        Vector2 sizeDelta = rectTransform.sizeDelta;
        float rectTransformWidth = sizeDelta.x * rectTransform.lossyScale.x;
        float rectTransformHeight = sizeDelta.y * rectTransform.lossyScale.y;

        Vector3 position = rectTransform.position;
        return new Rect(position.x + rectTransformWidth * rectTransform.pivot.x, position.y - rectTransformHeight * rectTransform.pivot.y, rectTransformWidth, rectTransformHeight);
    }
}

public class Main : MonoBehaviour
{
    public Transform[] Overlapping;
    public GameObject SquareParent;
    public GameObject[] List;
    public GameObject Fence;
    public GameObject Win;
    public Text Score;

    public GridLayoutGroup Grid;
    public GameObject Test_1;
    public GameObject Test_2;

    public AudioSource source;


    // public GameObject[] Wools = new GameObject[3] { null, null, null };
    // public GameObject[] Brushs = new GameObject[3] { null, null, null };
    // public GameObject[] Scissorses = new GameObject[3] { null, null, null };
    public GameObject[][] Total = new GameObject[14][] {
        new GameObject[3], new GameObject[3], new GameObject[3],
        new GameObject[3], new GameObject[3], new GameObject[3],
        new GameObject[3], new GameObject[3], new GameObject[3],
        new GameObject[3], new GameObject[3], new GameObject[3],
        new GameObject[3], new GameObject[3]

    };

    public void Func_Main(string tag, GameObject[] Storage, GameObject Self)
    {

        
    }

    void Start()
    {
        Fresh();
    }



    public void Fresh()
    {
        Transform[] Squares = SquareParent.GetComponentsInChildren<Transform>();
        // Debug.Log($"Start_Length:{Squares.Length}");
        for (int i=0; i < Squares.Length; i++)
        {
            for (int j = i+1; j < Squares.Length; j++)
            {
                if (Squares[i].gameObject.tag != "SquareParent")
                {
                    bool isOverlap = RectTransformExtensions.Overlaps(Squares[i].GetComponent<RectTransform>(), Squares[j].GetComponent<RectTransform>());
                    if (isOverlap)
                    {

                        Squares[i].GetComponent<Image>().color = Color.grey;

                        Array.Resize(ref Overlapping, Overlapping.Length + 1);
                        for (int k=0; k < Overlapping.Length + 1; k++)
                        {
                            if (Overlapping[k] == null)
                            {
                                Overlapping[k] = Squares[i];
                                break;
                            }
                        }
                        


                    }
                    bool isInOverlaping = Array.Exists(Overlapping, e => e == Squares[i]);
                    // Debug.Log(isInOverlaping);
                    if (!isInOverlaping)
                    {
                        Squares[i].GetComponent<Image>().color = Color.white;
                    }
                }
            }
         
        
        }
        // Debug.Log($"End_Length:{Squares.Length}");
        if (Squares.Length <= 1)
        {
            Win.SetActive(true);
        }
        Score.text = $"ʣ�ࣺ{Squares.Length - 1}";
    }

    public void Refresh()
    {
        Transform[] Squares = SquareParent.GetComponentsInChildren<Transform>();
        for (int i = 0; i < Squares.Length; i++)
        {
            if (Squares[i].gameObject.tag != "SquareParent") Squares[i].GetComponent<Image>().color = Color.white;
        }
    }


    public void Reset()
    {
        SceneManager.LoadScene("Main");
    }

    void RemoveThreeCard(GameObject[] Storage)
    {
        Debug.Log(1);

    }

}
