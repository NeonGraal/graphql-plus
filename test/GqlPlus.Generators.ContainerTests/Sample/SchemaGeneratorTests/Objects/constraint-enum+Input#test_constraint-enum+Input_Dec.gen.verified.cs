//HintName: test_constraint-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

internal class testCnstEnumInpDecoder : IDecoder<ItestCnstEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstEnumInpDecoder : IDecoder<testEnumCnstEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumCnstEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstEnumInp".AnError();
  }

  internal static testEnumCnstEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstEnumInpObject>(testCnstEnumInpDecoder.Factory)
      .AddDecoder<testEnumCnstEnumInp?>(testEnumCnstEnumInpDecoder.Factory);
}
