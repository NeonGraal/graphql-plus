//HintName: test_-Schema_Dec.gen.cs
// Generated from {CurrentDirectory}-Schema.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Schema;

internal class test_NameDecoder : IDecoder<Itest_Name>
{

  public IMessages Decode(IValue input, out Itest_Name? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_NameDecoder Factory(IDecoderRepository _) => new();
}

internal class test_FilterDecoder : IDecoder<Itest_FilterObject>
{
  public ICollection<Itest_NameFilter>? Names { get; set; }
  public bool? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter>? Aliases { get; set; }
  public bool? ReturnByAlias { get; set; }
  public bool? ReturnReferencedTypes { get; set; }

  public IMessages Decode(IValue input, out Itest_FilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_FilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_NameFilterDecoder : IDecoder<Itest_NameFilter>
{

  public IMessages Decode(IValue input, out Itest_NameFilter? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_NameFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_CategoryFilterDecoder : IDecoder<Itest_CategoryFilterObject>
{
  public ICollection<Itest_Resolution>? Resolutions { get; set; }

  public IMessages Decode(IValue input, out Itest_CategoryFilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_CategoryFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeFilterDecoder : IDecoder<Itest_TypeFilterObject>
{
  public ICollection<Itest_TypeKind>? Kinds { get; set; }

  public IMessages Decode(IValue input, out Itest_TypeFilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_TypeFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_AliasedDecoder : IDecoder<Itest_AliasedObject>
{
  public ICollection<Itest_Name>? Aliases { get; set; }

  public IMessages Decode(IValue input, out Itest_AliasedObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_AliasedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_NamedDecoder : IDecoder<Itest_NamedObject>
{
  public Itest_Name? Name { get; set; }

  public IMessages Decode(IValue input, out Itest_NamedObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_NamedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DescribedDecoder : IDecoder<Itest_DescribedObject>
{
  public ICollection<string>? Description { get; set; }

  public IMessages Decode(IValue input, out Itest_DescribedObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_DescribedDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__SchemaDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__SchemaDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_Name>(test_NameDecoder.Factory)
      .AddDecoder<Itest_FilterObject>(test_FilterDecoder.Factory)
      .AddDecoder<Itest_NameFilter>(test_NameFilterDecoder.Factory)
      .AddDecoder<Itest_CategoryFilterObject>(test_CategoryFilterDecoder.Factory)
      .AddDecoder<Itest_TypeFilterObject>(test_TypeFilterDecoder.Factory)
      .AddDecoder<Itest_AliasedObject>(test_AliasedDecoder.Factory)
      .AddDecoder<Itest_NamedObject>(test_NamedDecoder.Factory)
      .AddDecoder<Itest_DescribedObject>(test_DescribedDecoder.Factory);
}
