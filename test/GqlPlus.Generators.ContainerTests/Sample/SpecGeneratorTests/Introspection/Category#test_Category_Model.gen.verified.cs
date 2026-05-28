//HintName: test_Category_Model.gen.cs
// Generated from {CurrentDirectory}Category.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Category;

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public Itest_Category? As_Category { get; set; }
  public Itest_CategoriesObject? As__Categories { get; set; }
}

public class test_CategoriesObject
  : test_AndTypeObject
  , Itest_CategoriesObject
{
  public Itest_Category Category { get; set; }

  public test_CategoriesObject
    ( Itest_Category pcategory
    )
  {
    Category = pcategory;
  }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public Itest_CategoryObject? As__Category { get; set; }
}

public class test_CategoryObject
  : test_AliasedObject
  , Itest_CategoryObject
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<Itest_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }

  public test_CategoryObject
    ( test_Resolution presolution
    , Itest_TypeRef<Itest_TypeKind> poutput
    , ICollection<Itest_Modifiers> pmodifiers
    )
  {
    Resolution = presolution;
    Output = poutput;
    Modifiers = pmodifiers;
  }
}
