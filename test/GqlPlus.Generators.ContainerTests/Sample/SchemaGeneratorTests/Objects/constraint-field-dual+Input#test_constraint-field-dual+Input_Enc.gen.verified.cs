//HintName: test_constraint-field-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

internal class testCnstFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualInpObject>
{
  private readonly Encoder<ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>> _itestRefCnstFieldDualInp = encoders.EncoderFor<ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>>();
  public IGqlpValue Encode(ItestCnstFieldDualInpObject input)
    => _itestRefCnstFieldDualInp.Encode(input);

  internal static testCnstFieldDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDualInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDualInpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestRefCnstFieldDualInpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldDualInpEncoder : IEncoder<ItestPrntCnstFieldDualInpObject>
{
  public IGqlpValue Encode(ItestPrntCnstFieldDualInpObject input)
    => new GqlpUnit();

  internal static testPrntCnstFieldDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualInpObject>
{
  private readonly Encoder<ItestPrntCnstFieldDualInpObject> _itestPrntCnstFieldDualInp = encoders.EncoderFor<ItestPrntCnstFieldDualInpObject>();
  public IGqlpValue Encode(ItestAltCnstFieldDualInpObject input)
    => _itestPrntCnstFieldDualInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_field_dual_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_field_dual_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstFieldDualInpObject>(testCnstFieldDualInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldDualInpObject>(testPrntCnstFieldDualInpEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldDualInpObject>(testAltCnstFieldDualInpEncoder.Factory);
}
