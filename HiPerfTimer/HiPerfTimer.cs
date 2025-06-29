using System;
using System.Runtime.InteropServices;

public class HiPerfTimer
{
    [DllImport("Kernel32.dll")]
    private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

    [DllImport("Kernel32.dll")]
    private static extern bool QueryPerformanceFrequency(out long lpFrequency);

    private long startTime;
    private long stopTime;
    private long freq;

    public HiPerfTimer()
    {
        startTime = 0;
        stopTime = 0;
        freq = 0;
        if (QueryPerformanceFrequency(out freq) == false)
        {
            throw new Exception("不支持高性能计数器");
        }
    }

    public void Start()
    {
        QueryPerformanceCounter(out startTime);
    }

    public void Stop()
    {
        QueryPerformanceCounter(out stopTime);
    }

    public double Duration
    {
        get { return Math.Round((double)(stopTime - startTime) / (double)freq,8); }
    }
}