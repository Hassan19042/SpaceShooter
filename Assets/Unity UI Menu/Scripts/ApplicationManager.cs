using UnityEngine;
using System.Collections;

public class ApplicationManager : MonoBehaviour {
	

	public void Quit ()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
        #endif
    }
}
