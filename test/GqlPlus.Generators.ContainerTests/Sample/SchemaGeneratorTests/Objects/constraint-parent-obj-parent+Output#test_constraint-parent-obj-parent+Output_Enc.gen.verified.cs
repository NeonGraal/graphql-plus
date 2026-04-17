//HintName: test_constraint-parent-obj-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Output;

internal class testCnstPrntObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntOutpObject>
{
  private readonly IEncoder<ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>> _itestRefCnstPrntObjPrntOutp = encoders.EncoderFor<ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>>();
  public Structured Encode(ItestCnstPrntObjPrntOutpObject input)
    => _itestRefCnstPrntObjPrntOutp.Encode(input);

  internal static testCnstPrntObjPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntObjPrntOutpEncoder<TRef> : IEncoder<ItestRefCnstPrntObjPrntOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntObjPrntOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntObjPrntOutpEncoder : IEncoder<ItestPrntCnstPrntObjPrntOutpObject>
{
  public Structured Encode(ItestPrntCnstPrntObjPrntOutpObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntObjPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntOutpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntObjPrntOutpObject> _itestPrntCnstPrntObjPrntOutp = encoders.EncoderFor<ItestPrntCnstPrntObjPrntOutpObject>();
  public Structured Encode(ItestAltCnstPrntObjPrntOutpObject input)
    => _itestPrntCnstPrntObjPrntOutp.Encode(input)
      .Add("alt", input.Alt);

  internal static testAltCnstPrntObjPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_parent_obj_parent_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_obj_parent_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntObjPrntOutpObject>(testCnstPrntObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntObjPrntOutpObject>(testPrntCnstPrntObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntObjPrntOutpObject>(testAltCnstPrntObjPrntOutpEncoder.Factory);
}
