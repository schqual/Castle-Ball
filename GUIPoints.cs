using UnityEngine;
using System.Collections;

public class GUIPoints : MonoBehaviour
{

    private int points;

    void OnGUI(){
        GUILayout.Label("Score: " + points.ToString());
	}

    public void increasePoints(int amount)
    {
        points += amount;
	}
}

