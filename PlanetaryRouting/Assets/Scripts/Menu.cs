using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
  using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    void LoadData ()
    {
        // Load the json file containing all the players data
    }

    void LoadLevel (string LevelName)
    {
        // Load a level by it's name
    }

    public void StartClick ()
    {
        // Check which level the player has reached, and load it
    }

    public void QuitClick ()
    {
      #if UNITY_EDITOR
        EditorApplication.ExitPlaymode ();
      #else
        Application.Quit ();
      #endif
    }
}
