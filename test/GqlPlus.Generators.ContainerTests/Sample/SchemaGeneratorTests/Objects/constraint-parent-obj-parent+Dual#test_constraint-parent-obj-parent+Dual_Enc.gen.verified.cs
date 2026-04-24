//HintName: test_constraint-parent-obj-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

internal class testCnstPrntObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntDualObject>
{
  private readonly IEncoder<ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>> _itestRefCnstPrntObjPrntDual = encoders.EncoderFor<ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>>();
  public Structured Encode(ItestCnstPrntObjPrntDualObject input)
    => _itestRefCnstPrntObjPrntDual.Encode(input);

  internal static testCnstPrntObjPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntObjPrntDualEncoder<TRef> : IEncoder<ItestRefCnstPrntObjPrntDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntObjPrntDualObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntObjPrntDualEncoder : IEncoder<ItestPrntCnstPrntObjPrntDualObject>
{
  public Structured Encode(ItestPrntCnstPrntObjPrntDualObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntObjPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntDualObject>
{
  private readonly IEncoder<ItestPrntCnstPrntObjPrntDualObject> _itestPrntCnstPrntObjPrntDual = encoders.EncoderFor<ItestPrntCnstPrntObjPrntDualObject>();
  public Structured Encode(ItestAltCnstPrntObjPrntDualObject input)
    => _itestPrntCnstPrntObjPrntDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntObjPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_parent_obj_parent_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_obj_parent_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntObjPrntDualObject>(testCnstPrntObjPrntDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntObjPrntDualObject>(testPrntCnstPrntObjPrntDualEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntObjPrntDualObject>(testAltCnstPrntObjPrntDualEncoder.Factory);
}
