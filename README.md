[![](https://img.shields.io/nuget/v/soenneker.utils.timezones.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.timezones/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.timezones/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.timezones/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.timezones.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.timezones/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.timezones/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.timezones/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.TimeZones
Cached `TimeZoneInfo` access for common continental US zones and IANA/CLDR identifier resolution through TimeZoneConverter.

## Installation

```bash
dotnet add package Soenneker.Utils.TimeZones
```

## Common US zones

```csharp
using Soenneker.Utils.TimeZones;

TimeZoneInfo eastern = Tz.Eastern;
TimeZoneInfo central = Tz.Central;
TimeZoneInfo mountain = Tz.Mountain;
TimeZoneInfo pacific = Tz.Pacific;
TimeZoneInfo arizona = Tz.Arizona;
```

The properties are initialized lazily and then reused. They resolve these IANA zones through TimeZoneConverter:

| Property | Source identifier | Daylight saving time |
| --- | --- | --- |
| `Eastern` | `America/New_York` | Observed |
| `Central` | `America/Chicago` | Observed |
| `Mountain` | `America/Boise` | Observed |
| `Pacific` | `America/Los_Angeles` | Observed |
| `Arizona` | `America/Phoenix` | Not observed |

`TimeZoneInfo.Id` may be an IANA identifier or its Windows equivalent depending on the operating system. Use `TimeZoneInfo` conversion APIs instead of comparing the returned `Id` with a hard-coded platform-specific value.

## Resolve an identifier

```csharp
TimeZoneInfo zone = Tz.FromCldr("Europe/Paris");
DateTimeOffset local = TimeZoneInfo.ConvertTime(instant, zone);
```

The five built-in US zones return their shared property instances. `America/Denver` and `America/Boise` both return `Tz.Mountain`, whose source identifier is `America/Boise`. Other identifiers are resolved by `TZConvert.GetTimeZoneInfo` and cached by the exact input string.

Unknown or unsupported identifiers throw the exception produced by TimeZoneConverter. The fallback cache has no eviction, so do not call `FromCldr` with an unbounded stream of user-controlled identifiers without validating or constraining them first.

Time-zone rules come from the operating system and TimeZoneConverter mappings. They can change as governments and time-zone databases change; store the original zone identifier when future recalculation matters.

Call the static `Tz` members directly; no dependency-injection registration is required.
