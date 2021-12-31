using FluentAssertions;
using Xunit;

namespace Invoices.Core.Tests
{
    public class RecordTests
    {
        [Fact]
        public void Record_are_equal()
        {
            var gregor1 = new Gregor("Angular", "9");

            var gregor2 = new Gregor("Angular", "9");

            var gregor3 = gregor2 with { Version = "8" };

            var gregor4 = new Gregor("Angular", "9")
            {
                Version = "8"
            };

            gregor1.Should().Be(gregor2);
            gregor2.Should().NotBe(gregor3);
        }

        [Fact]
        public void Classes_are_equal()
        {
            var albert1 = new Albert("Vue", "9");

            var albert2= new Albert("Vue", "9");

            albert1.Should().Be(albert2);
        }
    }

    public record Gregor(string LieblingsFramework, string Version);

    public class Albert
    {

        public Albert(string framework, string version)
        {
            Framework = framework;
            Version = version;
        }
        public string Framework { get; }
        public string Version { get; }
    }
}
