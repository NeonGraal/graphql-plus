//HintName: test_+Simple_Dec.gen.cs
// Generated from {CurrentDirectory}+Simple.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

internal class testDmnBoolDescrDecoder : IDecoder<ItestDmnBoolDescr>
{

  public IMessages Decode(IValue input, out ItestDmnBoolDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolPrntDecoder : IDecoder<ItestDmnBoolPrnt>
{

  public IMessages Decode(IValue input, out ItestDmnBoolPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDecoder : IDecoder<ItestPrntDmnBoolPrnt>
{

  public IMessages Decode(IValue input, out ItestPrntDmnBoolPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnBoolPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolPrntDescrDecoder : IDecoder<ItestDmnBoolPrntDescr>
{

  public IMessages Decode(IValue input, out ItestDmnBoolPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDescrDecoder : IDecoder<ItestPrntDmnBoolPrntDescr>
{

  public IMessages Decode(IValue input, out ItestPrntDmnBoolPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnBoolPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumAllDecoder : IDecoder<ItestDmnEnumAll>
{
  public testEnumDmnEnumAll? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumAll? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllDecoder : IDecoder<testEnumDmnEnumAll?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumAll? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumAll value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumAll".AnError();
  }

  internal static testEnumDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumAllDescrDecoder : IDecoder<ItestDmnEnumAllDescr>
{
  public testEnumDmnEnumAllDescr? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumAllDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumAllDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllDescrDecoder : IDecoder<testEnumDmnEnumAllDescr?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumAllDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumAllDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumAllDescr".AnError();
  }

  internal static testEnumDmnEnumAllDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumAllPrntDecoder : IDecoder<ItestDmnEnumAllPrnt>
{
  public testEnumDmnEnumAllPrnt? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumAllPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllPrntDecoder : IDecoder<testEnumDmnEnumAllPrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumAllPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumAllPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumAllPrnt".AnError();
  }

  internal static testEnumDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumAllPrntDecoder : IDecoder<testPrntDmnEnumAllPrnt?>
{
  public IMessages Decode(IValue input, out testPrntDmnEnumAllPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntDmnEnumAllPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntDmnEnumAllPrnt".AnError();
  }

  internal static testPrntDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumDescrDecoder : IDecoder<ItestDmnEnumDescr>
{
  public testEnumDmnEnumDescr? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumDescrDecoder : IDecoder<testEnumDmnEnumDescr?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumDescr".AnError();
  }

  internal static testEnumDmnEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumExclDecoder : IDecoder<ItestDmnEnumExcl>
{
  public testEnumDmnEnumExcl? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumExcl? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumExclDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumExclDecoder : IDecoder<testEnumDmnEnumExcl?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumExcl? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumExcl value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumExcl".AnError();
  }

  internal static testEnumDmnEnumExclDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumExclPrntDecoder : IDecoder<ItestDmnEnumExclPrnt>
{

  public IMessages Decode(IValue input, out ItestDmnEnumExclPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumExclPrntDecoder : IDecoder<testEnumDmnEnumExclPrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumExclPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumExclPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumExclPrnt".AnError();
  }

  internal static testEnumDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumExclPrntDecoder : IDecoder<testPrntDmnEnumExclPrnt?>
{
  public IMessages Decode(IValue input, out testPrntDmnEnumExclPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntDmnEnumExclPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntDmnEnumExclPrnt".AnError();
  }

  internal static testPrntDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumLabelDecoder : IDecoder<ItestDmnEnumLabel>
{
  public testEnumDmnEnumLabel? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumLabel? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumLabelDecoder : IDecoder<testEnumDmnEnumLabel?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumLabel? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumLabel value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumLabel".AnError();
  }

  internal static testEnumDmnEnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumPrntDecoder : IDecoder<ItestDmnEnumPrnt>
{
  public testEnumDmnEnumPrnt? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDecoder : IDecoder<ItestPrntDmnEnumPrnt>
{
  public testEnumDmnEnumPrnt? Value { get; set; }

  public IMessages Decode(IValue input, out ItestPrntDmnEnumPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDecoder : IDecoder<testEnumDmnEnumPrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumPrnt".AnError();
  }

  internal static testEnumDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumPrntDescrDecoder : IDecoder<ItestDmnEnumPrntDescr>
{
  public testEnumDmnEnumPrntDescr? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDescrDecoder : IDecoder<ItestPrntDmnEnumPrntDescr>
{
  public testEnumDmnEnumPrntDescr? Value { get; set; }

  public IMessages Decode(IValue input, out ItestPrntDmnEnumPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDescrDecoder : IDecoder<testEnumDmnEnumPrntDescr?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumPrntDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumPrntDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumPrntDescr".AnError();
  }

  internal static testEnumDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumUnqDecoder : IDecoder<ItestDmnEnumUnq>
{

  public IMessages Decode(IValue input, out ItestDmnEnumUnq? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqDecoder : IDecoder<testEnumDmnEnumUnq?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumUnq? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumUnq value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumUnq".AnError();
  }

  internal static testEnumDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqDecoder : IDecoder<testDupDmnEnumUnq?>
{
  public IMessages Decode(IValue input, out testDupDmnEnumUnq? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testDupDmnEnumUnq value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testDupDmnEnumUnq".AnError();
  }

  internal static testDupDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumUnqPrntDecoder : IDecoder<ItestDmnEnumUnqPrnt>
{

  public IMessages Decode(IValue input, out ItestDmnEnumUnqPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqPrntDecoder : IDecoder<testEnumDmnEnumUnqPrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumUnqPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumUnqPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumUnqPrnt".AnError();
  }

  internal static testEnumDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumUnqPrntDecoder : IDecoder<testPrntDmnEnumUnqPrnt?>
{
  public IMessages Decode(IValue input, out testPrntDmnEnumUnqPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntDmnEnumUnqPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntDmnEnumUnqPrnt".AnError();
  }

  internal static testPrntDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqPrntDecoder : IDecoder<testDupDmnEnumUnqPrnt?>
{
  public IMessages Decode(IValue input, out testDupDmnEnumUnqPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testDupDmnEnumUnqPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testDupDmnEnumUnqPrnt".AnError();
  }

  internal static testDupDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumValueDecoder : IDecoder<ItestDmnEnumValue>
{
  public testEnumDmnEnumValue? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumValue? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumValueDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumValueDecoder : IDecoder<testEnumDmnEnumValue?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumValue? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumValue value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumValue".AnError();
  }

  internal static testEnumDmnEnumValueDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumValuePrntDecoder : IDecoder<ItestDmnEnumValuePrnt>
{
  public testEnumDmnEnumValuePrnt? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumValuePrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumValuePrntDecoder : IDecoder<testEnumDmnEnumValuePrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumValuePrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumValuePrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumValuePrnt".AnError();
  }

  internal static testEnumDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumValuePrntDecoder : IDecoder<testPrntDmnEnumValuePrnt?>
{
  public IMessages Decode(IValue input, out testPrntDmnEnumValuePrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntDmnEnumValuePrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntDmnEnumValuePrnt".AnError();
  }

  internal static testPrntDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDescrDecoder : IDecoder<ItestDmnNmbrDescr>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrPrntDecoder : IDecoder<ItestDmnNmbrPrnt>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDecoder : IDecoder<ItestPrntDmnNmbrPrnt>
{

  public IMessages Decode(IValue input, out ItestPrntDmnNmbrPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnNmbrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrPrntDescrDecoder : IDecoder<ItestDmnNmbrPrntDescr>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDescrDecoder : IDecoder<ItestPrntDmnNmbrPrntDescr>
{

  public IMessages Decode(IValue input, out ItestPrntDmnNmbrPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnNmbrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrPstvDecoder : IDecoder<ItestDmnNmbrPstv>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrPstv? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrPstvDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrRangeDecoder : IDecoder<ItestDmnNmbrRange>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrRange? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrRangeDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDescrDecoder : IDecoder<ItestDmnStrDescr>
{

  public IMessages Decode(IValue input, out ItestDmnStrDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrNonEmptyDecoder : IDecoder<ItestDmnStrNonEmpty>
{

  public IMessages Decode(IValue input, out ItestDmnStrNonEmpty? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrNonEmptyDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrPrntDecoder : IDecoder<ItestDmnStrPrnt>
{

  public IMessages Decode(IValue input, out ItestDmnStrPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnStrPrntDecoder : IDecoder<ItestPrntDmnStrPrnt>
{

  public IMessages Decode(IValue input, out ItestPrntDmnStrPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnStrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrPrntDescrDecoder : IDecoder<ItestDmnStrPrntDescr>
{

  public IMessages Decode(IValue input, out ItestDmnStrPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnStrPrntDescrDecoder : IDecoder<ItestPrntDmnStrPrntDescr>
{

  public IMessages Decode(IValue input, out ItestPrntDmnStrPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnStrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDescrDecoder : IDecoder<testEnumDescr?>
{
  public IMessages Decode(IValue input, out testEnumDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDescr".AnError();
  }

  internal static testEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntDecoder : IDecoder<testEnumPrnt?>
{
  public IMessages Decode(IValue input, out testEnumPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumPrnt".AnError();
  }

  internal static testEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDecoder : IDecoder<testPrntEnumPrnt?>
{
  public IMessages Decode(IValue input, out testPrntEnumPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumPrnt".AnError();
  }

  internal static testPrntEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntAliasDecoder : IDecoder<testEnumPrntAlias?>
{
  public IMessages Decode(IValue input, out testEnumPrntAlias? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumPrntAlias value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumPrntAlias".AnError();
  }

  internal static testEnumPrntAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntAliasDecoder : IDecoder<testPrntEnumPrntAlias?>
{
  public IMessages Decode(IValue input, out testPrntEnumPrntAlias? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumPrntAlias value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumPrntAlias".AnError();
  }

  internal static testPrntEnumPrntAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntDescrDecoder : IDecoder<testEnumPrntDescr?>
{
  public IMessages Decode(IValue input, out testEnumPrntDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumPrntDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumPrntDescr".AnError();
  }

  internal static testEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDescrDecoder : IDecoder<testPrntEnumPrntDescr?>
{
  public IMessages Decode(IValue input, out testPrntEnumPrntDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumPrntDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumPrntDescr".AnError();
  }

  internal static testPrntEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntDupDecoder : IDecoder<testEnumPrntDup?>
{
  public IMessages Decode(IValue input, out testEnumPrntDup? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumPrntDup value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumPrntDup".AnError();
  }

  internal static testEnumPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDupDecoder : IDecoder<testPrntEnumPrntDup?>
{
  public IMessages Decode(IValue input, out testPrntEnumPrntDup? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumPrntDup value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumPrntDup".AnError();
  }

  internal static testPrntEnumPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionDescrDecoder : IDecoder<ItestUnionDescr>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestUnionDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionPrntDecoder : IDecoder<ItestUnionPrnt>
{
  public String? AsString { get; set; }

  public IMessages Decode(IValue input, out ItestUnionPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDecoder : IDecoder<ItestPrntUnionPrnt>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestPrntUnionPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntUnionPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionPrntDescrDecoder : IDecoder<ItestUnionPrntDescr>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestUnionPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDescrDecoder : IDecoder<ItestPrntUnionPrntDescr>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestPrntUnionPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntUnionPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionPrntDupDecoder : IDecoder<ItestUnionPrntDup>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestUnionPrntDup? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDupDecoder : IDecoder<ItestPrntUnionPrntDup>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestPrntUnionPrntDup? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntUnionPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__SimpleDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__SimpleDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnBoolDescr>(testDmnBoolDescrDecoder.Factory)
      .AddDecoder<ItestDmnBoolPrnt>(testDmnBoolPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnBoolPrnt>(testPrntDmnBoolPrntDecoder.Factory)
      .AddDecoder<ItestDmnBoolPrntDescr>(testDmnBoolPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnBoolPrntDescr>(testPrntDmnBoolPrntDescrDecoder.Factory)
      .AddDecoder<ItestDmnEnumAll>(testDmnEnumAllDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAll?>(testEnumDmnEnumAllDecoder.Factory)
      .AddDecoder<ItestDmnEnumAllDescr>(testDmnEnumAllDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAllDescr?>(testEnumDmnEnumAllDescrDecoder.Factory)
      .AddDecoder<ItestDmnEnumAllPrnt>(testDmnEnumAllPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAllPrnt?>(testEnumDmnEnumAllPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumAllPrnt?>(testPrntDmnEnumAllPrntDecoder.Factory)
      .AddDecoder<ItestDmnEnumDescr>(testDmnEnumDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumDescr?>(testEnumDmnEnumDescrDecoder.Factory)
      .AddDecoder<ItestDmnEnumExcl>(testDmnEnumExclDecoder.Factory)
      .AddDecoder<testEnumDmnEnumExcl?>(testEnumDmnEnumExclDecoder.Factory)
      .AddDecoder<ItestDmnEnumExclPrnt>(testDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumExclPrnt?>(testEnumDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumExclPrnt?>(testPrntDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<ItestDmnEnumLabel>(testDmnEnumLabelDecoder.Factory)
      .AddDecoder<testEnumDmnEnumLabel?>(testEnumDmnEnumLabelDecoder.Factory)
      .AddDecoder<ItestDmnEnumPrnt>(testDmnEnumPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnEnumPrnt>(testPrntDmnEnumPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumPrnt?>(testEnumDmnEnumPrntDecoder.Factory)
      .AddDecoder<ItestDmnEnumPrntDescr>(testDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnEnumPrntDescr>(testPrntDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumPrntDescr?>(testEnumDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<ItestDmnEnumUnq>(testDmnEnumUnqDecoder.Factory)
      .AddDecoder<testEnumDmnEnumUnq?>(testEnumDmnEnumUnqDecoder.Factory)
      .AddDecoder<testDupDmnEnumUnq?>(testDupDmnEnumUnqDecoder.Factory)
      .AddDecoder<ItestDmnEnumUnqPrnt>(testDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumUnqPrnt?>(testEnumDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumUnqPrnt?>(testPrntDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testDupDmnEnumUnqPrnt?>(testDupDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<ItestDmnEnumValue>(testDmnEnumValueDecoder.Factory)
      .AddDecoder<testEnumDmnEnumValue?>(testEnumDmnEnumValueDecoder.Factory)
      .AddDecoder<ItestDmnEnumValuePrnt>(testDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumValuePrnt?>(testEnumDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumValuePrnt?>(testPrntDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<ItestDmnNmbrDescr>(testDmnNmbrDescrDecoder.Factory)
      .AddDecoder<ItestDmnNmbrPrnt>(testDmnNmbrPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnNmbrPrnt>(testPrntDmnNmbrPrntDecoder.Factory)
      .AddDecoder<ItestDmnNmbrPrntDescr>(testDmnNmbrPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnNmbrPrntDescr>(testPrntDmnNmbrPrntDescrDecoder.Factory)
      .AddDecoder<ItestDmnNmbrPstv>(testDmnNmbrPstvDecoder.Factory)
      .AddDecoder<ItestDmnNmbrRange>(testDmnNmbrRangeDecoder.Factory)
      .AddDecoder<ItestDmnStrDescr>(testDmnStrDescrDecoder.Factory)
      .AddDecoder<ItestDmnStrNonEmpty>(testDmnStrNonEmptyDecoder.Factory)
      .AddDecoder<ItestDmnStrPrnt>(testDmnStrPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnStrPrnt>(testPrntDmnStrPrntDecoder.Factory)
      .AddDecoder<ItestDmnStrPrntDescr>(testDmnStrPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnStrPrntDescr>(testPrntDmnStrPrntDescrDecoder.Factory)
      .AddDecoder<testEnumDescr?>(testEnumDescrDecoder.Factory)
      .AddDecoder<testEnumPrnt?>(testEnumPrntDecoder.Factory)
      .AddDecoder<testPrntEnumPrnt?>(testPrntEnumPrntDecoder.Factory)
      .AddDecoder<testEnumPrntAlias?>(testEnumPrntAliasDecoder.Factory)
      .AddDecoder<testPrntEnumPrntAlias?>(testPrntEnumPrntAliasDecoder.Factory)
      .AddDecoder<testEnumPrntDescr?>(testEnumPrntDescrDecoder.Factory)
      .AddDecoder<testPrntEnumPrntDescr?>(testPrntEnumPrntDescrDecoder.Factory)
      .AddDecoder<testEnumPrntDup?>(testEnumPrntDupDecoder.Factory)
      .AddDecoder<testPrntEnumPrntDup?>(testPrntEnumPrntDupDecoder.Factory)
      .AddDecoder<ItestUnionDescr>(testUnionDescrDecoder.Factory)
      .AddDecoder<ItestUnionPrnt>(testUnionPrntDecoder.Factory)
      .AddDecoder<ItestPrntUnionPrnt>(testPrntUnionPrntDecoder.Factory)
      .AddDecoder<ItestUnionPrntDescr>(testUnionPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntUnionPrntDescr>(testPrntUnionPrntDescrDecoder.Factory)
      .AddDecoder<ItestUnionPrntDup>(testUnionPrntDupDecoder.Factory)
      .AddDecoder<ItestPrntUnionPrntDup>(testPrntUnionPrntDupDecoder.Factory);
}
