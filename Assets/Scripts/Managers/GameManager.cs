using UnityEngine;

class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static StateManager StateManager { get; private set; }
    public static ChartIOManager ChartIOManager { get; private set; }

    private void Awake()
    {
        // Singleton Check
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;

        // GameManager should be global and should't be destroyed
        DontDestroyOnLoad(this);

        // Sub-Managers
        StateManager = GetComponentInChildren<StateManager>();
        ChartIOManager = GetComponentInChildren<ChartIOManager>();
    }
}
