//HintName: test_Operation_Dec.gen.cs
// Generated from {CurrentDirectory}Operation.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Operation;

internal class test_OpDirectiveDecoder
{
  public Itest_OpArgument? Argument { get; set; }
}

internal class test_OpArgumentDecoder
{
}

internal class test_OpArgValueDecoder
{
  public Itest_Name Variable { get; set; }
}

internal class test_OpArgListDecoder
{
}

internal class test_OpArgMapDecoder
{
  public Itest_OpArgValue Value { get; set; }
  public Itest_Name ByVariable { get; set; }
}

internal class test_PathDecoder
{
}

internal static class test_OperationDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_OperationDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_OpDirectiveObject>(_ => new test_OpDirectiveDecoder())
      .AddDecoder<Itest_OpArgumentObject>(_ => new test_OpArgumentDecoder())
      .AddDecoder<Itest_OpArgValueObject>(_ => new test_OpArgValueDecoder())
      .AddDecoder<Itest_OpArgListObject>(_ => new test_OpArgListDecoder())
      .AddDecoder<Itest_OpArgMapObject>(_ => new test_OpArgMapDecoder())
      .AddDecoder<Itest_Path>(_ => new test_PathDecoder());
}
