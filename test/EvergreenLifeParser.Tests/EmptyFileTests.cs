using System.Xml.Linq;
using Xunit;

namespace EvergreenLifeParser.Tests
{
    public class EmptyFileTests
    {
        [Fact]
        public void NoResults()
        {
            var loadedFile  = XElement.Load(@"TestFiles/1_EmptyFile.xml");
            var results = EvergreenLifeParser.Parser.Parse(loadedFile);
            Assert.True(results.Count == 0);
        }
    }
}
