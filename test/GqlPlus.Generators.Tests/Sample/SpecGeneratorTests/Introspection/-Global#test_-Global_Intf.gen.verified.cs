//HintName: test_-Global_Intf.gen.cs
// Generated from -Global.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Global;

public interface Itest_AndType
  : Itest_Named
{
  _Type type { get; }
  _Type As_Type { get; }
}

public interface Itest_Categories
  : Itest_AndType
{
  _Category category { get; }
  _Category As_Category { get; }
}

public interface Itest_Category
  : Itest_Aliased
{
  _Resolution resolution { get; }
  _TypeRef<_TypeKind> output { get; }
  _Modifiers modifiers { get; }
}

public interface Itest_Directives
  : Itest_AndType
{
  _Directive directive { get; }
  _Directive As_Directive { get; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  _InputParam parameters { get; }
  Boolean repeatable { get; }
  Unit locations { get; }
}

public interface Itest_Setting
  : Itest_Named
{
  _Value value { get; }
}
