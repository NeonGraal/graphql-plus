//HintName: test_-Type_Dec.gen.cs
// Generated from {CurrentDirectory}-Type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

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

internal class test_CollectionsDecoder : IDecoder<Itest_CollectionsObject>
{

  public IMessages Decode(IValue input, out Itest_CollectionsObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_CollectionsDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKeyedDecoder<TModifierKind>
{
  public Itest_TypeSimple? By { get; set; }
  public bool? IsOptional { get; set; }
}

internal class test_ModifiersDecoder : IDecoder<Itest_ModifiersObject>
{

  public IMessages Decode(IValue input, out Itest_ModifiersObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_ModifiersDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKindDecoder : IDecoder<test_ModifierKind?>
{
  public IMessages Decode(IValue input, out test_ModifierKind? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_ModifierKind value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_ModifierKind".AnError();
  }

  internal static test_ModifierKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierDecoder<TModifierKind>
{
  public TModifierKind? ModifierKind { get; set; }
}

internal static class test__TypeDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__TypeDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_SimpleKind?>(test_SimpleKindDecoder.Factory)
      .AddDecoder<test_TypeKind?>(test_TypeKindDecoder.Factory)
      .AddDecoder<Itest_TypeSimpleObject>(test_TypeSimpleDecoder.Factory)
      .AddDecoder<Itest_CollectionsObject>(test_CollectionsDecoder.Factory)
      .AddDecoder<Itest_ModifiersObject>(test_ModifiersDecoder.Factory)
      .AddDecoder<test_ModifierKind?>(test_ModifierKindDecoder.Factory);
}
