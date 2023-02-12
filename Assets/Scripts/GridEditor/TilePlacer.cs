using System;
using UnityEngine;

class TilePlacer : MonoBehaviour
{
    private NoteGroup _currentNote;
    
    [SerializeField] private GameObject normalNotePrefab;
    [SerializeField] private GameObject critNotePrefab;
    [SerializeField] private GameObject flickNotePrefab;
    [SerializeField] private GameObject holdNotePrefab;
    [SerializeField] private GameObject dragNotePrefab;
    [SerializeField] private GameObject damageNotePrefab;

    [SerializeField] private SnapData snapDataContainer;

    public void SetNotes(Vector3 position)
    {
        
    }

    public void RemoveNotes(Vector3 position)
    {
        
    }

    public void Zoom(float multiplier)
    {
        
    }

    /// <summary>
    /// Converts given horizontal position into snapped horizontal position following by Snap Mode.
    /// </summary>
    /// <param name="hPos">Raw Horizontal Position in float.</param>
    /// <param name="snapMode">Snap mode. Choose one between Border-oriented or Note-oriented.</param>
    /// <returns>Snapped position if the given horizontal position is in valid area. Null if not.</returns>
    private float? HorizontalSnap(float hPos, SnapMode snapMode)
    {
        if (snapMode == SnapMode.Border)
        {
            foreach (float pivot in snapDataContainer.borderPosData)
            {
                if (Math.Abs(hPos - pivot) <= 0.4f) return pivot;
            }

            return null;
        }
        else
        {
            foreach (float pivot in snapDataContainer.notePosData)
            {
                if (Math.Abs(hPos - pivot) <= 0.4f) return pivot;
            }

            return null;
        }
    }

    private float VerticalSnap(float vPos)
    {
        throw new NotImplementedException();
    }
}