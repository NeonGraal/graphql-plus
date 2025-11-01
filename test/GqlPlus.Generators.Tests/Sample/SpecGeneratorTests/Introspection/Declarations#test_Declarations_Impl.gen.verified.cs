//HintName: test_Declarations_Impl.gen.cs
// Generated from Declarations.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Declarations;

public class test_Schema
  : test_Named
  , Itest_Schema
{
  public IDictionary<test_Identifier, test_Categories> categories { get; set; }
  public IDictionary<test_Identifier, test_Directives> directives { get; set; }
  public IDictionary<test_Identifier, test_Type> types { get; set; }
  public IDictionary<test_Identifier, test_Setting> settings { get; set; }
  public test_Schema _Schema { get; set; }
}

public class test_Identifier
  : Itest_Identifier
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
  : Itest_NameFilter
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
