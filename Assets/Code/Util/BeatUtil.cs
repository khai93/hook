using System;
using UnityEngine;

public static class BeatUtil
{
    public static Vector2 GetSpawnPointFromDirection(PlayerDirection direction)
    {
        switch (direction)
        {
            case PlayerDirection.Left:
                return new Vector2(-10f, 0);
            case PlayerDirection.Right:
                return new Vector2(10f, 0);
            case PlayerDirection.Up:
                return new Vector2(0f, 10f);
            case PlayerDirection.Down:
                return new Vector2(0f, -10f);
            default:
                throw new Exception("Direction does not exist!");
        }
    }

    public static Transform GetTransformFromDirection(PlayerDirection direction)
    {
        var _basePlayer = Player.Instance.GetComponent<Player>();

        switch (direction)
        {
            case PlayerDirection.Left:
                return _basePlayer.Left;
            case PlayerDirection.Right:
                return _basePlayer.Right;
            case PlayerDirection.Up:
                return _basePlayer.Up;
            case PlayerDirection.Down:
                return _basePlayer.Down;
            default:
                throw new Exception("Direction does not exist!");
        }
    }

    public static PlayerDirection GetPlayerDirectionFromString(string direction)
    {
        switch (direction.ToLower()) {
            case "left":
                return PlayerDirection.Left;
            case "right":
                return PlayerDirection.Right;
            case "up":
                return PlayerDirection.Up;
            case "down":
                return PlayerDirection.Down;
            default:
                throw new Exception("Incorrect direction string!");
        }
    }

    public static KeyCode GetKeyCodeFromDirection(PlayerDirection direction)
    {
        switch (direction)
        {
            case PlayerDirection.Left:
                return KeyCode.A;
            case PlayerDirection.Right:
                return KeyCode.D;
            case PlayerDirection.Up:
                return KeyCode.W;
            case PlayerDirection.Down:
                return KeyCode.S;
            default:
                throw new Exception("Direction does not exist!");
        }
    }


}
