using UnityEngine;
using Map;

public class StraightBeat : Beat
{
    public override string Name => "straight";

    public override void Process(Transform target, Transform currentBeat, MapSection currentSection)
    {
        float speed = (currentSection.bpm / 60) * Time.deltaTime;
        currentBeat.position = Vector2.MoveTowards(currentBeat.position, target.position, speed);
    }

    public override BeatPooled GetNewInstance(PlayerDirection direction)
    {
        var beatInstance = BeatPool.Instance.Get();

        Vector2 spawnPoint = BeatUtil.GetSpawnPointFromDirection(direction);
        Transform target = BeatUtil.GetTransformFromDirection(direction);

        beatInstance.transform.position = spawnPoint;

        var pooled = beatInstance.GetComponent<BeatPooled>();
        pooled.Init(target, Name, direction);

        return beatInstance;
    }
}
