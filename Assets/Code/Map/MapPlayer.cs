using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class MapPlayer : MonoBehaviour
    {

        private float mapTimer = 0f;
        private float beatTimer = 0f;

        private void Update()
        {
            if (MapController.isPlaying)
            {
                var Sections = MapController.getSections();
                if (Sections.Count > 0)
                {
                    MapSection currentSection = MapUtil.getCurrentSection();

                    if (currentSection.beats.Count != 0)
                    {
                        if (Time.time > beatTimer)
                        {
                            MapBeatEntry CurrentBeatEntry = currentSection.beats[0];
                           

                            // Debug.Log("note, BPM: " + (currentSection.bpm / 60));

                            Beat beat = BeatFactory.GetBeat(CurrentBeatEntry.type);
                            PlayerDirection pDirection = BeatUtil.GetPlayerDirectionFromString(CurrentBeatEntry.direction);

                            BeatPooled beatInstance = beat.GetNewInstance(pDirection);
                            beatInstance.gameObject.SetActive(true);

                            currentSection.beats.RemoveAt(0);


                            // Check Burst

                            if (currentSection.beats.Count > 1)
                            {
                                MapBeatEntry NextBeatEntry = currentSection.beats[1];

                                if (!NextBeatEntry.burst)
                                    beatTimer = Time.time + (1 / (currentSection.bpm / 60));
                            }
                        }
                    } else
                    {
                        SectionEnd();
                    }
                } else
                {
                    SectionEnd();
                }

                mapTimer += Time.deltaTime;
            }
        }

        private void MapEnd()
        {
            mapTimer = 0f;
            beatTimer = 0f;
            MapController.Stop();
        }

        private void SectionEnd()
        {
            var Sections = MapController.getSections();
            if (Sections.Count > 0)
            {
                beatTimer = 0f;
                MapController.endSection();
            } else
            {
                MapEnd();
            }
        } 

    }
}

