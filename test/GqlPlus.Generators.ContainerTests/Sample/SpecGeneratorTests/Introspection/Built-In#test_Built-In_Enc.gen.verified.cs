//HintName: test_Built-In_Enc.gen.cs
// Generated from {CurrentDirectory}Built-In.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

internal class test_CollectionsEncoder : IEncoder<Itest_CollectionsObject>
{
  public Structured Encode(Itest_CollectionsObject input)
    => Structured.Empty();

  internal static test_CollectionsEncoder Factory(IEncoderRepository _) => new();
}

internal class test_ModifierKeyedEncoder<TModifierKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_ModifierKeyedObject<TModifierKind>>
{
  private readonly IEncoder<Itest_ModifierObject<TModifierKind>> _itest_Modifier = encoders.EncoderFor<Itest_ModifierObject<TModifierKind>>();
  private readonly IEncoder<Itest_TypeSimple> _itest_TypeSimple = encoders.EncoderFor<Itest_TypeSimple>();
  public Structured Encode(Itest_ModifierKeyedObject<TModifierKind> input)
    => _itest_Modifier.Encode(input)
      .AddEncoded("by", input.By, _itest_TypeSimple)
      .Add("isOptional", input.IsOptional);
}

internal class test_ModifiersEncoder : IEncoder<Itest_ModifiersObject>
{
  public Structured Encode(Itest_ModifiersObject input)
    => Structured.Empty();

  internal static test_ModifiersEncoder Factory(IEncoderRepository _) => new();
}

internal class test_ModifierKindEncoder : IEncoder<test_ModifierKind>
{
  public Structured Encode(test_ModifierKind input)
    => new(input.ToString(), "_ModifierKind");

  internal static test_ModifierKindEncoder Factory(IEncoderRepository _) => new();
}

internal class test_ModifierEncoder<TModifierKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_ModifierObject<TModifierKind>>
{
  private readonly IEncoder<TModifierKind> _modifierKind = encoders.EncoderFor<TModifierKind>();
  public Structured Encode(Itest_ModifierObject<TModifierKind> input)
    => Structured.Empty()
      .AddEncoded("modifierKind", input.ModifierKind, _modifierKind);
}

internal static class test_Built_InEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_Built_InEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_CollectionsObject>(test_CollectionsEncoder.Factory)
      .AddEncoder<Itest_ModifiersObject>(test_ModifiersEncoder.Factory)
      .AddEncoder<test_ModifierKind>(test_ModifierKindEncoder.Factory);
}
