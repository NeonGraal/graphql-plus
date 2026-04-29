//HintName: test_constraint-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

internal class testCnstEnumInpDecoder
{

  internal static testCnstEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstEnumInpDecoder : IDecoder<testEnumCnstEnumInp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstEnumInp? output)
    => input.DecodeEnum("EnumCnstEnumInp", out output);

  internal static testEnumCnstEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstEnumInpObject>(testCnstEnumInpDecoder.Factory)
      .AddDecoder<testEnumCnstEnumInp?>(testEnumCnstEnumInpDecoder.Factory);
}
