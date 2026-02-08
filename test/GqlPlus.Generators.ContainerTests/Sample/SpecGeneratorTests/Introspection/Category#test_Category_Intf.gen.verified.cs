//HintName: test_Category_Intf.gen.cs
// Generated from Category.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Category;

public interface Itest_Categories
  : Itest_AndType
{
  public Itest_Category As_Category { get; set; }
  public Itest_CategoriesObject As_Categories { get; set; }
}

public interface Itest_CategoriesObject
  : Itest_AndTypeObject
{
  public Itest_Category Category { get; set; }
}

public interface Itest_Category
  : Itest_Aliased
{
  public Itest_CategoryObject As_Category { get; set; }
}

public interface Itest_CategoryObject
  : Itest_AliasedObject
{
  public Itest_Resolution Resolution { get; set; }
  public Itest_TypeRef<Itest_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}
