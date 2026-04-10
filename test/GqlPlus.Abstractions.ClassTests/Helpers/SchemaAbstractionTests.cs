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
      .SelectMany(a => a.NameAndAliases())
      .Distinct();
}

public class TestAliased(string name, string[] aliases)
  : IAstAliased
{
  private static readonly ITokenAt s_at = Substitute.For<ITokenAt>();

  public IEnumerable<string> Aliases => aliases;
  public string Name => name;
  public ITokenAt At => s_at;
  public string Abbr { get; } = "Tt";
  public string Description { get; } = "";

  public bool Equals(IAstAbbreviated? other) => Equals(other as IAstAliased);
  public bool Equals(IAstDescribed? other) => Equals(other as IAstAliased);
  public bool Equals(IAstNamed? other) => Equals(other as IAstAliased);
  public bool Equals(IAstAliased? other)
    => other is not null
    && Name == other.Name;
  public IEnumerable<string?> GetFields() => throw new NotImplementedException();
  public bool IsNameOrAlias(string id) => id == name || aliases.Contains(id);
  public IMessages MakeError(string message) => throw new NotImplementedException();
}
