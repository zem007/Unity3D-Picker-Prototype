﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public GUIText scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        scoreGT = scoreGo.GetComponent<GUIText>();
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll) 
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple") {
            Destroy(collidedWith);
        }

        //记录获得分数
        int score = int.Parse(scoreGT.text);
        score += 100;
        scoreGT.text = score.ToString();

        //监视最高分
        if(score > HighScore.score) {
            HighScore.score = score;
        }
    }
}
