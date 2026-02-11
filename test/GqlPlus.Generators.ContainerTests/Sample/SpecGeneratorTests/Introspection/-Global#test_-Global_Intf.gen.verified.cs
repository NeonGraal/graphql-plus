//HintName: test_-Global_Intf.gen.cs
// Generated from -Global.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

public interface Itest_AndType
  : Itest_Named
{
  Itest_Type As_Type { get; }
  Itest_AndTypeObject As_AndType { get; }
}

public interface Itest_AndTypeObject
  : Itest_NamedObject
{
  Itest_Type Type { get; }
}

public interface Itest_Categories
  : Itest_AndType
{
  Itest_Category As_Category { get; }
  Itest_CategoriesObject As_Categories { get; }
}

public interface Itest_CategoriesObject
  : Itest_AndTypeObject
{
  Itest_Category Category { get; }
}

public interface Itest_Category
  : Itest_Aliased
{
  Itest_CategoryObject As_Category { get; }
}

public interface Itest_CategoryObject
  : Itest_AliasedObject
{
  test_Resolution Resolution { get; }
  Itest_TypeRef<Itest_TypeKind> Output { get; }
  ICollection<Itest_Modifiers> Modifiers { get; }
}

public interface Itest_Directives
  : Itest_AndType
{
  Itest_Directive As_Directive { get; }
  Itest_DirectivesObject As_Directives { get; }
}

public interface Itest_DirectivesObject
  : Itest_AndTypeObject
{
  Itest_Directive Directive { get; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  Itest_DirectiveObject As_Directive { get; }
}

public interface Itest_DirectiveObject
  : Itest_AliasedObject
{
  ICollection<Itest_InputParam> Parameters { get; }
  bool Repeatable { get; }
  IDictionary<test_Location, testUnit> Locations { get; }
}

public interface Itest_Setting
  : Itest_Named
{
  Itest_SettingObject As_Setting { get; }
}

public interface Itest_SettingObject
  : Itest_NamedObject
{
  Itest_Value Value { get; }
}
