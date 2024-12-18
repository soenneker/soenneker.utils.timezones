using Soenneker.Tests.FixturedUnit;
using Xunit;

using FluentAssertions;

namespace Soenneker.Utils.TimeZones.Tests;

[Collection("Collection")]
public class TimeZonesTests : FixturedUnitTest
{
    public TimeZonesTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Retrieving_all_zones_should_retrieve()
    {
        Tz.Eastern.Should().NotBeNull();
        Tz.Central.Should().NotBeNull();
        Tz.Mountain.Should().NotBeNull();
        Tz.Pacific.Should().NotBeNull();
    }
}
