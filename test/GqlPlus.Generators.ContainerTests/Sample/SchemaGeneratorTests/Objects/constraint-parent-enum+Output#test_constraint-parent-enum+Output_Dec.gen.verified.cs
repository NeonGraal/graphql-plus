//HintName: test_constraint-parent-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

internal class testEnumCnstPrntEnumOutpDecoder : IDecoder<testEnumCnstPrntEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumCnstPrntEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstPrntEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstPrntEnumOutp".AnError();
  }

  internal static testEnumCnstPrntEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstPrntEnumOutpDecoder : IDecoder<testParentCnstPrntEnumOutp?>
{
  public IMessages Decode(IValue input, out testParentCnstPrntEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentCnstPrntEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentCnstPrntEnumOutp".AnError();
  }

  internal static testParentCnstPrntEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumCnstPrntEnumOutp?>(testEnumCnstPrntEnumOutpDecoder.Factory)
      .AddDecoder<testParentCnstPrntEnumOutp?>(testParentCnstPrntEnumOutpDecoder.Factory);
}
