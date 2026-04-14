//HintName: test_Declarations_Dec.gen.cs
// Generated from {CurrentDirectory}Declarations.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Declarations;

internal class test_SchemaDecoder
{
  public IDictionary<Itest_Name, Itest_Categories>? Categories(Itest_CategoryFilter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Categories>? Categories()
    => null;
  public IDictionary<Itest_Name, Itest_Directives>? Directives(Itest_Filter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Directives>? Directives()
    => null;
  public IDictionary<Itest_Name, Itest_Type>? Types(Itest_TypeFilter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Type>? Types()
    => null;
  public IDictionary<Itest_Name, Itest_Setting>? Settings(Itest_Filter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Setting>? Settings()
    => null;
}

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
      .AddDecoder<Itest_SchemaObject>(r => new test_SchemaDecoder(r))
      .AddDecoder<Itest_Name>(_ => new test_NameDecoder())
      .AddDecoder<Itest_FilterObject>(r => new test_FilterDecoder(r))
      .AddDecoder<Itest_NameFilter>(_ => new test_NameFilterDecoder())
      .AddDecoder<Itest_CategoryFilterObject>(r => new test_CategoryFilterDecoder(r))
      .AddDecoder<Itest_TypeFilterObject>(r => new test_TypeFilterDecoder(r));
}
