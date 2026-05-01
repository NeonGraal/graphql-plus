//HintName: test_+Merges_Dec.gen.cs
// Generated from {CurrentDirectory}+Merges.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

internal class testInDrctParamDecoder : IDecoder<ItestInDrctParamObject>
{

  public IMessages Decode(IValue input, out ItestInDrctParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInDrctParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnAliasDecoder : IDecoder<ItestDmnAlias>
{

  public IMessages Decode(IValue input, out ItestDmnAlias? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolDecoder : IDecoder<ItestDmnBool>
{

  public IMessages Decode(IValue input, out ItestDmnBool? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolDiffDecoder : IDecoder<ItestDmnBoolDiff>
{

  public IMessages Decode(IValue input, out ItestDmnBoolDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolSameDecoder : IDecoder<ItestDmnBoolSame>
{

  public IMessages Decode(IValue input, out ItestDmnBoolSame? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumDiffDecoder : IDecoder<ItestDmnEnumDiff>
{
  public bool? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumSameDecoder : IDecoder<ItestDmnEnumSame>
{
  public bool? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumSame? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDecoder : IDecoder<ItestDmnNmbr>
{

  public IMessages Decode(IValue input, out ItestDmnNmbr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDiffDecoder : IDecoder<ItestDmnNmbrDiff>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrSameDecoder : IDecoder<ItestDmnNmbrSame>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrSame? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDecoder : IDecoder<ItestDmnStr>
{

  public IMessages Decode(IValue input, out ItestDmnStr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDiffDecoder : IDecoder<ItestDmnStrDiff>
{

  public IMessages Decode(IValue input, out ItestDmnStrDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrSameDecoder : IDecoder<ItestDmnStrSame>
{

  public IMessages Decode(IValue input, out ItestDmnStrSame? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAliasDecoder : IDecoder<testEnumAlias?>
{
  public IMessages Decode(IValue input, out testEnumAlias? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumAlias value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumAlias".AnError();
  }

  internal static testEnumAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDiffDecoder : IDecoder<testEnumDiff?>
{
  public IMessages Decode(IValue input, out testEnumDiff? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDiff value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDiff".AnError();
  }

  internal static testEnumDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumSameDecoder : IDecoder<testEnumSame?>
{
  public IMessages Decode(IValue input, out testEnumSame? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumSame value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumSame".AnError();
  }

  internal static testEnumSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumSamePrntDecoder : IDecoder<testEnumSamePrnt?>
{
  public IMessages Decode(IValue input, out testEnumSamePrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumSamePrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumSamePrnt".AnError();
  }

  internal static testEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumSamePrntDecoder : IDecoder<testPrntEnumSamePrnt?>
{
  public IMessages Decode(IValue input, out testPrntEnumSamePrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumSamePrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumSamePrnt".AnError();
  }

  internal static testPrntEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumValueAliasDecoder : IDecoder<testEnumValueAlias?>
{
  public IMessages Decode(IValue input, out testEnumValueAlias? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumValueAlias value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumValueAlias".AnError();
  }

  internal static testEnumValueAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualDecoder : IDecoder<ItestObjDualObject>
{

  public IMessages Decode(IValue input, out ItestObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjInpDecoder : IDecoder<ItestObjInpObject>
{

  public IMessages Decode(IValue input, out ItestObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAliasDualDecoder : IDecoder<ItestObjAliasDualObject>
{

  public IMessages Decode(IValue input, out ItestObjAliasDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAliasInpDecoder : IDecoder<ItestObjAliasInpObject>
{

  public IMessages Decode(IValue input, out ItestObjAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltDualDecoder : IDecoder<ItestObjAltDualObject>
{

  public IMessages Decode(IValue input, out ItestObjAltDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltDualTypeDecoder : IDecoder<ItestObjAltDualTypeObject>
{

  public IMessages Decode(IValue input, out ItestObjAltDualTypeObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltDualTypeDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltInpDecoder : IDecoder<ItestObjAltInpObject>
{

  public IMessages Decode(IValue input, out ItestObjAltInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltInpTypeDecoder : IDecoder<ItestObjAltInpTypeObject>
{

  public IMessages Decode(IValue input, out ItestObjAltInpTypeObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltInpTypeDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltEnumDualDecoder : IDecoder<ItestObjAltEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestObjAltEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltEnumInpDecoder : IDecoder<ItestObjAltEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestObjAltEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjCnstDualDecoder<TType>
{
  public TType? Field { get; set; }
  public TType? Str { get; set; }
}

internal class testObjCnstInpDecoder<TType>
{
  public TType? Field { get; set; }
  public TType? Str { get; set; }
}

internal class testObjFieldDualDecoder : IDecoder<ItestObjFieldDualObject>
{
  public ItestFldObjFieldDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldDualDecoder : IDecoder<ItestFldObjFieldDualObject>
{

  public IMessages Decode(IValue input, out ItestFldObjFieldDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldObjFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldInpDecoder : IDecoder<ItestObjFieldInpObject>
{
  public ItestFldObjFieldInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldInpDecoder : IDecoder<ItestFldObjFieldInpObject>
{

  public IMessages Decode(IValue input, out ItestFldObjFieldInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldObjFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldAliasDualDecoder : IDecoder<ItestObjFieldAliasDualObject>
{
  public ItestFldObjFieldAliasDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldAliasDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldAliasDualDecoder : IDecoder<ItestFldObjFieldAliasDualObject>
{

  public IMessages Decode(IValue input, out ItestFldObjFieldAliasDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldObjFieldAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldAliasInpDecoder : IDecoder<ItestObjFieldAliasInpObject>
{
  public ItestFldObjFieldAliasInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldAliasInpDecoder : IDecoder<ItestFldObjFieldAliasInpObject>
{

  public IMessages Decode(IValue input, out ItestFldObjFieldAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldObjFieldAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumAliasDualDecoder : IDecoder<ItestObjFieldEnumAliasDualObject>
{
  public bool? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldEnumAliasDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldEnumAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumAliasInpDecoder : IDecoder<ItestObjFieldEnumAliasInpObject>
{
  public bool? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldEnumAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldEnumAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumValueDualDecoder : IDecoder<ItestObjFieldEnumValueDualObject>
{
  public bool? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldEnumValueDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldEnumValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumValueInpDecoder : IDecoder<ItestObjFieldEnumValueInpObject>
{
  public bool? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldEnumValueInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldEnumValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldTypeAliasDualDecoder : IDecoder<ItestObjFieldTypeAliasDualObject>
{
  public string? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldTypeAliasDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldTypeAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldTypeAliasInpDecoder : IDecoder<ItestObjFieldTypeAliasInpObject>
{
  public string? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldTypeAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldTypeAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjParamDualDecoder<TTest,TType>
{
  public TTest? Test { get; set; }
  public TType? Type { get; set; }
}

internal class testObjParamInpDecoder<TTest,TType>
{
  public TTest? Test { get; set; }
  public TType? Type { get; set; }
}

internal class testObjParamDupDualDecoder<TTest>
{
  public TTest? Test { get; set; }
  public TTest? Type { get; set; }
}

internal class testObjParamDupInpDecoder<TTest>
{
  public TTest? Test { get; set; }
  public TTest? Type { get; set; }
}

internal class testObjPrntDualDecoder : IDecoder<ItestObjPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestObjPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefObjPrntDualDecoder : IDecoder<ItestRefObjPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestRefObjPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjPrntInpDecoder : IDecoder<ItestObjPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestObjPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefObjPrntInpDecoder : IDecoder<ItestRefObjPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestRefObjPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testOutpFieldParam1Decoder : IDecoder<ItestOutpFieldParam1Object>
{

  public IMessages Decode(IValue input, out ItestOutpFieldParam1Object? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testOutpFieldParam1Decoder Factory(IDecoderRepository _) => new();
}

internal class testOutpFieldParam2Decoder : IDecoder<ItestOutpFieldParam2Object>
{

  public IMessages Decode(IValue input, out ItestOutpFieldParam2Object? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testOutpFieldParam2Decoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpFieldParamDecoder : IDecoder<ItestFldOutpFieldParamObject>
{

  public IMessages Decode(IValue input, out ItestFldOutpFieldParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldOutpFieldParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionAliasDecoder : IDecoder<ItestUnionAlias>
{
  public Boolean? AsBoolean { get; set; }
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestUnionAlias? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionDiffDecoder : IDecoder<ItestUnionDiff>
{
  public Boolean? AsBoolean { get; set; }
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestUnionDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionSameDecoder : IDecoder<ItestUnionSame>
{
  public Boolean? AsBoolean { get; set; }

  public IMessages Decode(IValue input, out ItestUnionSame? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionSamePrntDecoder : IDecoder<ItestUnionSamePrnt>
{
  public Boolean? AsBoolean { get; set; }

  public IMessages Decode(IValue input, out ItestUnionSamePrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionSamePrntDecoder : IDecoder<ItestPrntUnionSamePrnt>
{
  public String? AsString { get; set; }

  public IMessages Decode(IValue input, out ItestPrntUnionSamePrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__MergesDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__MergesDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInDrctParamObject>(testInDrctParamDecoder.Factory)
      .AddDecoder<ItestDmnAlias>(testDmnAliasDecoder.Factory)
      .AddDecoder<ItestDmnBool>(testDmnBoolDecoder.Factory)
      .AddDecoder<ItestDmnBoolDiff>(testDmnBoolDiffDecoder.Factory)
      .AddDecoder<ItestDmnBoolSame>(testDmnBoolSameDecoder.Factory)
      .AddDecoder<ItestDmnEnumDiff>(testDmnEnumDiffDecoder.Factory)
      .AddDecoder<ItestDmnEnumSame>(testDmnEnumSameDecoder.Factory)
      .AddDecoder<ItestDmnNmbr>(testDmnNmbrDecoder.Factory)
      .AddDecoder<ItestDmnNmbrDiff>(testDmnNmbrDiffDecoder.Factory)
      .AddDecoder<ItestDmnNmbrSame>(testDmnNmbrSameDecoder.Factory)
      .AddDecoder<ItestDmnStr>(testDmnStrDecoder.Factory)
      .AddDecoder<ItestDmnStrDiff>(testDmnStrDiffDecoder.Factory)
      .AddDecoder<ItestDmnStrSame>(testDmnStrSameDecoder.Factory)
      .AddDecoder<testEnumAlias?>(testEnumAliasDecoder.Factory)
      .AddDecoder<testEnumDiff?>(testEnumDiffDecoder.Factory)
      .AddDecoder<testEnumSame?>(testEnumSameDecoder.Factory)
      .AddDecoder<testEnumSamePrnt?>(testEnumSamePrntDecoder.Factory)
      .AddDecoder<testPrntEnumSamePrnt?>(testPrntEnumSamePrntDecoder.Factory)
      .AddDecoder<testEnumValueAlias?>(testEnumValueAliasDecoder.Factory)
      .AddDecoder<ItestObjDualObject>(testObjDualDecoder.Factory)
      .AddDecoder<ItestObjInpObject>(testObjInpDecoder.Factory)
      .AddDecoder<ItestObjAliasDualObject>(testObjAliasDualDecoder.Factory)
      .AddDecoder<ItestObjAliasInpObject>(testObjAliasInpDecoder.Factory)
      .AddDecoder<ItestObjAltDualObject>(testObjAltDualDecoder.Factory)
      .AddDecoder<ItestObjAltDualTypeObject>(testObjAltDualTypeDecoder.Factory)
      .AddDecoder<ItestObjAltInpObject>(testObjAltInpDecoder.Factory)
      .AddDecoder<ItestObjAltInpTypeObject>(testObjAltInpTypeDecoder.Factory)
      .AddDecoder<ItestObjAltEnumDualObject>(testObjAltEnumDualDecoder.Factory)
      .AddDecoder<ItestObjAltEnumInpObject>(testObjAltEnumInpDecoder.Factory)
      .AddDecoder<ItestObjFieldDualObject>(testObjFieldDualDecoder.Factory)
      .AddDecoder<ItestFldObjFieldDualObject>(testFldObjFieldDualDecoder.Factory)
      .AddDecoder<ItestObjFieldInpObject>(testObjFieldInpDecoder.Factory)
      .AddDecoder<ItestFldObjFieldInpObject>(testFldObjFieldInpDecoder.Factory)
      .AddDecoder<ItestObjFieldAliasDualObject>(testObjFieldAliasDualDecoder.Factory)
      .AddDecoder<ItestFldObjFieldAliasDualObject>(testFldObjFieldAliasDualDecoder.Factory)
      .AddDecoder<ItestObjFieldAliasInpObject>(testObjFieldAliasInpDecoder.Factory)
      .AddDecoder<ItestFldObjFieldAliasInpObject>(testFldObjFieldAliasInpDecoder.Factory)
      .AddDecoder<ItestObjFieldEnumAliasDualObject>(testObjFieldEnumAliasDualDecoder.Factory)
      .AddDecoder<ItestObjFieldEnumAliasInpObject>(testObjFieldEnumAliasInpDecoder.Factory)
      .AddDecoder<ItestObjFieldEnumValueDualObject>(testObjFieldEnumValueDualDecoder.Factory)
      .AddDecoder<ItestObjFieldEnumValueInpObject>(testObjFieldEnumValueInpDecoder.Factory)
      .AddDecoder<ItestObjFieldTypeAliasDualObject>(testObjFieldTypeAliasDualDecoder.Factory)
      .AddDecoder<ItestObjFieldTypeAliasInpObject>(testObjFieldTypeAliasInpDecoder.Factory)
      .AddDecoder<ItestObjPrntDualObject>(testObjPrntDualDecoder.Factory)
      .AddDecoder<ItestRefObjPrntDualObject>(testRefObjPrntDualDecoder.Factory)
      .AddDecoder<ItestObjPrntInpObject>(testObjPrntInpDecoder.Factory)
      .AddDecoder<ItestRefObjPrntInpObject>(testRefObjPrntInpDecoder.Factory)
      .AddDecoder<ItestOutpFieldParam1Object>(testOutpFieldParam1Decoder.Factory)
      .AddDecoder<ItestOutpFieldParam2Object>(testOutpFieldParam2Decoder.Factory)
      .AddDecoder<ItestFldOutpFieldParamObject>(testFldOutpFieldParamDecoder.Factory)
      .AddDecoder<ItestUnionAlias>(testUnionAliasDecoder.Factory)
      .AddDecoder<ItestUnionDiff>(testUnionDiffDecoder.Factory)
      .AddDecoder<ItestUnionSame>(testUnionSameDecoder.Factory)
      .AddDecoder<ItestUnionSamePrnt>(testUnionSamePrntDecoder.Factory)
      .AddDecoder<ItestPrntUnionSamePrnt>(testPrntUnionSamePrntDecoder.Factory);
}
