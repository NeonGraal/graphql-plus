//HintName: test_constraint-field-domain+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Dual;

internal class testCnstFieldDmnDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnDualObject>
{
  private readonly IEncoder<ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>> _itestRefCnstFieldDmnDual = encoders.EncoderFor<ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>>();
  public Structured Encode(ItestCnstFieldDmnDualObject input)
    => _itestRefCnstFieldDmnDual.Encode(input);

  internal static testCnstFieldDmnDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDmnDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDmnDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDmnDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomCnstFieldDmnDualEncoder : IEncoder<ItestDomCnstFieldDmnDual>
{
  public Structured Encode(ItestDomCnstFieldDmnDual input)
    => new(input.Value);

  internal static testDomCnstFieldDmnDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_field_domain_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_field_domain_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstFieldDmnDualObject>(testCnstFieldDmnDualEncoder.Factory)
      .AddEncoder<ItestDomCnstFieldDmnDual>(testDomCnstFieldDmnDualEncoder.Factory);
}
