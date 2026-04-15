//HintName: test_-Global_Dec.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

internal class test_ResolutionDecoder
{
  public string Parallel { get; set; }
  public string Sequential { get; set; }
  public string Single { get; set; }
}

internal class test_LocationDecoder
{
  public string Operation { get; set; }
  public string Variable { get; set; }
  public string Field { get; set; }
  public string Inline { get; set; }
  public string Spread { get; set; }
  public string Fragment { get; set; }
}

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

internal static class test__GlobalDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__GlobalDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_Resolution>(_ => new test_ResolutionDecoder())
      .AddDecoder<test_Location>(_ => new test_LocationDecoder())
      .AddDecoder<Itest_OpDirectiveObject>(_ => new test_OpDirectiveDecoder())
      .AddDecoder<Itest_OpArgumentObject>(_ => new test_OpArgumentDecoder())
      .AddDecoder<Itest_OpArgValueObject>(_ => new test_OpArgValueDecoder())
      .AddDecoder<Itest_OpArgListObject>(_ => new test_OpArgListDecoder())
      .AddDecoder<Itest_OpArgMapObject>(_ => new test_OpArgMapDecoder())
      .AddDecoder<Itest_Path>(_ => new test_PathDecoder());
}
