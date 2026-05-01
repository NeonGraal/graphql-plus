//HintName: test_-Object_Dec.gen.cs
// Generated from {CurrentDirectory}-Object.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Object;

internal class test_ObjectKindDecoder : IDecoder<Itest_ObjectKind>
{
  public test_TypeKind? Value { get; set; }

  public IMessages Decode(IValue input, out Itest_ObjectKind? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_ObjectKindDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__ObjectDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__ObjectDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_ObjectKind>(test_ObjectKindDecoder.Factory);
}
