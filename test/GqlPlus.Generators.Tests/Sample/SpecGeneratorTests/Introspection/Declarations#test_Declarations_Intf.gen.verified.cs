//HintName: test_Declarations_Intf.gen.cs
// Generated from Declarations.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Declarations;

public interface Itest_Schema
  : Itest_Named
{
  public test_Schema _Schema { get; set; }
}

public interface Itest_SchemaObject
  : Itest_NamedObject
{
  public IDictionary<test_Name, test_Categories> categories { get; set; }
  public IDictionary<test_Name, test_Directives> directives { get; set; }
  public IDictionary<test_Name, test_Type> types { get; set; }
  public IDictionary<test_Name, test_Setting> settings { get; set; }
}

public interface Itest_Name
  : IDomainString
{
}

public interface Itest_Filter
{
  public ICollection<test_NameFilter> As_NameFilter { get; set; }
  public test_Filter _Filter { get; set; }
}

public interface Itest_FilterObject
{
  public ICollection<test_NameFilter> names { get; set; }
  public testBoolean? matchAliases { get; set; }
  public ICollection<test_NameFilter> aliases { get; set; }
  public testBoolean? returnByAlias { get; set; }
  public testBoolean? returnReferencedTypes { get; set; }
}

public interface Itest_NameFilter
  : IDomainString
{
}

public interface Itest_CategoryFilter
  : Itest_Filter
{
  public test_CategoryFilter _CategoryFilter { get; set; }
}

public interface Itest_CategoryFilterObject
  : Itest_FilterObject
{
  public ICollection<test_Resolution> resolutions { get; set; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
  public test_TypeFilter _TypeFilter { get; set; }
}

public interface Itest_TypeFilterObject
  : Itest_FilterObject
{
  public ICollection<test_TypeKind> kinds { get; set; }
}
