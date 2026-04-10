//HintName: test_Category_Dec.gen.cs
// Generated from {CurrentDirectory}Category.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Category;

internal class test_CategoriesDecoder
{
  public Itest_Category Category { get; set; }
}

internal class test_CategoryDecoder
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<Itest_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

internal class test_ResolutionDecoder
{
  public string Parallel { get; set; }
  public string Sequential { get; set; }
  public string Single { get; set; }
}
