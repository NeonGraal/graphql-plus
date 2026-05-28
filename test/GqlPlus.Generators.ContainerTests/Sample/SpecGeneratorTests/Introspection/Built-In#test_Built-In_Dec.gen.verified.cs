//HintName: test_Built-In_Dec.gen.cs
// Generated from {CurrentDirectory}Built-In.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

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

internal static class test_Built_InDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_Built_InDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_CollectionsObject>(test_CollectionsDecoder.Factory)
      .AddDecoder<Itest_ModifiersObject>(test_ModifiersDecoder.Factory)
      .AddDecoder<test_ModifierKind?>(test_ModifierKindDecoder.Factory);
}
