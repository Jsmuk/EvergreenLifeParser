using System;
using System.Linq;
using System.Xml.Linq;
using Xunit;

namespace EvergreenLifeParser.Tests
{
    public class MultiItemTests
    {
        private XElement file;
        public MultiItemTests()
        {
            file = XElement.Load(@"TestFiles/3_MultiItems.xml");
        }
        
        [Fact]
        public void ResultsCount()
        {
            var results = EvergreenLifeParser.Parser.Parse(file);
            Assert.True(results.Count == 2);
        }

        [Fact]
        public void InnerResultsOfSecondEmpty()
        {
            var results = EvergreenLifeParser.Parser.Parse(file);
            Assert.NotNull(results[1].InnerResults);
        }

        [Fact]
        public void CheckValuesOfFirst()
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

        [Fact]
        public void CheckSecondResultInnerResultCount()
        {
            var results = EvergreenLifeParser.Parser.Parse(file);
            Assert.True(results[1].InnerResults.Count() == 2);
        }

        [Fact]
        public void CheckSecondResultValues()
        {
            var results = EvergreenLifeParser.Parser.Parse(file);
            var result = results[1];
            Assert.True(result.Date == new DateTime(2019,10,15));
            Assert.True(result.Name == "Full blood count - FBC");
            Assert.True(result.Code == "795331000006111");
            Assert.True(result.Comment == "(adoctor) - Normal - No Action  ");
        }
        
        [Fact]
        public void CheckSecondResultInnerResultValues()
        {
            var results = EvergreenLifeParser.Parser.Parse(file);
            var firstInner = results[1].InnerResults[0];
            var secondInner = results[1].InnerResults[1];

            Assert.True(firstInner.Date == new DateTime(2019, 10, 15));
            Assert.True(firstInner.Name == "Total white cell count");
            Assert.True(firstInner.Code == "98461000006116");
            Assert.True(firstInner.Value == "5.300");
            Assert.True(firstInner.Units == "10*9/L");
            Assert.True(firstInner.ValueMin == "3.5");
            Assert.True(firstInner.ValueMax == "10");
            
            Assert.True(secondInner.Date == new DateTime(2019, 10, 15));
            Assert.True(secondInner.Name == "Red blood cell (RBC) count");
            Assert.True(secondInner.Code == "183211000006119");
            Assert.True(secondInner.Value == "5.040");
            Assert.True(secondInner.Units == "10*12/L");
            Assert.True(secondInner.ValueMin == "4.25");
            Assert.True(secondInner.ValueMax == "5.75");

        }
        
    }
}
