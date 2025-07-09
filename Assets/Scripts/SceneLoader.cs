using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void QuitGame()
    // quit game function for button 
    {
        Application.Quit();
        Debug.Log("Quit"); 
    }
}
