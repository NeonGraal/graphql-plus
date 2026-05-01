//HintName: test_constraint-alt-obj+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

internal class testCnstAltObjInpDecoder : IDecoder<ItestCnstAltObjInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstAltObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstAltObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltObjInpDecoder<TRef>
{
}

internal class testPrntCnstAltObjInpDecoder : IDecoder<ItestPrntCnstAltObjInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstAltObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstAltObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltObjInpDecoder : IDecoder<ItestAltCnstAltObjInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstAltObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstAltObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_alt_obj_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_obj_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltObjInpObject>(testCnstAltObjInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstAltObjInpObject>(testPrntCnstAltObjInpDecoder.Factory)
      .AddDecoder<ItestAltCnstAltObjInpObject>(testAltCnstAltObjInpDecoder.Factory);
}
