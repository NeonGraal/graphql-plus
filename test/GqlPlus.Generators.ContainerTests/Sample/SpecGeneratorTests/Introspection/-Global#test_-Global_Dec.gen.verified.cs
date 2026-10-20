//HintName: test_-Global_Dec.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

internal class test_ResolutionDecoder : NullDecoder<test_Resolution>
{
  public string Parallel { get; set; } = default!;
  public string Sequential { get; set; } = default!;
  public string Single { get; set; } = default!;

  internal static test_ResolutionDecoder Factory(IDecoderRepository _) => new();
}

internal class test_LocationDecoder : NullDecoder<test_Location>
{
  public string Operation { get; set; } = default!;
  public string Variable { get; set; } = default!;
  public string Field { get; set; } = default!;
  public string Inline { get; set; } = default!;
  public string Spread { get; set; } = default!;
  public string Fragment { get; set; } = default!;

  internal static test_LocationDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpDirectiveDecoder : NullDecoder<Itest_OpDirectiveObject>
{
  public Itest_OpArgument? Argument { get; set; } = default!;

  internal static test_OpDirectiveDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgumentDecoder : NullDecoder<Itest_OpArgumentObject>
{

  internal static test_OpArgumentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgValueDecoder : NullDecoder<Itest_OpArgValueObject>
{
  public Itest_Name Variable { get; set; } = default!;

  internal static test_OpArgValueDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgListDecoder : NullDecoder<Itest_OpArgListObject>
{

  internal static test_OpArgListDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgMapDecoder : NullDecoder<Itest_OpArgMapObject>
{
  public Itest_OpArgValue Value { get; set; } = default!;
  public Itest_Name ByVariable { get; set; } = default!;

  internal static test_OpArgMapDecoder Factory(IDecoderRepository _) => new();
}

internal class test_PathDecoder : NullDecoder<Itest_Path>
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
