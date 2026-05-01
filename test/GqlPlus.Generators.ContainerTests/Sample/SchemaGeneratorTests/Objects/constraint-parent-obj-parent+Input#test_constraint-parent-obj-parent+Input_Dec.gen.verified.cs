//HintName: test_constraint-parent-obj-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

internal class testCnstPrntObjPrntInpDecoder : IDecoder<ItestCnstPrntObjPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstPrntObjPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstPrntObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntObjPrntInpDecoder<TRef>
{
}

internal class testPrntCnstPrntObjPrntInpDecoder : IDecoder<ItestPrntCnstPrntObjPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstPrntObjPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstPrntObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntInpDecoder : IDecoder<ItestAltCnstPrntObjPrntInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstPrntObjPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstPrntObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_obj_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_obj_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntObjPrntInpObject>(testCnstPrntObjPrntInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntObjPrntInpObject>(testPrntCnstPrntObjPrntInpDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntObjPrntInpObject>(testAltCnstPrntObjPrntInpDecoder.Factory);
}
