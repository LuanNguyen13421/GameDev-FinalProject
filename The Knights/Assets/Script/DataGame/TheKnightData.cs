using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class TheKnightData
{
    public float[] position;
    public TheKnightData(Vector2 position)
    {
        this.position= new float[2];
        this.position[0]=position.x;
        this.position[1]=position.y;
    }

}
