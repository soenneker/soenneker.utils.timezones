using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;
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
        TimeZones.Eastern.Should().NotBeNull();
        TimeZones.Central.Should().NotBeNull();
        TimeZones.Mountain.Should().NotBeNull();
        TimeZones.Pacific.Should().NotBeNull();
    }
}
