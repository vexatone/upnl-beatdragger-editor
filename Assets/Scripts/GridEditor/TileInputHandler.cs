using UnityEngine;

class TileInputHandler : MonoBehaviour
{
    private TilePlacer _tilePlacer;

    private void Start()
    {
        _tilePlacer = GetComponent<TilePlacer>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // TODO: Implement logic for note placing
            var currentPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // TODO: Implement logic for note removal
            var currentPosition = Input.mousePosition;
        }
    }
}
