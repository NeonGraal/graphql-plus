//HintName: test_Base_Enc.gen.cs
// Generated from {CurrentDirectory}Base.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Base;

internal class test_ObjectKindEncoder : IEncoder<Itest_ObjectKind>
{
  public Structured Encode(Itest_ObjectKind input)
    => new((decimal?)input.Value);
}

internal class test_TypeObjectEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_TypeObjectObject<TObjectKind,TField>>
{
  private readonly IEncoder<Itest_ChildTypeObject<TObjectKind, Itest_ObjBase>> _itest_ChildTypeObject<TObjectKind, Itest_ObjBase> = encoders.EncoderFor<Itest_ChildTypeObject<TObjectKind, Itest_ObjBase>>();
  private readonly IEncoder<Itest_ObjTypeParam> _itest_ObjTypeParam = encoders.EncoderFor<Itest_ObjTypeParam>();
  private readonly IEncoder<TField> _field = encoders.EncoderFor<TField>();
  private readonly IEncoder<Itest_ObjAlternate> _itest_ObjAlternate = encoders.EncoderFor<Itest_ObjAlternate>();
  private readonly IEncoder<Itest_ObjectFor<TField>> _itest_ObjectFor<TField> = encoders.EncoderFor<Itest_ObjectFor<TField>>();
  private readonly IEncoder<Itest_ObjectFor<Itest_ObjAlternate>> _itest_ObjectFor<Itest_ObjAlternate> = encoders.EncoderFor<Itest_ObjectFor<Itest_ObjAlternate>>();
  public Structured Encode(Itest_TypeObjectObject<TObjectKind,TField> input)
    => _itest_ChildTypeObject<TObjectKind, Itest_ObjBase>.Encode(input)
      .AddList("typeParams", input.TypeParams, _itest_ObjTypeParam)
      .AddList("fields", input.Fields, _field)
      .AddList("alternates", input.Alternates, _itest_ObjAlternate)
      .AddList("allFields", input.AllFields, _itest_ObjectFor<TField>)
      .AddList("allAlternates", input.AllAlternates, _itest_ObjectFor<Itest_ObjAlternate>);
}

internal class test_ObjTypeParamEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjTypeParamObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_TypeRef<Itest_TypeKind>> _itest_TypeRef<Itest_TypeKind> = encoders.EncoderFor<Itest_TypeRef<Itest_TypeKind>>();
  public Structured Encode(Itest_ObjTypeParamObject input)
    => _itest_Named.Encode(input)
      .AddEncoded("constraint", input.Constraint, _itest_TypeRef<Itest_TypeKind>);
}

internal class test_ObjBaseEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjBaseObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_ObjTypeArg> _itest_ObjTypeArg = encoders.EncoderFor<Itest_ObjTypeArg>();
  public Structured Encode(Itest_ObjBaseObject input)
    => _itest_Named.Encode(input)
      .AddList("typeArgs", input.TypeArgs, _itest_ObjTypeArg);
}

internal class test_ObjTypeArgEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjTypeArgObject>
{
  private readonly IEncoder<Itest_TypeRefObject<Itest_TypeKind>> _itest_TypeRefObject<Itest_TypeKind> = encoders.EncoderFor<Itest_TypeRefObject<Itest_TypeKind>>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_ObjTypeArgObject input)
    => _itest_TypeRefObject<Itest_TypeKind>.Encode(input)
      .AddEncoded("label", input.Label, _itest_Name);
}

internal class test_TypeParamEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_TypeParamObject>
{
  private readonly IEncoder<Itest_DescribedObject> _itest_Described = encoders.EncoderFor<Itest_DescribedObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_TypeParamObject input)
    => _itest_Described.Encode(input)
      .AddEncoded("typeParam", input.TypeParam, _itest_Name);
}

internal class test_ObjAlternateEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjAlternateObject>
{
  private readonly IEncoder<Itest_ObjBase> _itest_ObjBase = encoders.EncoderFor<Itest_ObjBase>();
  private readonly IEncoder<Itest_Collections> _itest_Collections = encoders.EncoderFor<Itest_Collections>();
  public Structured Encode(Itest_ObjAlternateObject input)
    => Structured.Empty()
      .AddEncoded("type", input.Type, _itest_ObjBase)
      .AddList("collections", input.Collections, _itest_Collections);
}

internal class test_ObjAlternateEnumEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjAlternateEnumObject>
{
  private readonly IEncoder<Itest_TypeRefObject<Itest_TypeKind>> _itest_TypeRefObject<Itest_TypeKind> = encoders.EncoderFor<Itest_TypeRefObject<Itest_TypeKind>>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_ObjAlternateEnumObject input)
    => _itest_TypeRefObject<Itest_TypeKind>.Encode(input)
      .AddEncoded("label", input.Label, _itest_Name);
}

internal class test_ObjectForEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjectForObject<TFor>>
{
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_ObjectForObject<TFor> input)
    => Structured.Empty()
      .AddEncoded("objectType", input.ObjectType, _itest_Name);
}

internal class test_ObjFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjFieldObject<TType>>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(Itest_ObjFieldObject<TType> input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("type", input.Type, _type);
}

internal class test_ObjFieldTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjFieldTypeObject>
{
  private readonly IEncoder<Itest_ObjBaseObject> _itest_ObjBase = encoders.EncoderFor<Itest_ObjBaseObject>();
  private readonly IEncoder<Itest_Modifiers> _itest_Modifiers = encoders.EncoderFor<Itest_Modifiers>();
  public Structured Encode(Itest_ObjFieldTypeObject input)
    => _itest_ObjBase.Encode(input)
      .AddList("modifiers", input.Modifiers, _itest_Modifiers);
}

internal class test_ObjFieldEnumEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjFieldEnumObject>
{
  private readonly IEncoder<Itest_TypeRefObject<Itest_TypeKind>> _itest_TypeRefObject<Itest_TypeKind> = encoders.EncoderFor<Itest_TypeRefObject<Itest_TypeKind>>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_ObjFieldEnumObject input)
    => _itest_TypeRefObject<Itest_TypeKind>.Encode(input)
      .AddEncoded("label", input.Label, _itest_Name);
}

internal class test_ForParamEncoder : IEncoder<Itest_ForParamObject<TType>>
{
  public Structured Encode(Itest_ForParamObject<TType> input)
    => Structured.Empty();
}
