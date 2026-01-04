//HintName: test_-Schema_Intf.gen.cs
// Generated from -Schema.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Schema;

public interface Itest_Schema
  : Itest_Named
{
  public test_Schema _Schema { get; set; }
}

public interface Itest_SchemaField
  : Itest_NamedField
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

public interface Itest_FilterField
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

public interface Itest_CategoryFilterField
  : Itest_FilterField
{
  public ICollection<test_Resolution> resolutions { get; set; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
  public test_TypeFilter _TypeFilter { get; set; }
}

public interface Itest_TypeFilterField
  : Itest_FilterField
{
  public ICollection<test_TypeKind> kinds { get; set; }
}

public interface Itest_Aliased
  : Itest_Named
{
  public test_Aliased _Aliased { get; set; }
}

public interface Itest_AliasedField
  : Itest_NamedField
{
  public ICollection<test_Name> aliases { get; set; }
}

public interface Itest_Named
  : Itest_Described
{
  public test_Named _Named { get; set; }
}

public interface Itest_NamedField
  : Itest_DescribedField
{
  public test_Name name { get; set; }
}

public interface Itest_Described
{
  public test_Described _Described { get; set; }
}

public interface Itest_DescribedField
{
  public ICollection<testString> description { get; set; }
}
