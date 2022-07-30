using System;

namespace BlazorWebCV.Helpers;

public static class RandomHelper
{
    private static Random _R = new Random ();
    public static T RandomEnumValue<T> () where T : Enum
    {
        var v = Enum.GetValues (typeof (T));
        return (T) v.GetValue (_R.Next(v.Length));
    }
}