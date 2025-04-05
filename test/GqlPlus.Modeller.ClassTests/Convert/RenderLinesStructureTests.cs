using GqlPlus.Structures;
using Shouldly;

namespace GqlPlus.Convert;

public class RenderLinesStructureTests
{
  [Theory, RepeatData]
  public void ToLines_List(string[] value)
  {
    string expected = value.IsList("").IsLine();
    Structured model = value.Render();

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_Map(MapPair<string>[] value)
  {
    Assert.SkipWhen(value is null || value.Length != value.Select(v => v.Key).Distinct().Count(), "Duplicate Keys in map");

    string expected = value.IsMap("", v => " " + v).IsLine();
    Structured model = value.AsMap("", v => new(v));

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_ListOfLists(string[][] value)
  {
    string expected = value.IsList(v => "-" + Environment.NewLine + v!.IsList("  ")).IsLine();
    Structured model = value.Render(v => v.Render());

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_MapOfLists(MapPair<string[]>[] value)
  {
    Assert.SkipWhen(value is null || value.Length != value.Select(v => v.Key).Distinct().Count(), "Duplicate Keys in map");

    string expected = value.IsMap("", v => Environment.NewLine + v.IsList("  ")).IsLine();
    Structured model = value.AsMap("", v => v.Render());

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_ListOfMaps(MapPair<string>[][] value)
  {
    string expected = value.IsList(v => "-" + Environment.NewLine + v!.IsMap("  ", vv => " " + vv)).IsLine();
    Structured model = value.Render(v => v.AsMap("", vv => new(vv)));

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToLines_MapOfMaps(MapPair<MapPair<string>[]>[] value)
  {
    Assert.SkipWhen(value is null || value.Length != value.Select(v => v.Key).Distinct().Count(), "Duplicate Keys in map");

    string expected = value.IsMap("", v => Environment.NewLine + v.IsMap("  ", vv => " " + vv)).IsLine();
    Structured model = value.AsMap("", v => v.AsMap("", vv => new(vv)));

    string result = model.ToLines(false);

    result.ShouldBe(expected);
  }
}
