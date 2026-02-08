//HintName: test_-Schema_Intf.gen.cs
// Generated from -Schema.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Schema;

public interface Itest_Schema
  : Itest_Named
{
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
}

public interface Itest_CategoryFilterObject
  : Itest_FilterObject
{
  public ICollection<Itest_Resolution> Resolutions { get; set; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
}

public interface Itest_TypeFilterObject
  : Itest_FilterObject
{
  public ICollection<Itest_TypeKind> Kinds { get; set; }
}

public interface Itest_Aliased
  : Itest_Named
{
}

public interface Itest_AliasedObject
  : Itest_NamedObject
{
  public ICollection<Itest_Name> Aliases { get; set; }
}

public interface Itest_Named
  : Itest_Described
{
}

public interface Itest_NamedObject
  : Itest_DescribedObject
{
  public Itest_Name Name { get; set; }
}

public interface Itest_Described
{
}

public interface Itest_DescribedObject
{
  public ICollection<ItestString> Description { get; set; }
}
