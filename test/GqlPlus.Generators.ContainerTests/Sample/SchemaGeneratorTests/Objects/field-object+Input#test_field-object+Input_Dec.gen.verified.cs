//HintName: test_field-object+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-object+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Input;

internal class testFieldObjInpDecoder : IDecoder<ItestFieldObjInpObject>
{
  public ItestFldFieldObjInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldObjInpDecoder : IDecoder<ItestFldFieldObjInpObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFldFieldObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_object_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_object_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldObjInpObject>(testFieldObjInpDecoder.Factory)
      .AddDecoder<ItestFldFieldObjInpObject>(testFldFieldObjInpDecoder.Factory);
}
