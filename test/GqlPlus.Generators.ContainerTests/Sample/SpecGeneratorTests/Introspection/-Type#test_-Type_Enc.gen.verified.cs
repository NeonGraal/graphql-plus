//HintName: test_-Type_Enc.gen.cs
// Generated from {CurrentDirectory}-Type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

internal class test_TypeEncoder : IEncoder<Itest_TypeObject>
{
  public Structured Encode(Itest_TypeObject input)
    => Structured.Empty();
}

internal class test_BaseTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_BaseTypeObject<TTypeKind>>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<TTypeKind> _typeKind = encoders.EncoderFor<TTypeKind>();
  public Structured Encode(Itest_BaseTypeObject<TTypeKind> input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("typeKind", input.TypeKind, _typeKind);
}

internal class test_ChildTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ChildTypeObject<TTypeKind,TParent>>
{
  private readonly IEncoder<Itest_BaseTypeObject<TTypeKind>> _itest_BaseTypeObject<TTypeKind> = encoders.EncoderFor<Itest_BaseTypeObject<TTypeKind>>();
  private readonly IEncoder<TParent> _parent = encoders.EncoderFor<TParent>();
  public Structured Encode(Itest_ChildTypeObject<TTypeKind,TParent> input)
    => _itest_BaseTypeObject<TTypeKind>.Encode(input)
      .AddEncoded("parent", input.Parent, _parent);
}

internal class test_ParentTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ParentTypeObject<TTypeKind,TItem,TAllItem>>
{
  private readonly IEncoder<Itest_ChildTypeObject<TTypeKind, Itest_Named>> _itest_ChildTypeObject<TTypeKind, Itest_Named> = encoders.EncoderFor<Itest_ChildTypeObject<TTypeKind, Itest_Named>>();
  private readonly IEncoder<TItem> _item = encoders.EncoderFor<TItem>();
  private readonly IEncoder<TAllItem> _allItem = encoders.EncoderFor<TAllItem>();
  public Structured Encode(Itest_ParentTypeObject<TTypeKind,TItem,TAllItem> input)
    => _itest_ChildTypeObject<TTypeKind, Itest_Named>.Encode(input)
      .AddList("items", input.Items, _item)
      .AddList("allItems", input.AllItems, _allItem);
}

internal class test_SimpleKindEncoder : IEncoder<test_SimpleKind>
{
  public Structured Encode(test_SimpleKind input)
    => new(input.ToString(), "_SimpleKind");
}

internal class test_TypeKindEncoder : IEncoder<test_TypeKind>
{
  public Structured Encode(test_TypeKind input)
    => new(input.ToString(), "_TypeKind");
}

internal class test_TypeRefEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_TypeRefObject<TTypeKind>>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<TTypeKind> _typeKind = encoders.EncoderFor<TTypeKind>();
  public Structured Encode(Itest_TypeRefObject<TTypeKind> input)
    => _itest_Named.Encode(input)
      .AddEncoded("typeKind", input.TypeKind, _typeKind);
}

internal class test_TypeSimpleEncoder : IEncoder<Itest_TypeSimpleObject>
{
  public Structured Encode(Itest_TypeSimpleObject input)
    => Structured.Empty();
}

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
