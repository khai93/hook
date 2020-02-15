using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelper
{
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }


    /// <summary>
    /// Get a json array as a queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <returns>A Queue of type T</returns>

    public static Queue<T> getJsonArrayAsQueue<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);

        var queue = new Queue<T>(wrapper.array);

        return queue;
    }

}

