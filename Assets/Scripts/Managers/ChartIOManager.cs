using System;
using System.IO;
using UnityEngine;

class ChartIOManager : MonoBehaviour
{
    [SerializeField] private LoadedNotesData notesData;
    
    /// <summary>
    /// Creates an empty chart. Be sure you have to include the file name into the path.
    /// </summary>
    /// <param name="path">A path of file where created empty chart will be stored.</param>
    public void CreateEmptyChart(string path)
    {
        if (File.Exists(path)) return;
        try
        {
            File.Create(path);
        }
        catch (Exception e)
        {
# if UNITY_EDITOR
            Debug.LogErrorFormat("An error occured while creating a new empty chart: {0}", e.Message);
# else
            Console.WriteLine($"An error occured while creating a new empty chart: {e.Message}");
# endif
            throw;
        }
    }

    public void LoadChart(string path)
    {
        try
        {
            
        }
        catch (Exception e)
        {
# if UNITY_EDITOR
            Debug.LogErrorFormat("An error occured while loading chart: {0}", e.Message);
# else
            Console.WriteLine($"An error occured while loading chart: {e.Message}");
# endif
            throw;
        }
    }

    public void SaveChart(string path)
    {
        try
        {

        }
        catch (Exception e)
        {
# if UNITY_EDITOR
            Debug.LogErrorFormat("An error occured while saving chart: {0}", e.Message);
# else
            Console.WriteLine($"An error occured while saving chart: {e.Message}");
# endif
            throw;
        }
    }
}