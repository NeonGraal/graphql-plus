//HintName: test_-Type_Enc.gen.cs
// Generated from {CurrentDirectory}-Type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

internal class test_TypeEncoder : IEncoder<Itest_TypeObject>
{
  public IGqlpValue Encode(Itest_TypeObject input)
    => new GqlpUnit();

  internal static test_TypeEncoder Factory(IEncoderRepository _) => new();
}

internal class test_BaseTypeEncoder<TTypeKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_BaseTypeObject<TTypeKind>>
{
  private readonly Encoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly Encoder<TTypeKind> _typeKind = encoders.EncoderFor<TTypeKind>();
  public IGqlpValue Encode(Itest_BaseTypeObject<TTypeKind> input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("typeKind", input.TypeKind, _typeKind);
}

internal class test_ChildTypeEncoder<TTypeKind,TParent>(
  IEncoderRepository encoders
) : IEncoder<Itest_ChildTypeObject<TTypeKind,TParent>>
{
  private readonly Encoder<Itest_BaseTypeObject<TTypeKind>> _itest_BaseType = encoders.EncoderFor<Itest_BaseTypeObject<TTypeKind>>();
  private readonly Encoder<TParent> _parent = encoders.EncoderFor<TParent>();
  public IGqlpValue Encode(Itest_ChildTypeObject<TTypeKind,TParent> input)
    => _itest_BaseType.Encode(input)
      .AddEncoded("parent", input.Parent, _parent);
}

internal class test_ParentTypeEncoder<TTypeKind,TItem,TAllItem>(
  IEncoderRepository encoders
) : IEncoder<Itest_ParentTypeObject<TTypeKind,TItem,TAllItem>>
{
  private readonly Encoder<Itest_ChildTypeObject<TTypeKind, Itest_Named>> _itest_ChildType = encoders.EncoderFor<Itest_ChildTypeObject<TTypeKind, Itest_Named>>();
  private readonly Encoder<TItem> _item = encoders.EncoderFor<TItem>();
  private readonly Encoder<TAllItem> _allItem = encoders.EncoderFor<TAllItem>();
  public IGqlpValue Encode(Itest_ParentTypeObject<TTypeKind,TItem,TAllItem> input)
    => _itest_ChildType.Encode(input)
      .AddList("items", input.Items, _item)
      .AddList("allItems", input.AllItems, _allItem);
}

internal class test_SimpleKindEncoder : IEncoder<test_SimpleKind>
{
  public IGqlpValue Encode(test_SimpleKind input)
    => input.EncodeEnum("_SimpleKind");

  internal static test_SimpleKindEncoder Factory(IEncoderRepository _) => new();
}

internal class test_TypeKindEncoder : IEncoder<test_TypeKind>
{
  public IGqlpValue Encode(test_TypeKind input)
    => input.EncodeEnum("_TypeKind");

  internal static test_TypeKindEncoder Factory(IEncoderRepository _) => new();
}

internal class test_TypeRefEncoder<TTypeKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_TypeRefObject<TTypeKind>>
{
  private readonly Encoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly Encoder<TTypeKind> _typeKind = encoders.EncoderFor<TTypeKind>();
  public IGqlpValue Encode(Itest_TypeRefObject<TTypeKind> input)
    => _itest_Named.Encode(input)
      .AddEncoded("typeKind", input.TypeKind, _typeKind);
}

internal class test_TypeSimpleEncoder : IEncoder<Itest_TypeSimpleObject>
{
  public IGqlpValue Encode(Itest_TypeSimpleObject input)
    => new GqlpUnit();

  internal static test_TypeSimpleEncoder Factory(IEncoderRepository _) => new();
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
  private readonly Encoder<Itest_TypeSimple> _itest_TypeSimple = encoders.EncoderFor<Itest_TypeSimple>();
  public IGqlpValue Encode(Itest_ModifierKeyedObject<TModifierKind> input)
    => _itest_Modifier.Encode(input)
      .AddEncoded("by", input.By, _itest_TypeSimple)
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

internal static class test__TypeEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__TypeEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_TypeObject>(test_TypeEncoder.Factory)
      .AddEncoder<test_SimpleKind>(test_SimpleKindEncoder.Factory)
      .AddEncoder<test_TypeKind>(test_TypeKindEncoder.Factory)
      .AddEncoder<Itest_TypeSimpleObject>(test_TypeSimpleEncoder.Factory)
      .AddEncoder<Itest_CollectionsObject>(test_CollectionsEncoder.Factory)
      .AddEncoder<Itest_ModifiersObject>(test_ModifiersEncoder.Factory)
      .AddEncoder<test_ModifierKind>(test_ModifierKindEncoder.Factory);
}
