using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Map
{
    public static class MapController
    {
        private static Queue<MapSection> sections;
        public static bool isPlaying => sections != null;

        public static void Play(string MapDataJson)
        {
            if (isPlaying)
                return;

            sections = JsonHelper.getJsonArrayAsQueue<MapSection>(MapDataJson);

            // Debug.Log(sections.Peek().beats.Capacity);
        }

        public static void Stop()
        {
            sections = null;
        }

        public static Queue<MapSection> getSections()
        {
            return sections;
        }

        public static void endSection()
        {
            if (sections.Count != 0)
            {
                sections.Dequeue();
            } else
            {
                throw new System.Exception("Sections has reached the end of the queue!");
            }
            
        }
    }
}

