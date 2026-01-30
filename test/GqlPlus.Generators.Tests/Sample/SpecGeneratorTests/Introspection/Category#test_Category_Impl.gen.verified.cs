//HintName: test_Category_Impl.gen.cs
// Generated from Category.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Category;

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public test_Category category { get; set; }
  public test_Category As_Category { get; set; }
  public test_Categories _Categories { get; set; }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public test_Resolution resolution { get; set; }
  public test_TypeRef<test_TypeKind> output { get; set; }
  public ICollection<test_Modifiers> modifiers { get; set; }
  public test_Category _Category { get; set; }
}
