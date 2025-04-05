using GqlPlus.Structures;
using Shouldly;

namespace GqlPlus.Convert;

public class RenderLinesFlowTests
{
  [Theory, RepeatData]
  public void ToLines_List(string[] value)
  {
    string expected = value.FlowList().IsLine();
    Structured model = value.Render(flow: true);

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_Map(MapPair<string>[] value)
  {
    Assert.SkipWhen(value is null || value.Length != value.Select(v => v.Key).Distinct().Count(), "Duplicate Keys in map");

    string expected = value.FlowMap().IsLine();
    Structured model = value.AsMap("", v => new(v), flow: true);

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_ListOfLists(string[][] value)
  {
    string expected = value.IsList(v => "- " + v!.FlowList()).IsLine();
    Structured model = value.Render(v => v.Render(flow: true), flow: true);

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_MapOfLists(MapPair<string[]>[] value)
  {
    Assert.SkipWhen(value is null || value.Length != value.Select(v => v.Key).Distinct().Count(), "Duplicate Keys in map");

    string expected = value.IsMap("", v => " " + v.FlowList()).IsLine();
    Structured model = value.AsMap("", v => v.Render(flow: true), flow: true);

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_ListOfMaps(MapPair<string>[][] value)
  {
    string expected = value.IsList(v => "- " + v!.FlowMap()).IsLine();
    Structured model = value.Render(v => v.AsMap("", vv => new(vv), flow: true), flow: true);

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_MapOfMaps(MapPair<MapPair<string>[]>[] value)
  {
    Assert.SkipWhen(value is null || value.Length != value.Select(v => v.Key).Distinct().Count(), "Duplicate Keys in map");

    string expected = value.IsMap("", v => " " + v.FlowMap()).IsLine();
    Structured model = value.AsMap("", v => v.AsMap("", vv => new(vv), flow: true), flow: true);

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }
}
