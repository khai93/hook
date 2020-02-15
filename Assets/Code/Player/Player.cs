using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public Transform Left;
    public Transform Right;
    public Transform Up;
    public Transform Down;

    private void Awake()
    {
        Instance = this;
    }
}
