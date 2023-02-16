using UnityEngine;

class TileInputHandler : MonoBehaviour
{
    private Camera _cam;
    private TilePlacer _tilePlacer;

    private void Start()
    {
        _cam = Camera.main;
        _tilePlacer = GetComponent<TilePlacer>();
    }

    private void Update()
    {
        // TODO: Code rework so that the note is previewed when holding a mouse button

        if (Input.GetMouseButton(0))
        {
            var currentPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
            
            // Not Completed, but temporarilly... (FOR TEST)
            _tilePlacer.PreviewNewNotes(currentPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // TODO: Implement logic for note placing
            var currentPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
            
            // Not completed, but temporarily... (FOR TEST)
            _tilePlacer.DestroyPreviews();
            _tilePlacer.SetNotes(currentPosition);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // TODO: Implement logic for note removal
            var currentPosition = Input.mousePosition;
        }
    }
}
