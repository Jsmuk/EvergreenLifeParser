using System;
using System.Linq;
using System.Xml.Linq;
using Xunit;

namespace EvergreenLifeParser.Tests
{
    public class SingleItemTests
    {
        private XElement file;
        public SingleItemTests()
        {
            file = XElement.Load(@"TestFiles/2_SingleItem.xml");
        }
        [Fact]
        public void ResultsCount()
        {
            var results = EvergreenLifeParser.Parser.Parse(file);
            Assert.True(results.Count == 1);
        }

        [Fact]
        public void InnerResultsEmpty()
        {
            var results = EvergreenLifeParser.Parser.Parse(file);
            Assert.Null(results.First().InnerResults);
        }

        [Fact]
        public void CheckValues()
        {
            var results = EvergreenLifeParser.Parser.Parse(file);
            Assert.True(results.First().Date == new DateTime(2019,10,15));
            Assert.True(results.First().Name == "Erythrocyte sedimentation rate");
            Assert.True(results.First().Code == "648521000006111");
            Assert.True(results.First().Comment == "(adoctor) - Normal - No Action  ");
            Assert.True(results.First().Value == "3.000");
            Assert.True(results.First().ValueMin == "0");
            Assert.True(results.First().ValueMax == "10");
            Assert.True(results.First().Units == "mm/h");
        }
    }
}