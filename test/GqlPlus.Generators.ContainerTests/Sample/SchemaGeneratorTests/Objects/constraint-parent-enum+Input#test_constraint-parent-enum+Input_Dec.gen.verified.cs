//HintName: test_constraint-parent-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

internal class testCnstPrntEnumInpDecoder : IDecoder<ItestCnstPrntEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstPrntEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstPrntEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntEnumInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstPrntEnumInpDecoder : IDecoder<testEnumCnstPrntEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumCnstPrntEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstPrntEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstPrntEnumInp".AnError();
  }

  internal static testEnumCnstPrntEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstPrntEnumInpDecoder : IDecoder<testParentCnstPrntEnumInp?>
{
  public IMessages Decode(IValue input, out testParentCnstPrntEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentCnstPrntEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentCnstPrntEnumInp".AnError();
  }

  internal static testParentCnstPrntEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntEnumInpObject>(testCnstPrntEnumInpDecoder.Factory)
      .AddDecoder<testEnumCnstPrntEnumInp?>(testEnumCnstPrntEnumInpDecoder.Factory)
      .AddDecoder<testParentCnstPrntEnumInp?>(testParentCnstPrntEnumInpDecoder.Factory);
}
