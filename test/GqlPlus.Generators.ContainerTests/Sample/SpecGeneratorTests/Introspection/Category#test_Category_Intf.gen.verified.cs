//HintName: test_Category_Intf.gen.cs
// Generated from Category.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Category;

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
