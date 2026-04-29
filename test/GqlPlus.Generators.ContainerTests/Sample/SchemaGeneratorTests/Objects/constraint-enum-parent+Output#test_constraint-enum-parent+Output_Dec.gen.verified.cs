//HintName: test_constraint-enum-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

internal class testEnumCnstEnumPrntOutpDecoder : IDecoder<testEnumCnstEnumPrntOutp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstEnumPrntOutp? output)
    => input.DecodeEnum("EnumCnstEnumPrntOutp", out output);

  internal static testEnumCnstEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstEnumPrntOutpDecoder : IDecoder<testParentCnstEnumPrntOutp?>
{
  public IMessages Decoder(IValue input, out testParentCnstEnumPrntOutp? output)
    => input.DecodeEnum("ParentCnstEnumPrntOutp", out output);

  internal static testParentCnstEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_enum_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumCnstEnumPrntOutp?>(testEnumCnstEnumPrntOutpDecoder.Factory)
      .AddDecoder<testParentCnstEnumPrntOutp?>(testParentCnstEnumPrntOutpDecoder.Factory);
}
