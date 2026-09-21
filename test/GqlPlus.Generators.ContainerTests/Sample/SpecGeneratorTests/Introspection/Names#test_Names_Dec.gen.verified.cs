//HintName: test_Names_Dec.gen.cs
// Generated from {CurrentDirectory}Names.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Names;

internal class test_AliasedDecoder : NullDecoder<Itest_AliasedObject>
{
  public ICollection<Itest_Name> Aliases { get; set; } = default!;

  internal static test_AliasedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_NamedDecoder : NullDecoder<Itest_NamedObject>
{
  public Itest_Name Name { get; set; } = default!;

  internal static test_NamedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DescribedDecoder : NullDecoder<Itest_DescribedObject>
{
  public ICollection<string> Description { get; set; } = default!;

  internal static test_DescribedDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_NamesDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_NamesDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_AliasedObject>(test_AliasedDecoder.Factory)
      .AddDecoder<Itest_NamedObject>(test_NamedDecoder.Factory)
      .AddDecoder<Itest_DescribedObject>(test_DescribedDecoder.Factory);
}
