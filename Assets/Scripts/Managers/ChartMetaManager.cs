using System;
using System.Collections.Generic;
using UnityEngine;

class ChartMetaManager : MonoBehaviour
{
    private ChartMetaData _metaData;
    
    // ID, Title, Composer, Note count, Difficulty, BPMs
    
    public struct BPMTimings
    {
        public int BPM;
        public float Timing;

        public BPMTimings(int bpm, float timing)
        {
            BPM = bpm;
            Timing = timing;
        }
    }
    
    public struct ChartMetaData
    {
        public int ID;
        public string Title;
        public string Composer;
        public int NoteCount;
        public ChartDifficulty Difficulty;
        public List<BPMTimings> Timings;

        public void Initialize()
        {
            ID = 0;
            Title = "";
            Composer = "";
            NoteCount = 0;
            Difficulty = ChartDifficulty.Normal;
            Timings.Add(new BPMTimings(120, 0f));
        }
    }
    
    public ChartMetaData GetCurrentMetaData()
    {
        try
        {
            return _metaData;
        }
        catch (Exception e)
        {
# if UNITY_EDITOR
            Debug.LogError($"Cannot retrieve current chart metadata: {e.Message}");
# else
            Console.WriteLine($"Cannot retrieve current chart metadata: {e.Message}");
# endif
            throw;
        }
    }

    private void Awake()
    {
        ChartMetaData tempData = new ChartMetaData();
        tempData.Initialize();

        _metaData = tempData;
    }
}