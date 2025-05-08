using GqlPlus.Abstractions.Schema;
using NSubstitute;

namespace GqlPlus.Helpers;

public class SchemaAbstractionTests
{
  [Theory, RepeatData]
  public void AliasedGroup_CorrectlyGrouped(TestAliased[] aliased)
  {
    IEnumerable<IGrouping<string, TestAliased>> groups = aliased.AliasedGroup();

    groups.ShouldSatisfyAllConditions(
      a => a.Select(g => g.Key).ShouldBe(NamesAndAliases(aliased), ignoreOrder: true));
  }

  [Theory, RepeatData]
  public void AliasedMap_CorrectlyMapped(TestAliased[] aliased)
  {
    IMap<IEnumerable<TestAliased>> map = aliased.AliasedMap(a => a);

    map.ShouldSatisfyAllConditions(
      m => m.Keys.ShouldBe(NamesAndAliases(aliased), ignoreOrder: true));
  }

  private static IEnumerable<string> NamesAndAliases(TestAliased[] aliased)
    => aliased
      .Select(a => a.Name)
      .Concat(aliased.SelectMany(a => a.Aliases))
      .Distinct();
}

public class TestAliased(string name, string[] aliases)
  : IGqlpAliased
{
  private static readonly ITokenAt s_at = Substitute.For<ITokenAt>();

  public IEnumerable<string> Aliases => aliases;
  public string Name => name;
  public ITokenAt At => s_at;
  public string Abbr { get; } = "Tt";
  public string Description { get; } = "";

  public bool Equals(IGqlpAbbreviated? other) => other is not null;
  public bool Equals(IGqlpAliased? other) => other is not null;
  public bool Equals(IGqlpDescribed? other) => other is not null;
  public bool Equals(IGqlpNamed? other) => other is not null;
  public IEnumerable<string?> GetFields() => throw new NotImplementedException();
  public bool IsNameOrAlias(string id) => id == name || aliases.Contains(id);
  public ITokenMessages MakeError(string message) => throw new NotImplementedException();
}
