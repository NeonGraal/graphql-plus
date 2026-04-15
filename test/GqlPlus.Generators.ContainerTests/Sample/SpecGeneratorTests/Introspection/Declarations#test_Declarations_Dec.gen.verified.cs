//HintName: test_Declarations_Dec.gen.cs
// Generated from {CurrentDirectory}Declarations.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Declarations;

internal class test_NameDecoder
{
}

internal class test_FilterDecoder
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public bool? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public bool? ReturnByAlias { get; set; }
  public bool? ReturnReferencedTypes { get; set; }
}

internal class test_NameFilterDecoder
{
}

internal class test_CategoryFilterDecoder
{
  public ICollection<Itest_Resolution> Resolutions { get; set; }
}

internal class test_TypeFilterDecoder
{
  public ICollection<Itest_TypeKind> Kinds { get; set; }
}

internal static class test_DeclarationsDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_DeclarationsDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_Name>(_ => new test_NameDecoder())
      .AddDecoder<Itest_FilterObject>(_ => new test_FilterDecoder())
      .AddDecoder<Itest_NameFilter>(_ => new test_NameFilterDecoder())
      .AddDecoder<Itest_CategoryFilterObject>(_ => new test_CategoryFilterDecoder())
      .AddDecoder<Itest_TypeFilterObject>(_ => new test_TypeFilterDecoder());
}
