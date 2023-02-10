using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Data Containers/Snap Data",fileName="SnapData",order=1)]
class SnapData : ScriptableObject
{
    public List<float> borderPosData = new List<float>();
    public List<float> notePosData = new List<float>();
}