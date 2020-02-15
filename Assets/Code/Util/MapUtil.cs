using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public static class MapUtil
    {
        public static MapSection getCurrentSection()
        {
            Queue<MapSection> sections = MapController.getSections();
            MapSection currentSection = sections.Peek();

            return currentSection;
        }
    }
}
