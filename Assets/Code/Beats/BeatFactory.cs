using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class BeatFactory
{
    private static Dictionary<string, Type> beatsByName;
    private static bool IsInitialized => beatsByName != null;

    private static void InitFactory()
    {
        if (IsInitialized)
            return;

        var beatTypes = Assembly.GetAssembly(typeof(Beat)).GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Beat)));

        beatsByName = new Dictionary<string, Type>();

        foreach (var type in beatTypes)
        {
            var tempEffect = Activator.CreateInstance(type) as Beat;
            beatsByName.Add(tempEffect.Name, type);
        }
    }

    public static Beat GetBeat(string beatType)
    {
        InitFactory();

        if (beatsByName.ContainsKey(beatType))
        {
            Type type = beatsByName[beatType];
            var beat = Activator.CreateInstance(type) as Beat;
            return beat;
        }

        return null;
    }

    internal static IEnumerable<string> GetBeatNames()
    {
        InitFactory();

        return beatsByName.Keys;
    }
}
