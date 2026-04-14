//HintName: test_Names_Dec.gen.cs
// Generated from {CurrentDirectory}Names.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Names;

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

internal static class test_NamesDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_NamesDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_AliasedObject>(_ => new test_AliasedDecoder())
      .AddDecoder<Itest_NamedObject>(_ => new test_NamedDecoder())
      .AddDecoder<Itest_DescribedObject>(_ => new test_DescribedDecoder());
}
