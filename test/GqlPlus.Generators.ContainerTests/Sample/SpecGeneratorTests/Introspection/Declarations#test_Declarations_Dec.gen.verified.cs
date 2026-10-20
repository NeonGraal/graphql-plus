//HintName: test_Declarations_Dec.gen.cs
// Generated from {CurrentDirectory}Declarations.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Declarations;

internal class test_NameDecoder : NullDecoder<Itest_Name>
{

  internal static test_NameDecoder Factory(IDecoderRepository _) => new();
}

internal class test_FilterDecoder : NullDecoder<Itest_FilterObject>
{
  public ICollection<Itest_NameFilter> Names { get; set; } = default!;
  public bool? MatchAliases { get; set; } = default!;
  public ICollection<Itest_NameFilter> Aliases { get; set; } = default!;
  public bool? ReturnByAlias { get; set; } = default!;
  public bool? ReturnReferencedTypes { get; set; } = default!;

  internal static test_FilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_NameFilterDecoder : NullDecoder<Itest_NameFilter>
{

  internal static test_NameFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_CategoryFilterDecoder : NullDecoder<Itest_CategoryFilterObject>
{
  public ICollection<Itest_Resolution> Resolutions { get; set; } = default!;

  internal static test_CategoryFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeFilterDecoder : NullDecoder<Itest_TypeFilterObject>
{
  public ICollection<Itest_TypeKind> Kinds { get; set; } = default!;

  internal static test_TypeFilterDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_DeclarationsDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_DeclarationsDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_Name>(test_NameDecoder.Factory)
      .AddDecoder<Itest_FilterObject>(test_FilterDecoder.Factory)
      .AddDecoder<Itest_NameFilter>(test_NameFilterDecoder.Factory)
      .AddDecoder<Itest_CategoryFilterObject>(test_CategoryFilterDecoder.Factory)
      .AddDecoder<Itest_TypeFilterObject>(test_TypeFilterDecoder.Factory);
}
