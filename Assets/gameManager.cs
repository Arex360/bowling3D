using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameManager : MonoBehaviour
{
    public static int succesShots = 0;
    public static int lastScore = 0;

    public TextMeshPro score;
    public int hitShot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hitShot = succesShots;
        score.text = lastScore.ToString();
    }
}
