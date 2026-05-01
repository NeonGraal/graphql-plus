//HintName: test_constraint-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

internal class testEnumCnstEnumOutpDecoder : IDecoder<testEnumCnstEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumCnstEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstEnumOutp".AnError();
  }

  internal static testEnumCnstEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumCnstEnumOutp?>(testEnumCnstEnumOutpDecoder.Factory);
}
