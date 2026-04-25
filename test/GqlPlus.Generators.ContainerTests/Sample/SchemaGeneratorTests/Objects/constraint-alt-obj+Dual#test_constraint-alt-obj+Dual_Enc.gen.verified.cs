//HintName: test_constraint-alt-obj+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

internal class testCnstAltObjDualEncoder : IEncoder<ItestCnstAltObjDualObject>
{
  public Structured Encode(ItestCnstAltObjDualObject input)
    => Structured.Empty();

  internal static testCnstAltObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltObjDualEncoder<TRef> : IEncoder<ItestRefCnstAltObjDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltObjDualObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltObjDualEncoder : IEncoder<ItestPrntCnstAltObjDualObject>
{
  public Structured Encode(ItestPrntCnstAltObjDualObject input)
    => Structured.Empty();

  internal static testPrntCnstAltObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjDualObject>
{
  private readonly IEncoder<ItestPrntCnstAltObjDualObject> _itestPrntCnstAltObjDual = encoders.EncoderFor<ItestPrntCnstAltObjDualObject>();
  public Structured Encode(ItestAltCnstAltObjDualObject input)
    => _itestPrntCnstAltObjDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltObjDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_alt_obj_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_alt_obj_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstAltObjDualObject>(testCnstAltObjDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltObjDualObject>(testPrntCnstAltObjDualEncoder.Factory)
      .AddEncoder<ItestAltCnstAltObjDualObject>(testAltCnstAltObjDualEncoder.Factory);
}
