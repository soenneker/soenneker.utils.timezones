[![](https://img.shields.io/nuget/v/soenneker.utils.timezones.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.timezones/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.timezones/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.timezones/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.timezones.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.timezones/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.timezones/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.timezones/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.TimeZones
A utility library for easy access to common TimeZoneInfos.

## Installation

```bash
dotnet add package Soenneker.Utils.TimeZones
```

## Quick start

```csharp
using Soenneker.Utils.TimeZones;
```

Call the static `Tz` methods directly; no dependency-injection registration is required.

## Common operations

- `FromCldr()` - Maps a CLDR time-zone ID (e.g. "America/Chicago") to one of the above, or falls back to TZConvert if it�s not one of the five.
