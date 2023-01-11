using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class TheKnightData
{

    private float expChar1;
    public float expChar2;
    public float expChar3;
    public int sceneIndex = 0;
    public float getChar1()
    {
        Debug.Log("Archer Exp: " + expChar1);
        return expChar1;
    }
    public float getChar2()
    {
        Debug.Log("Mage Exp: " + expChar2);
        return expChar2;
    }
    public float getChar3()
    {
        Debug.Log("Soldier Exp: " + expChar3);
        return expChar3;
    }
    public int getSceneIndex() { return sceneIndex; }
    public TheKnightData(float expChar1, float expChar2, float expChar3, int sceneIndex)
    {
        this.expChar1 = expChar1;
        this.expChar2 = expChar2;
        this.expChar3 = expChar3;
        this.sceneIndex = sceneIndex;
    }

}
