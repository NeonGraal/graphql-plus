//HintName: test_Operation_Dec.gen.cs
// Generated from {CurrentDirectory}Operation.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Operation;

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

internal static class test_OperationDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_OperationDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_OpDirectiveObject>(test_OpDirectiveDecoder.Factory)
      .AddDecoder<Itest_OpArgumentObject>(test_OpArgumentDecoder.Factory)
      .AddDecoder<Itest_OpArgValueObject>(test_OpArgValueDecoder.Factory)
      .AddDecoder<Itest_OpArgListObject>(test_OpArgListDecoder.Factory)
      .AddDecoder<Itest_OpArgMapObject>(test_OpArgMapDecoder.Factory)
      .AddDecoder<Itest_Path>(test_PathDecoder.Factory);
}
