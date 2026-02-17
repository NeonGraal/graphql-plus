//HintName: test_Category_Impl.gen.cs
// Generated from {CurrentDirectory}Category.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Category;

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public Itest_Category Category { get; set; }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<Itest_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}
