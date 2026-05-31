//HintName: test_-Global_Dec.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

internal class test_ResolutionDecoder : IDecoder<test_Resolution?>
{
  public IMessages Decode(IValue input, out test_Resolution? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_Resolution value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_Resolution".AnError();
  }

  internal static test_ResolutionDecoder Factory(IDecoderRepository _) => new();
}

internal class test_LocationDecoder : IDecoder<test_Location?>
{
  public IMessages Decode(IValue input, out test_Location? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_Location value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_Location".AnError();
  }

  internal static test_LocationDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpDirectiveDecoder : IDecoder<Itest_OpDirectiveObject>
{
  public Itest_OpArgument? Argument { get; set; }

  public IMessages Decode(IValue input, out Itest_OpDirectiveObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_OpDirectiveDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgumentDecoder : IDecoder<Itest_OpArgumentObject>
{

  public IMessages Decode(IValue input, out Itest_OpArgumentObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_OpArgumentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgValueDecoder : IDecoder<Itest_OpArgValueObject>
{
  public Itest_Name? Variable { get; set; }

  public IMessages Decode(IValue input, out Itest_OpArgValueObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_OpArgValueDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgListDecoder : IDecoder<Itest_OpArgListObject>
{

  public IMessages Decode(IValue input, out Itest_OpArgListObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_OpArgListDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgMapDecoder : IDecoder<Itest_OpArgMapObject>
{
  public Itest_OpArgValue? Value { get; set; }
  public Itest_Name? ByVariable { get; set; }

  public IMessages Decode(IValue input, out Itest_OpArgMapObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_OpArgMapDecoder Factory(IDecoderRepository _) => new();
}

internal class test_PathDecoder : IDecoder<Itest_Path>
{

  public IMessages Decode(IValue input, out Itest_Path? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_PathDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__GlobalDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__GlobalDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_Resolution?>(test_ResolutionDecoder.Factory)
      .AddDecoder<test_Location?>(test_LocationDecoder.Factory)
      .AddDecoder<Itest_OpDirectiveObject>(test_OpDirectiveDecoder.Factory)
      .AddDecoder<Itest_OpArgumentObject>(test_OpArgumentDecoder.Factory)
      .AddDecoder<Itest_OpArgValueObject>(test_OpArgValueDecoder.Factory)
      .AddDecoder<Itest_OpArgListObject>(test_OpArgListDecoder.Factory)
      .AddDecoder<Itest_OpArgMapObject>(test_OpArgMapDecoder.Factory)
      .AddDecoder<Itest_Path>(test_PathDecoder.Factory);
}
