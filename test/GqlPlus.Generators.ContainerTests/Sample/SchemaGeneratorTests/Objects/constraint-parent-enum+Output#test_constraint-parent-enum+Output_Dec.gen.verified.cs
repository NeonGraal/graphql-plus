//HintName: test_constraint-parent-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

internal class testEnumCnstPrntEnumOutpDecoder : IDecoder<testEnumCnstPrntEnumOutp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstPrntEnumOutp? output)
    => input.DecodeEnum("EnumCnstPrntEnumOutp", out output);

  internal static testEnumCnstPrntEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstPrntEnumOutpDecoder : IDecoder<testParentCnstPrntEnumOutp?>
{
  public IMessages Decoder(IValue input, out testParentCnstPrntEnumOutp? output)
    => input.DecodeEnum("ParentCnstPrntEnumOutp", out output);

  internal static testParentCnstPrntEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumCnstPrntEnumOutp?>(testEnumCnstPrntEnumOutpDecoder.Factory)
      .AddDecoder<testParentCnstPrntEnumOutp?>(testParentCnstPrntEnumOutpDecoder.Factory);
}
