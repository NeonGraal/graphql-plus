//HintName: test_Directive_Dec.gen.cs
// Generated from {CurrentDirectory}Directive.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Directive;

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

internal static class test_DirectiveDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_DirectiveDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_Location>(test_LocationDecoder.Factory);
}
