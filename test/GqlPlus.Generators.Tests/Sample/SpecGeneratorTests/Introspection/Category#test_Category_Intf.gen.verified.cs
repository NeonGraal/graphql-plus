//HintName: test_Category_Intf.gen.cs
// Generated from Category.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Category;

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
