using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    public void Next()
    {
        GlobalVariables.Next();
        // �� ��������
        //     GlobalVariables.MoveTurn[GlobalVariables.ListIndex].GetComponent<Move>().SetStepsRemain();
    }

}
