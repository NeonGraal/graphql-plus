//HintName: test_-Global_Intf.gen.cs
// Generated from -Global.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

public interface Itest_AndType
  : Itest_Named
{
  public test_Type As_Type { get; set; }
  public test_AndType _AndType { get; set; }
}

public interface Itest_AndTypeField
  : Itest_NamedField
{
  public test_Type type { get; set; }
}

public interface Itest_Categories
  : Itest_AndType
{
  public test_Category As_Category { get; set; }
  public test_Categories _Categories { get; set; }
}

public interface Itest_CategoriesField
  : Itest_AndTypeField
{
  public test_Category category { get; set; }
}

public interface Itest_Category
  : Itest_Aliased
{
  public test_Category _Category { get; set; }
}

public interface Itest_CategoryField
  : Itest_AliasedField
{
  public test_Resolution resolution { get; set; }
  public test_TypeRef<test_TypeKind> output { get; set; }
  public ICollection<test_Modifiers> modifiers { get; set; }
}

public interface Itest_Directives
  : Itest_AndType
{
  public test_Directive As_Directive { get; set; }
  public test_Directives _Directives { get; set; }
}

public interface Itest_DirectivesField
  : Itest_AndTypeField
{
  public test_Directive directive { get; set; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  public test_Directive _Directive { get; set; }
}

public interface Itest_DirectiveField
  : Itest_AliasedField
{
  public ICollection<test_InputParam> parameters { get; set; }
  public testBoolean repeatable { get; set; }
  public IDictionary<test_Location, testUnit> locations { get; set; }
}

public interface Itest_Setting
  : Itest_Named
{
  public test_Setting _Setting { get; set; }
}

public interface Itest_SettingField
  : Itest_NamedField
{
  public test_Value value { get; set; }
}
