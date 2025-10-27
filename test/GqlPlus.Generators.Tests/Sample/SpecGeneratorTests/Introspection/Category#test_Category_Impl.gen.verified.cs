//HintName: test_Category_Impl.gen.cs
// Generated from Category.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Category;

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public _Category category { get; set; }
  public _Category As_Category { get; set; }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public _Resolution resolution { get; set; }
  public _TypeRef<_TypeKind> output { get; set; }
  public _Modifiers modifiers { get; set; }
}
