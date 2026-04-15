//HintName: test_generic-parent-enum-child+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

internal class testGnrcPrntEnumChildDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumChildDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>> _itestFieldGnrcPrntEnumChildDual = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>>();
  public Structured Encode(ItestGnrcPrntEnumChildDualObject input)
    => _itestFieldGnrcPrntEnumChildDual.Encode(input);
}

internal class testFieldGnrcPrntEnumChildDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumChildDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumChildDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumChildDualEncoder : IEncoder<testEnumGnrcPrntEnumChildDual>
{
  public Structured Encode(testEnumGnrcPrntEnumChildDual input)
    => new(input.ToString(), "_EnumGnrcPrntEnumChildDual");
}

internal class testParentGnrcPrntEnumChildDualEncoder : IEncoder<testParentGnrcPrntEnumChildDual>
{
  public Structured Encode(testParentGnrcPrntEnumChildDual input)
    => new(input.ToString(), "_ParentGnrcPrntEnumChildDual");
}

internal static class test_generic_parent_enum_child_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_enum_child_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntEnumChildDualObject>(r => new testGnrcPrntEnumChildDualEncoder(r))
      .AddEncoder<testEnumGnrcPrntEnumChildDual>(_ => new testEnumGnrcPrntEnumChildDualEncoder())
      .AddEncoder<testParentGnrcPrntEnumChildDual>(_ => new testParentGnrcPrntEnumChildDualEncoder());
}
