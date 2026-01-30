//HintName: test_Category_Intf.gen.cs
// Generated from Category.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Category;

public interface Itest_Categories
  : Itest_AndType
{
  public test_Category As_Category { get; set; }
  public test_Categories _Categories { get; set; }
}

public interface Itest_CategoriesObject
  : Itest_AndTypeObject
{
  public test_Category category { get; set; }
}

public interface Itest_Category
  : Itest_Aliased
{
  public test_Category _Category { get; set; }
}

public interface Itest_CategoryObject
  : Itest_AliasedObject
{
  public test_Resolution resolution { get; set; }
  public test_TypeRef<test_TypeKind> output { get; set; }
  public ICollection<test_Modifiers> modifiers { get; set; }
}
