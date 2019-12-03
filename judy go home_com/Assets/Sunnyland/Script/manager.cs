using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

    static int score = 0;
	
    public static void setScore(int value)
    {
        score += value;
    }
    public static int getScore()
    {
        return score;
    }
    public static int resetScore()
    {
        score = 0;
        return score;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUIStyle style = new GUIStyle();

        style.fontSize = h * 2 / 30; 
        GUILayout.Label("Score : " + score.ToString(),style);

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();


    }
}
