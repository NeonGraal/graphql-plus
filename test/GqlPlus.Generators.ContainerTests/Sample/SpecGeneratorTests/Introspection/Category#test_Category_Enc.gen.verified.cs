//HintName: test_Category_Enc.gen.cs
// Generated from {CurrentDirectory}Category.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Category;

internal class test_CategoriesEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_CategoriesObject>
{
  private readonly IEncoder<Itest_AndTypeObject> _itest_AndType = encoders.EncoderFor<Itest_AndTypeObject>();
  private readonly IEncoder<Itest_Category> _itest_Category = encoders.EncoderFor<Itest_Category>();
  public Structured Encode(Itest_CategoriesObject input)
    => _itest_AndType.Encode(input)
      .AddEncoded("category", input.Category, _itest_Category);

  internal static test_CategoriesEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_CategoryEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_CategoryObject>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<Itest_TypeRef<Itest_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRef<Itest_TypeKind>>();
  private readonly IEncoder<Itest_Modifiers> _itest_Modifiers = encoders.EncoderFor<Itest_Modifiers>();
  public Structured Encode(Itest_CategoryObject input)
    => _itest_Aliased.Encode(input)
      .AddEnum("resolution", input.Resolution)
      .AddEncoded("output", input.Output, _itest_TypeRef)
      .AddList("modifiers", input.Modifiers, _itest_Modifiers);

  internal static test_CategoryEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_ResolutionEncoder : IEncoder<test_Resolution>
{
  public Structured Encode(test_Resolution input)
    => new(input.ToString(), "_Resolution");

  internal static test_ResolutionEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_CategoryEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_CategoryEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_CategoriesObject>(test_CategoriesEncoder.Factory)
      .AddEncoder<Itest_CategoryObject>(test_CategoryEncoder.Factory)
      .AddEncoder<test_Resolution>(test_ResolutionEncoder.Factory);
}
