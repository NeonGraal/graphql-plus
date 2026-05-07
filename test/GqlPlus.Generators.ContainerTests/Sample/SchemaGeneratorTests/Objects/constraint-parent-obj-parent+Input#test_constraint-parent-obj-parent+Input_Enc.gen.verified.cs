//HintName: test_constraint-parent-obj-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

internal class testCnstPrntObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntInpObject>
{
  private readonly IEncoder<ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>> _itestRefCnstPrntObjPrntInp = encoders.EncoderFor<ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>>();
  public Structured Encode(ItestCnstPrntObjPrntInpObject input)
    => _itestRefCnstPrntObjPrntInp.Encode(input);

  internal static testCnstPrntObjPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntObjPrntInpEncoder<TRef> : IEncoder<ItestRefCnstPrntObjPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntObjPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntObjPrntInpEncoder : IEncoder<ItestPrntCnstPrntObjPrntInpObject>
{
  public Structured Encode(ItestPrntCnstPrntObjPrntInpObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntObjPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntInpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntObjPrntInpObject> _itestPrntCnstPrntObjPrntInp = encoders.EncoderFor<ItestPrntCnstPrntObjPrntInpObject>();
  public Structured Encode(ItestAltCnstPrntObjPrntInpObject input)
    => _itestPrntCnstPrntObjPrntInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntObjPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_parent_obj_parent_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_obj_parent_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntObjPrntInpObject>(testCnstPrntObjPrntInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntObjPrntInpObject>(testPrntCnstPrntObjPrntInpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntObjPrntInpObject>(testAltCnstPrntObjPrntInpEncoder.Factory);
}
