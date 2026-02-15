//HintName: test_-Schema_Impl.gen.cs
// Generated from -Schema.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Schema;

public class test_Schema
  : test_Named
  , Itest_Schema
{
  public IDictionary<Itest_Name, Itest_Categories> Categories { get; set; }
  public IDictionary<Itest_Name, Itest_Directives> Directives { get; set; }
  public IDictionary<Itest_Name, Itest_Type> Types { get; set; }
  public IDictionary<Itest_Name, Itest_Setting> Settings { get; set; }
}

public class test_Name
  : GqlpDomainString
  , Itest_Name
{
}

public class test_Filter
  : Itest_Filter
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public bool? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public bool? ReturnByAlias { get; set; }
  public bool? ReturnReferencedTypes { get; set; }
}

public class test_NameFilter
  : GqlpDomainString
  , Itest_NameFilter
{
}

public class test_CategoryFilter
  : test_Filter
  , Itest_CategoryFilter
{
  public ICollection<Itest_Resolution> Resolutions { get; set; }
}

public class test_TypeFilter
  : test_Filter
  , Itest_TypeFilter
{
  public ICollection<Itest_TypeKind> Kinds { get; set; }
}

public class test_Aliased
  : test_Named
  , Itest_Aliased
{
  public ICollection<Itest_Name> Aliases { get; set; }
}

public class test_Named
  : test_Described
  , Itest_Named
{
  public Itest_Name Name { get; set; }
}

public class test_Described
  : Itest_Described
{
  public ICollection<string> Description { get; set; }
}
