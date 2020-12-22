using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EvergreenLifeParser
{
    public static class Parser
    {
        public static List<Result> Parse(XElement file)
        {
            var resultsFromXml = file.Descendants("result");
            var results = new List<Result>();

            foreach (var result in resultsFromXml)
            {
                var dateCount = result.Descendants("date").Count();
                if (dateCount == 1)
                {
                    var newResult = new Result
                    {
                        Code = result.Element("code")?.Value,
                        Name = result.Element("name")?.Value,
                        Date = DateTime.Parse(result.Element("date")?.Value ?? string.Empty),
                        Comment = result.Element("comment")?.Value,
                        Value = result.Element("value")?.Value,
                        ValueMin = result.Element("value_minimum")?.Value,
                        ValueMax = result.Element("value_maximum")?.Value,
                        Units = result.Element("units")?.Value
                    };
                    results.Add(newResult);
                }
                else
                {
                    var index = 0;
                    var count = 0;
                    Dictionary<int, int> indexes = new Dictionary<int, int>();
                    var resultList = result.Elements().ToList();
                    foreach (var t in resultList)
                    {
                        if (t.Name == "date")
                        {
                            indexes[count++] = index;
                        }

                        index++;
                    }

                    Result outerResult = null;
                    for (var i = 0; i < indexes.Count(); i++)
                    {
                        var start = indexes[i];
                        var end = 0;
                        end = i != indexes.Count() - 1 ? indexes[i + 1] : index;

                        List<XElement> slice;
                        if (start == 0)
                        {
                            slice = resultList.Take(end).ToList();
                            var newResult = new Result
                            {
                                Code = slice.FirstOrDefault(x => x.Name == "code")?.Value,
                                Name = slice.FirstOrDefault(x => x.Name == "name")?.Value,
                                Date = DateTime.Parse(
                                    slice.FirstOrDefault(x => x.Name == "date")?.Value ?? string.Empty),
                                Comment = slice.FirstOrDefault(x => x.Name == "comment")?.Value,
                                Value = slice.FirstOrDefault(x => x.Name == "value")?.Value,
                                ValueMin = slice.FirstOrDefault(x => x.Name == "value_minimum")?.Value,
                                ValueMax = slice.FirstOrDefault(x => x.Name == "value_maximum")?.Value,
                                Units = slice.FirstOrDefault(x => x.Name == "units")?.Value,
                                InnerResults = new List<Result>()
                            };
                            outerResult = newResult;
                        }
                        else
                        {
                            slice = resultList.Skip(start).Take(end - start).ToList();
                            var newResult = new Result
                            {
                                Code = slice.FirstOrDefault(x => x.Name == "code")?.Value,
                                Name = slice.FirstOrDefault(x => x.Name == "name")?.Value,
                                Date = DateTime.Parse(
                                    slice.FirstOrDefault(x => x.Name == "date")?.Value ?? string.Empty),
                                Comment = slice.FirstOrDefault(x => x.Name == "comment")?.Value,
                                Value = slice.FirstOrDefault(x => x.Name == "value")?.Value,
                                ValueMin = slice.FirstOrDefault(x => x.Name == "value_minimum")?.Value,
                                ValueMax = slice.FirstOrDefault(x => x.Name == "value_maximum")?.Value,
                                Units = slice.FirstOrDefault(x => x.Name == "units")?.Value,
                            };
                            outerResult?.InnerResults.Add(newResult);
                        }
                    }
                    results.Add(outerResult);
                }
            }
            return results;
        }
    }
}

