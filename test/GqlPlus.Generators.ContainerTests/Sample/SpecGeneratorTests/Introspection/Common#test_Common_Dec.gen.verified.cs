//HintName: test_Common_Dec.gen.cs
// Generated from {CurrentDirectory}Common.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

internal class test_SimpleKindDecoder : NullDecoder<test_SimpleKind>
{
  public string Basic { get; set; } = default!;
  public string Enum { get; set; } = default!;
  public string Internal { get; set; } = default!;
  public string Domain { get; set; } = default!;
  public string Union { get; set; } = default!;

  internal static test_SimpleKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeKindDecoder : NullDecoder<test_TypeKind>
{
  public string Basic { get; set; } = default!;
  public string Enum { get; set; } = default!;
  public string Internal { get; set; } = default!;
  public string Domain { get; set; } = default!;
  public string Union { get; set; } = default!;
  public string Dual { get; set; } = default!;
  public string Input { get; set; } = default!;
  public string Output { get; set; } = default!;

  internal static test_TypeKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeRefDecoder<TTypeKind>
{
  public TTypeKind TypeKind { get; set; } = default!;
}

internal class test_TypeSimpleDecoder : NullDecoder<Itest_TypeSimpleObject>
{

  internal static test_TypeSimpleDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_CommonDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_CommonDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_SimpleKind>(test_SimpleKindDecoder.Factory)
      .AddDecoder<test_TypeKind>(test_TypeKindDecoder.Factory)
      .AddDecoder<Itest_TypeSimpleObject>(test_TypeSimpleDecoder.Factory);
}
