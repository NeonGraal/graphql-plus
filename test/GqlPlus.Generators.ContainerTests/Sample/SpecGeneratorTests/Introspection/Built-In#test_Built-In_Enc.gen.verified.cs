//HintName: test_Built-In_Enc.gen.cs
// Generated from {CurrentDirectory}Built-In.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

internal class test_CollectionsEncoder : IEncoder<Itest_CollectionsObject>
{
  public Structured Encode(Itest_CollectionsObject input)
    => Structured.Empty();
}

internal class test_ModifierKeyedEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ModifierKeyedObject<TModifierKind>>
{
  private readonly IEncoder<Itest_ModifierObject<TModifierKind>> _itest_ModifierObject<TModifierKind> = encoders.EncoderFor<Itest_ModifierObject<TModifierKind>>();
  private readonly IEncoder<Itest_TypeSimple> _itest_TypeSimple = encoders.EncoderFor<Itest_TypeSimple>();
  public Structured Encode(Itest_ModifierKeyedObject<TModifierKind> input)
    => _itest_ModifierObject<TModifierKind>.Encode(input)
      .AddEncoded("by", input.By, _itest_TypeSimple)
      .Add("isOptional", input.IsOptional);
}

internal class test_ModifiersEncoder : IEncoder<Itest_ModifiersObject>
{
  public Structured Encode(Itest_ModifiersObject input)
    => Structured.Empty();
}

internal class test_ModifierKindEncoder : IEncoder<test_ModifierKind>
{
  public Structured Encode(test_ModifierKind input)
    => new(input.ToString(), "_ModifierKind");
}

internal class test_ModifierEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ModifierObject<TModifierKind>>
{
  private readonly IEncoder<TModifierKind> _modifierKind = encoders.EncoderFor<TModifierKind>();
  public Structured Encode(Itest_ModifierObject<TModifierKind> input)
    => Structured.Empty()
      .AddEncoded("modifierKind", input.ModifierKind, _modifierKind);
}
