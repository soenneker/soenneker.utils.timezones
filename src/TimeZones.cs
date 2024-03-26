using System;
using System.Threading;
using TimeZoneConverter;

namespace Soenneker.Utils.TimeZones;

/// <summary>
/// A utility library for easy access to common <see cref="TimeZoneInfo"/>
/// </summary>
public static class Tz
{
    private static readonly Lazy<TimeZoneInfo> _easternLazy = new(() => TZConvert.GetTimeZoneInfo("America/New_York"), LazyThreadSafetyMode.PublicationOnly);
    private static readonly Lazy<TimeZoneInfo> _centralLazy = new(() => TZConvert.GetTimeZoneInfo("America/Chicago"), LazyThreadSafetyMode.PublicationOnly);
    private static readonly Lazy<TimeZoneInfo> _mountainLazy = new(() => TZConvert.GetTimeZoneInfo("America/Boise"), LazyThreadSafetyMode.PublicationOnly);
    private static readonly Lazy<TimeZoneInfo> _pacificLazy = new(() => TZConvert.GetTimeZoneInfo("America/Los_Angeles"), LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Gets the <see cref="TimeZoneInfo"/> for the Eastern Standard Time zone (EST), covering the east coast of the United States.
    /// </summary>
    public static TimeZoneInfo Eastern => _easternLazy.Value;

    /// <summary>
    /// Gets the <see cref="TimeZoneInfo"/> for the Central Standard Time zone (CST), covering the central part of the United States.
    /// </summary>
    public static TimeZoneInfo Central => _centralLazy.Value;

    /// <summary>
    /// Gets the <see cref="TimeZoneInfo"/> for the Mountain Standard Time zone (MST), covering the mountain regions of the United States.
    /// </summary>
    public static TimeZoneInfo Mountain => _mountainLazy.Value;

    /// <summary>
    /// Gets the <see cref="TimeZoneInfo"/> for the Pacific Standard Time zone (PST), covering the west coast of the United States.
    /// </summary>
    public static TimeZoneInfo Pacific => _pacificLazy.Value;
}
