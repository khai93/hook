using System.Collections.Generic;
using UnityEngine;

namespace Map {
    [System.Serializable]
    public class MapSection
    {
        public string type;
        public float bpm;

        public List<MapBeatEntry> beats;
    }

    [System.Serializable]
    public struct MapBeatEntry
    {
        public string type;
        public string direction;
        public bool burst;
    }
}


