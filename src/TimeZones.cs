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
    private static readonly Lazy<TimeZoneInfo> _arizonaLazy = new(() => TZConvert.GetTimeZoneInfo("America/Phoenix"), LazyThreadSafetyMode.PublicationOnly);

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

    /// <summary>
    /// Gets the &lt;see cref="TimeZoneInfo"/&gt; for Arizona, which does not observe Daylight Saving Time and is effectively in Mountain Standard Time year-round.
    /// </summary>
    public static TimeZoneInfo Arizona => _arizonaLazy.Value;

    /// <summary>
    /// Maps a CLDR time-zone ID (e.g. "America/Chicago") to one of the above,
    /// or falls back to TZConvert if it’s not one of the five.
    /// </summary>
    public static TimeZoneInfo FromCldr(string cldrTimeZoneId) => cldrTimeZoneId switch
    {
        "America/New_York" => Eastern,
        "America/Chicago" => Central,
        "America/Denver" => Mountain,
        "America/Boise" => Mountain,
        "America/Los_Angeles" => Pacific,
        "America/Phoenix" => Arizona,
        _ => TZConvert.GetTimeZoneInfo(cldrTimeZoneId)
    };
}