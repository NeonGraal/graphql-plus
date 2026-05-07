//HintName: test_-Global_Dec.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

internal class test_ResolutionDecoder
{
  public string Parallel { get; set; }
  public string Sequential { get; set; }
  public string Single { get; set; }

  internal static test_ResolutionDecoder Factory(IDecoderRepository _) => new();
}

internal class test_LocationDecoder
{
  public string Operation { get; set; }
  public string Variable { get; set; }
  public string Field { get; set; }
  public string Inline { get; set; }
  public string Spread { get; set; }
  public string Fragment { get; set; }

  internal static test_LocationDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpDirectiveDecoder
{
  public Itest_OpArgument? Argument { get; set; }

  internal static test_OpDirectiveDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgumentDecoder
{

  internal static test_OpArgumentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgValueDecoder
{
  public Itest_Name Variable { get; set; }

  internal static test_OpArgValueDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgListDecoder
{

  internal static test_OpArgListDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgMapDecoder
{
  public Itest_OpArgValue Value { get; set; }
  public Itest_Name ByVariable { get; set; }

  internal static test_OpArgMapDecoder Factory(IDecoderRepository _) => new();
}

internal class test_PathDecoder
{

  internal static test_PathDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__GlobalDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__GlobalDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_Resolution>(test_ResolutionDecoder.Factory)
      .AddDecoder<test_Location>(test_LocationDecoder.Factory)
      .AddDecoder<Itest_OpDirectiveObject>(test_OpDirectiveDecoder.Factory)
      .AddDecoder<Itest_OpArgumentObject>(test_OpArgumentDecoder.Factory)
      .AddDecoder<Itest_OpArgValueObject>(test_OpArgValueDecoder.Factory)
      .AddDecoder<Itest_OpArgListObject>(test_OpArgListDecoder.Factory)
      .AddDecoder<Itest_OpArgMapObject>(test_OpArgMapDecoder.Factory)
      .AddDecoder<Itest_Path>(test_PathDecoder.Factory);
}
