//HintName: test_generic-parent-enum-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

internal class testGnrcPrntEnumPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>> _itestFieldGnrcPrntEnumPrntDual = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>>();
  public Structured Encode(ItestGnrcPrntEnumPrntDualObject input)
    => _itestFieldGnrcPrntEnumPrntDual.Encode(input);
}

internal class testFieldGnrcPrntEnumPrntDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumPrntDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumPrntDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumPrntDualEncoder : IEncoder<testEnumGnrcPrntEnumPrntDual>
{
  public Structured Encode(testEnumGnrcPrntEnumPrntDual input)
    => new(input.ToString(), "_EnumGnrcPrntEnumPrntDual");
}

internal class testParentGnrcPrntEnumPrntDualEncoder : IEncoder<testParentGnrcPrntEnumPrntDual>
{
  public Structured Encode(testParentGnrcPrntEnumPrntDual input)
    => new(input.ToString(), "_ParentGnrcPrntEnumPrntDual");
}

internal static class test_generic_parent_enum_parent_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_enum_parent_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntEnumPrntDualObject>(r => new testGnrcPrntEnumPrntDualEncoder(r))
      .AddEncoder<testEnumGnrcPrntEnumPrntDual>(_ => new testEnumGnrcPrntEnumPrntDualEncoder())
      .AddEncoder<testParentGnrcPrntEnumPrntDual>(_ => new testParentGnrcPrntEnumPrntDualEncoder());
}
