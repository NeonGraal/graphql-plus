//HintName: test_Full_Enc.gen.cs
// Generated from {CurrentDirectory}Full.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Full;

internal class test_RequestEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_RequestObject>
{
  private readonly Encoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly Encoder<Itest_Operation> _itest_Operation = encoders.EncoderFor<Itest_Operation>();
  private readonly Encoder<object> _object = encoders.EncoderFor<object>();
  public IGqlpValue Encode(Itest_RequestObject input)
    => new GqlpUnit()
      .AddEncoded("category", input.Category, _itest_Identifier)
      .AddEncoded("operation", input.Operation, _itest_Identifier)
      .AddEncoded("definition", input.Definition, _itest_Operation)
      .AddEncoded("parameters", input.Parameters, _object);

  internal static test_RequestEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_IdentifierEncoder : IEncoder<Itest_Identifier>
{
  public IGqlpValue Encode(Itest_Identifier input)
    => input.Value!.Encode();

  internal static test_IdentifierEncoder Factory(IEncoderRepository _) => new();
}

internal class test_CollectionsEncoder : IEncoder<Itest_CollectionsObject>
{
  public IGqlpValue Encode(Itest_CollectionsObject input)
    => new GqlpUnit();

  internal static test_CollectionsEncoder Factory(IEncoderRepository _) => new();
}

internal class test_ModifierKeyedEncoder<TModifierKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_ModifierKeyedObject<TModifierKind>>
{
  private readonly Encoder<Itest_ModifierObject<TModifierKind>> _itest_Modifier = encoders.EncoderFor<Itest_ModifierObject<TModifierKind>>();
  private readonly Encoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  public IGqlpValue Encode(Itest_ModifierKeyedObject<TModifierKind> input)
    => _itest_Modifier.Encode(input)
      .AddEncoded("by", input.By, _itest_Identifier)
      .Add("isOptional", input.IsOptional.Encode());
}

internal class test_ModifiersEncoder : IEncoder<Itest_ModifiersObject>
{
  public IGqlpValue Encode(Itest_ModifiersObject input)
    => new GqlpUnit();

  internal static test_ModifiersEncoder Factory(IEncoderRepository _) => new();
}

internal class test_ModifierKindEncoder : IEncoder<test_ModifierKind>
{
  public IGqlpValue Encode(test_ModifierKind input)
    => input.EncodeEnum("_ModifierKind");

  internal static test_ModifierKindEncoder Factory(IEncoderRepository _) => new();
}

internal class test_ModifierEncoder<TModifierKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_ModifierObject<TModifierKind>>
{
  private readonly Encoder<TModifierKind> _modifierKind = encoders.EncoderFor<TModifierKind>();
  public IGqlpValue Encode(Itest_ModifierObject<TModifierKind> input)
    => new GqlpUnit()
      .AddEncoded("modifierKind", input.ModifierKind, _modifierKind);
}

internal static class test_FullEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_FullEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_RequestObject>(test_RequestEncoder.Factory)
      .AddEncoder<Itest_Identifier>(test_IdentifierEncoder.Factory)
      .AddEncoder<Itest_CollectionsObject>(test_CollectionsEncoder.Factory)
      .AddEncoder<Itest_ModifiersObject>(test_ModifiersEncoder.Factory)
      .AddEncoder<test_ModifierKind>(test_ModifierKindEncoder.Factory);
}
