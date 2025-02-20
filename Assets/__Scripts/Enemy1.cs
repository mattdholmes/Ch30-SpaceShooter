﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    [Header("Set in Inspector")]
    public float waveFrequency = 2;
    public float waveWidth = 4;
    public float waveRotY = 45;
    private float x0;
    private float birthTime;
    private BoundsCheck bndCheck;

    private void Start()
    {
        
    }

    //void Awake()
    //{
    //    bndCheck = GetComponent<BoundsCheck>();
    //}

    //public Vector3 pos
    //{
    //    get
    //    {
    //        return (this.transform.position);

    //    }
    //    set
    //    {
    //        this.transform.position = value;

    //    }
    //}
    //void Update()
    //{
    //    Move();

    //    if (bndCheck != null && bndCheck.offDown)
    //    {

    //        if (pos.y < (bndCheck.camHeight) - bndCheck.camWidth)
    //        {
    //            Destroy(gameObject);
    //        }
    //    }
    //}

    public override void Move()
    {
        Vector3 tempPos = pos;
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;
        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);
        base.Move();
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        if (otherGO.tag == "ProjectileHero")
        {
            Destroy(otherGO);
            Destroy(gameObject);
        }
        else
        {
            print("Enemy hit by non-ProjectileHero: " + otherGO.name);
        }
    }

}
