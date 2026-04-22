using Soenneker.Tests.HostedUnit;

using AwesomeAssertions;

namespace Soenneker.Utils.TimeZones.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class TimeZonesTests : HostedUnitTest
{
    public TimeZonesTests(Host host) : base(host)
    {
    }

    [Test]
    public void Retrieving_all_zones_should_retrieve()
    {
        Tz.Eastern.Should().NotBeNull();
        Tz.Central.Should().NotBeNull();
        Tz.Mountain.Should().NotBeNull();
        Tz.Pacific.Should().NotBeNull();
    }
}
