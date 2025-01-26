using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static int level = 1;
    public static int perfect_count;
    public static int ok_count;
    public static int bad_count;
    public static float time_for_beat;

    public static void setData(int lvl, int per, int ok, int bad, float tfb)
    {
        level = lvl;
        perfect_count = per;
        ok_count = ok;
        bad_count = bad;
        time_for_beat = tfb;
    }
}
