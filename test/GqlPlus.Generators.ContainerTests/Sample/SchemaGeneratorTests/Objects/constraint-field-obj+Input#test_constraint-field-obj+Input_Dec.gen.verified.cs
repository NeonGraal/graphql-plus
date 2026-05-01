//HintName: test_constraint-field-obj+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

internal class testCnstFieldObjInpDecoder : IDecoder<ItestCnstFieldObjInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstFieldObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldObjInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testPrntCnstFieldObjInpDecoder : IDecoder<ItestPrntCnstFieldObjInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstFieldObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldObjInpDecoder : IDecoder<ItestAltCnstFieldObjInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstFieldObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_field_obj_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_obj_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldObjInpObject>(testCnstFieldObjInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstFieldObjInpObject>(testPrntCnstFieldObjInpDecoder.Factory)
      .AddDecoder<ItestAltCnstFieldObjInpObject>(testAltCnstFieldObjInpDecoder.Factory);
}
