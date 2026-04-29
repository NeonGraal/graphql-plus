//HintName: test_Common_Dec.gen.cs
// Generated from {CurrentDirectory}Common.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

internal class test_SimpleKindDecoder : IDecoder<test_SimpleKind?>
{
  public IMessages Decoder(IValue input, out test_SimpleKind? output)
    => input.DecodeEnum("_SimpleKind", out output);

  internal static test_SimpleKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeKindDecoder : IDecoder<test_TypeKind?>
{
  public IMessages Decoder(IValue input, out test_TypeKind? output)
    => input.DecodeEnum("_TypeKind", out output);

  internal static test_TypeKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeRefDecoder<TTypeKind>
{
  public TTypeKind TypeKind { get; set; }
}

internal class test_TypeSimpleDecoder
{

  internal static test_TypeSimpleDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_CommonDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_CommonDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_SimpleKind?>(test_SimpleKindDecoder.Factory)
      .AddDecoder<test_TypeKind?>(test_TypeKindDecoder.Factory)
      .AddDecoder<Itest_TypeSimpleObject>(test_TypeSimpleDecoder.Factory);
}
