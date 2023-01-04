using UnityEngine;
using UnityEngine.SceneManagement;

class StateManager : MonoBehaviour
{
    public GameState CurrentState { get; private set; }

    /// <summary>
    /// Starts the editor and loads the selection menu.
    /// </summary>
    /// <returns>true if the scene is successfully loaded; false if not</returns>
    public bool StartEditor()
    {
        if (CurrentState == GameState.MainMenu)
        {
            SceneManager.LoadScene("Menu");
            CurrentState = GameState.SelectionMenu;
            return true;
        }
        else return false;
    }

    private void Awake()
    {
        CurrentState = GameState.MainMenu;
    }
}