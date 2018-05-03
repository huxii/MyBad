﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallTransitionControl : TransitionEffectControl
{
    bool reverse = false;
    Material mat;
    float alphaCutoff;

    // Use this for initialization
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        alphaCutoff = mat.GetFloat("_Cutoff");
        timer = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            mat.SetFloat("_Cutoff", timer);
            if (reverse)
            {
                timer -= Time.deltaTime * speed;
                if (timer <= alphaCutoff)
                {
                    End();
                }
            }
            else
            {
                timer += Time.deltaTime * speed;
                if (timer >= alphaCutoff)
                {
                    End();
                }

            }
        }
    }

    public override void Play(TransitionData data = null)
    {
        start = true;
        reverse = false;
    }

    public override void Reverse(TransitionData data = null)
    {
        start = true;
        reverse = true;
    }
}