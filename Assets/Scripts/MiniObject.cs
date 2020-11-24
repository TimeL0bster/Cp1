using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MiniObject : MonoBehaviour
{
    [Header("Distance")]
    public int leight1 = 0;
    public int leight2 = 0;
    public Vector3 collOffsetHorizontal;
    public Vector3 collOffsetVertical;
    public Vector3 collOffsetHorizontal2;
    public Vector3 collOffsetVertical2;
    public Vector3 collOffsetHorizontal3;
    public Vector3 collOffsetVertical3;

    [Header("Sprites")]
    public Sprite[] miniObjectSprite;

    protected Image img;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        img = GetComponent<Image>();
    }

    protected void detechAdjacientSlot()
    {
        


    }

    protected void SwitchObjectPosition()
    {
        
    }

}
