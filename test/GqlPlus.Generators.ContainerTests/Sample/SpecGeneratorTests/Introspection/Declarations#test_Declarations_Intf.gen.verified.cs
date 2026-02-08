//HintName: test_Declarations_Intf.gen.cs
// Generated from Declarations.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Declarations;

public interface Itest_Schema
  : Itest_Named
{
  public Itest_SchemaObject As_Schema { get; set; }
}

public interface Itest_SchemaObject
  : Itest_NamedObject
{
  public IDictionary<test_Name, Itest_Categories> Categories { get; set; }
  public IDictionary<test_Name, Itest_Directives> Directives { get; set; }
  public IDictionary<test_Name, Itest_Type> Types { get; set; }
  public IDictionary<test_Name, Itest_Setting> Settings { get; set; }
}

public interface Itest_Name
  : IDomainString
{
}

public interface Itest_Filter
{
  public ICollection<Itest_NameFilter> As_NameFilter { get; set; }
  public Itest_FilterObject As_Filter { get; set; }
}

public interface Itest_FilterObject
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public ItestBoolean? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public ItestBoolean? ReturnByAlias { get; set; }
  public ItestBoolean? ReturnReferencedTypes { get; set; }
}

public interface Itest_NameFilter
  : IDomainString
{
}

public interface Itest_CategoryFilter
  : Itest_Filter
{
  public Itest_CategoryFilterObject As_CategoryFilter { get; set; }
}

public interface Itest_CategoryFilterObject
  : Itest_FilterObject
{
  public ICollection<Itest_Resolution> Resolutions { get; set; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
  public Itest_TypeFilterObject As_TypeFilter { get; set; }
}

public interface Itest_TypeFilterObject
  : Itest_FilterObject
{
  public ICollection<Itest_TypeKind> Kinds { get; set; }
}
