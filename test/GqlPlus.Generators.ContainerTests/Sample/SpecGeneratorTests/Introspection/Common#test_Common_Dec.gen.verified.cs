//HintName: test_Common_Dec.gen.cs
// Generated from {CurrentDirectory}Common.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

internal class test_SimpleKindDecoder : IDecoder<test_SimpleKind?>
{
  public IMessages Decode(IValue input, out test_SimpleKind? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_SimpleKind value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_SimpleKind".AnError();
  }

  internal static test_SimpleKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeKindDecoder : IDecoder<test_TypeKind?>
{
  public IMessages Decode(IValue input, out test_TypeKind? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_TypeKind value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_TypeKind".AnError();
  }

  internal static test_TypeKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeRefDecoder<TTypeKind>
{
  public TTypeKind? TypeKind { get; set; }
}

internal class test_TypeSimpleDecoder : IDecoder<Itest_TypeSimpleObject>
{

  public IMessages Decode(IValue input, out Itest_TypeSimpleObject? output)
  {
    output = null;
    return Messages.New;
  }

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
