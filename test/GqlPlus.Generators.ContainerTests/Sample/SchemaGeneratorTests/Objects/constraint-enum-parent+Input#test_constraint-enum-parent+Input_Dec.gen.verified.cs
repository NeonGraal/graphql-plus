//HintName: test_constraint-enum-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

internal class testCnstEnumPrntInpDecoder
{

  internal static testCnstEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumPrntInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstEnumPrntInpDecoder : IDecoder<testEnumCnstEnumPrntInp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstEnumPrntInp? output)
    => input.DecodeEnum("EnumCnstEnumPrntInp", out output);

  internal static testEnumCnstEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstEnumPrntInpDecoder : IDecoder<testParentCnstEnumPrntInp?>
{
  public IMessages Decoder(IValue input, out testParentCnstEnumPrntInp? output)
    => input.DecodeEnum("ParentCnstEnumPrntInp", out output);

  internal static testParentCnstEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_enum_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstEnumPrntInpObject>(testCnstEnumPrntInpDecoder.Factory)
      .AddDecoder<testEnumCnstEnumPrntInp?>(testEnumCnstEnumPrntInpDecoder.Factory)
      .AddDecoder<testParentCnstEnumPrntInp?>(testParentCnstEnumPrntInpDecoder.Factory);
}
