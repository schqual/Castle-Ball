using UnityEngine;
using System.Collections;

public class GUIMenu : MonoBehaviour {

    public Texture btnTexture;

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect((Screen.width / 2) - 100, 0, 200, 200));
        GUILayout.Button("Restart");
        GUILayout.EndArea();
    }
}

