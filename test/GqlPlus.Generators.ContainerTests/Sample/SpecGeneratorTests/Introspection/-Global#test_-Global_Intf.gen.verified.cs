//HintName: test_-Global_Intf.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

public interface Itest_AndType
  : Itest_Named
{
  Itest_Type? As_Type { get; }
  Itest_AndTypeObject? As__AndType { get; }
}

public interface Itest_AndTypeObject
  : Itest_NamedObject
{
  Itest_Type Type { get; }
}

public interface Itest_Categories
  : Itest_AndType
{
  Itest_Category? As_Category { get; }
  Itest_CategoriesObject? As__Categories { get; }
}

public interface Itest_CategoriesObject
  : Itest_AndTypeObject
{
  Itest_Category Category { get; }
}

public interface Itest_Category
  : Itest_Aliased
{
  Itest_CategoryObject? As__Category { get; }
}

public interface Itest_CategoryObject
  : Itest_AliasedObject
{
  test_Resolution Resolution { get; }
  Itest_TypeRef<Itest_TypeKind> Output { get; }
  ICollection<Itest_Modifiers> Modifiers { get; }
}

public enum test_Resolution
{
  Parallel,
  Sequential,
  Single,
}

public interface Itest_Directives
  : Itest_AndType
{
  Itest_Directive? As_Directive { get; }
  Itest_DirectivesObject? As__Directives { get; }
}

public interface Itest_DirectivesObject
  : Itest_AndTypeObject
{
  Itest_Directive Directive { get; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  Itest_DirectiveObject? As__Directive { get; }
}

public interface Itest_DirectiveObject
  : Itest_AliasedObject
{
  Itest_InputFieldType? Parameter { get; }
  bool Repeatable { get; }
  IDictionary<test_Location, GqlpUnit> Locations { get; }
}

public enum test_Location
{
  Operation,
  Variable,
  Field,
  Inline,
  Spread,
  Fragment,
}

public interface Itest_Setting
  : Itest_Named
{
  Itest_SettingObject? As__Setting { get; }
}

public interface Itest_SettingObject
  : Itest_NamedObject
{
  GqlpValue Value { get; }
}
