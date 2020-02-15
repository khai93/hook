using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map;

public class BeatPooled : MonoBehaviour
{
    private Transform target;
    private Beat beat;
    private MapSection currentSection;
    private Collider2D currentCollider;
    private Player player;
    private KeyCode KeyToPress;
    private bool canBePresssed = false;
    private PlayerDirection direction;

    private float lifeTime;
    private float maxLifetime = 360f;

    private void Update()
    {
        if (beat is Beat)
        {
            CheckKey(KeyToPress);
            beat.Process(target, transform, currentSection);
            lifeTime += Time.deltaTime;

            float distance = DistanceFromTarget();

            if (distance <= 0 && this.isActiveAndEnabled)
            {
                Debug.Log(distance);
                GameManager.Instance.ProcessScore(0);
                BeatPool.Instance.ReturnToPool(this);
            } else if (lifeTime > maxLifetime)
            {
                BeatPool.Instance.ReturnToPool(this);
            }
        }
    }

    private void CheckKey(KeyCode keyToPress)
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePresssed)
            {
                BeatPool.Instance.ReturnToPool(this);

                float distance = DistanceFromTarget();

                

                if (distance <= 0)
                {
                    // miss
                    GameManager.Instance.ProcessScore(0);
                }
                else if (distance > 0.5)
                {
                    // 50
                    GameManager.Instance.ProcessScore(50);
                }
                else if (distance > 0.25)
                {
                    // 100
                    GameManager.Instance.ProcessScore(100);
                }
                else if (distance > 0.1)
                {
                    // 300
                    GameManager.Instance.ProcessScore(300);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Entered");
            canBePresssed = true;
        }
    }

    public void Init(Transform _target, string beatType, PlayerDirection _direction)
    {
        beat = BeatFactory.GetBeat(beatType);
        currentSection = MapUtil.getCurrentSection();
        KeyToPress = BeatUtil.GetKeyCodeFromDirection(_direction);
        canBePresssed = false;
        target = _target;
        direction = _direction;
        lifeTime = 0f;

        transform.rotation = _target.rotation;

        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        spr.color = _target.GetComponent<SpriteRenderer>().color;
    }

    private float DistanceFromTarget()
    {
        return Vector2.Distance(transform.position, target.position);
    }
}
