using UnityEngine;
using Map;

public abstract class Beat
{
    public abstract string Name { get; }
    public abstract void Process(Transform target, Transform currentBeat, MapSection currentSection);
    public abstract BeatPooled GetNewInstance(PlayerDirection direction);
}


