//HintName: test_constraint-field-domain+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

internal class testCnstFieldDmnInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnInpObject>
{
  private readonly Encoder<ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>> _itestRefCnstFieldDmnInp = encoders.EncoderFor<ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>>();
  public IGqlpValue Encode(ItestCnstFieldDmnInpObject input)
    => _itestRefCnstFieldDmnInp.Encode(input);

  internal static testCnstFieldDmnInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDmnInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDmnInpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestRefCnstFieldDmnInpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomCnstFieldDmnInpEncoder : IEncoder<ItestDomCnstFieldDmnInp>
{
  public IGqlpValue Encode(ItestDomCnstFieldDmnInp input)
    => input.Value!.Encode();

  internal static testDomCnstFieldDmnInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_field_domain_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_field_domain_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstFieldDmnInpObject>(testCnstFieldDmnInpEncoder.Factory)
      .AddEncoder<ItestDomCnstFieldDmnInp>(testDomCnstFieldDmnInpEncoder.Factory);
}
