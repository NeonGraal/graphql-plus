//HintName: test_constraint-field-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

internal class testCnstFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualDualObject>
{
  private readonly IEncoder<ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>> _itestRefCnstFieldDualDual = encoders.EncoderFor<ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>>();
  public Structured Encode(ItestCnstFieldDualDualObject input)
    => _itestRefCnstFieldDualDual.Encode(input);

  internal static testCnstFieldDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDualDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDualDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDualDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldDualDualEncoder : IEncoder<ItestPrntCnstFieldDualDualObject>
{
  public Structured Encode(ItestPrntCnstFieldDualDualObject input)
    => Structured.Empty();

  internal static testPrntCnstFieldDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualDualObject>
{
  private readonly IEncoder<ItestPrntCnstFieldDualDualObject> _itestPrntCnstFieldDualDual = encoders.EncoderFor<ItestPrntCnstFieldDualDualObject>();
  public Structured Encode(ItestAltCnstFieldDualDualObject input)
    => _itestPrntCnstFieldDualDual.Encode(input)
      .Add("alt", input.Alt);

  internal static testAltCnstFieldDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_field_dual_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_field_dual_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstFieldDualDualObject>(testCnstFieldDualDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldDualDualObject>(testPrntCnstFieldDualDualEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldDualDualObject>(testAltCnstFieldDualDualEncoder.Factory);
}
