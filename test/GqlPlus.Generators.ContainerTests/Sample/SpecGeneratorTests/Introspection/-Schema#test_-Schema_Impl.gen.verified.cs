//HintName: test_-Schema_Impl.gen.cs
// Generated from -Schema.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Schema;

public class test_Schema
  : test_Named
  , Itest_Schema
{
  public IDictionary<test_Name, Itest_Categories> Categories { get; set; }
  public IDictionary<test_Name, Itest_Directives> Directives { get; set; }
  public IDictionary<test_Name, Itest_Type> Types { get; set; }
  public IDictionary<test_Name, Itest_Setting> Settings { get; set; }
  public Itest_SchemaObject As_Schema { get; set; }
}

public class test_Name
  : DomainString
  , Itest_Name
{
}

public class test_Filter
  : Itest_Filter
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public ItestBoolean? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public ItestBoolean? ReturnByAlias { get; set; }
  public ItestBoolean? ReturnReferencedTypes { get; set; }
  public ICollection<Itest_NameFilter> As_NameFilter { get; set; }
  public Itest_FilterObject As_Filter { get; set; }
}

public class test_NameFilter
  : DomainString
  , Itest_NameFilter
{
}

public class test_CategoryFilter
  : test_Filter
  , Itest_CategoryFilter
{
  public ICollection<Itest_Resolution> Resolutions { get; set; }
  public Itest_CategoryFilterObject As_CategoryFilter { get; set; }
}

public class test_TypeFilter
  : test_Filter
  , Itest_TypeFilter
{
  public ICollection<Itest_TypeKind> Kinds { get; set; }
  public Itest_TypeFilterObject As_TypeFilter { get; set; }
}

public class test_Aliased
  : test_Named
  , Itest_Aliased
{
  public ICollection<Itest_Name> Aliases { get; set; }
  public Itest_AliasedObject As_Aliased { get; set; }
}

public class test_Named
  : test_Described
  , Itest_Named
{
  public Itest_Name Name { get; set; }
  public Itest_NamedObject As_Named { get; set; }
}

public class test_Described
  : Itest_Described
{
  public ICollection<ItestString> Description { get; set; }
  public Itest_DescribedObject As_Described { get; set; }
}
