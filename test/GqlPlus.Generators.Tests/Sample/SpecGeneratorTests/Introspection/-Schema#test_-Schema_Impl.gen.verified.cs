//HintName: test_-Schema_Impl.gen.cs
// Generated from -Schema.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Schema;

public class test_Schema
  : test_Named
  , Itest_Schema
{
  public IDictionary<test_Name, test_Categories> categories { get; set; }
  public IDictionary<test_Name, test_Directives> directives { get; set; }
  public IDictionary<test_Name, test_Type> types { get; set; }
  public IDictionary<test_Name, test_Setting> settings { get; set; }
  public test_Schema _Schema { get; set; }
}

public class test_Name
  : DomainString
  , Itest_Name
{
}

public class test_Filter
  : Itest_Filter
{
  public ICollection<test_NameFilter> names { get; set; }
  public testBoolean? matchAliases { get; set; }
  public ICollection<test_NameFilter> aliases { get; set; }
  public testBoolean? returnByAlias { get; set; }
  public testBoolean? returnReferencedTypes { get; set; }
  public ICollection<test_NameFilter> As_NameFilter { get; set; }
  public test_Filter _Filter { get; set; }
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
  public ICollection<test_Resolution> resolutions { get; set; }
  public test_CategoryFilter _CategoryFilter { get; set; }
}

public class test_TypeFilter
  : test_Filter
  , Itest_TypeFilter
{
  public ICollection<test_TypeKind> kinds { get; set; }
  public test_TypeFilter _TypeFilter { get; set; }
}

public class test_Aliased
  : test_Named
  , Itest_Aliased
{
  public ICollection<test_Name> aliases { get; set; }
  public test_Aliased _Aliased { get; set; }
}

public class test_Named
  : test_Described
  , Itest_Named
{
  public test_Name name { get; set; }
  public test_Named _Named { get; set; }
}

public class test_Described
  : Itest_Described
{
  public ICollection<testString> description { get; set; }
  public test_Described _Described { get; set; }
}
