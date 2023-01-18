using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    static public List<GameObject> MoveTurn = new List<GameObject>();
    static public int ListIndex = -1;
    static public int AddNew(GameObject gameObject)
    {
        MoveTurn.Add(gameObject);
        return ListIndex += 1;
    }
}
