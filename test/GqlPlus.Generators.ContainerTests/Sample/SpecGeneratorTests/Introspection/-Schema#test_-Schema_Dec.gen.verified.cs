//HintName: test_-Schema_Dec.gen.cs
// Generated from {CurrentDirectory}-Schema.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Schema;

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

internal class test_AliasedDecoder
{
  public ICollection<Itest_Name> Aliases { get; set; }
}

internal class test_NamedDecoder
{
  public Itest_Name Name { get; set; }
}

internal class test_DescribedDecoder
{
  public ICollection<string> Description { get; set; }
}

internal static class test__SchemaDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__SchemaDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_Name>(_ => new test_NameDecoder())
      .AddDecoder<Itest_FilterObject>(_ => new test_FilterDecoder())
      .AddDecoder<Itest_NameFilter>(_ => new test_NameFilterDecoder())
      .AddDecoder<Itest_CategoryFilterObject>(_ => new test_CategoryFilterDecoder())
      .AddDecoder<Itest_TypeFilterObject>(_ => new test_TypeFilterDecoder())
      .AddDecoder<Itest_AliasedObject>(_ => new test_AliasedDecoder())
      .AddDecoder<Itest_NamedObject>(_ => new test_NamedDecoder())
      .AddDecoder<Itest_DescribedObject>(_ => new test_DescribedDecoder());
}
