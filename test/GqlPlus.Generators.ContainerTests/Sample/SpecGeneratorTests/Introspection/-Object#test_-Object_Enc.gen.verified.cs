//HintName: test_-Object_Enc.gen.cs
// Generated from {CurrentDirectory}-Object.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Object;

internal class test_ObjectKindEncoder : IEncoder<Itest_ObjectKind>
{
  public Structured Encode(Itest_ObjectKind input)
    => new((decimal?)input.Value);

  internal static test_ObjectKindEncoder Factory(IEncoderRepository _) => new();
}

internal class test_TypeObjectEncoder<TObjectKind,TField>(
  IEncoderRepository encoders
) : IEncoder<Itest_TypeObjectObject<TObjectKind,TField>>
{
  private readonly IEncoder<Itest_ChildTypeObject<TObjectKind, Itest_ObjBase>> _itest_ChildType = encoders.EncoderFor<Itest_ChildTypeObject<TObjectKind, Itest_ObjBase>>();
  private readonly IEncoder<Itest_ObjTypeParam> _itest_ObjTypeParam = encoders.EncoderFor<Itest_ObjTypeParam>();
  private readonly IEncoder<TField> _field = encoders.EncoderFor<TField>();
  private readonly IEncoder<Itest_ObjAlternate> _itest_ObjAlternate = encoders.EncoderFor<Itest_ObjAlternate>();
  private readonly IEncoder<Itest_ObjectFor<TField>> _itest_ObjectFor = encoders.EncoderFor<Itest_ObjectFor<TField>>();
  private readonly IEncoder<Itest_ObjectFor<Itest_ObjAlternate>> _itest_ObjectFor2 = encoders.EncoderFor<Itest_ObjectFor<Itest_ObjAlternate>>();
  public Structured Encode(Itest_TypeObjectObject<TObjectKind,TField> input)
    => _itest_ChildType.Encode(input)
      .AddList("typeParams", input.TypeParams, _itest_ObjTypeParam)
      .AddList("fields", input.Fields, _field)
      .AddList("alternates", input.Alternates, _itest_ObjAlternate)
      .AddList("allFields", input.AllFields, _itest_ObjectFor)
      .AddList("allAlternates", input.AllAlternates, _itest_ObjectFor2);
}

internal class test_ObjTypeParamEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjTypeParamObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_TypeRef<Itest_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRef<Itest_TypeKind>>();
  public Structured Encode(Itest_ObjTypeParamObject input)
    => _itest_Named.Encode(input)
      .AddEncoded("constraint", input.Constraint, _itest_TypeRef);

  internal static test_ObjTypeParamEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_ObjBaseEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_ObjTypeArgEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjTypeArgObject>
{
  private readonly IEncoder<Itest_TypeRefObject<Itest_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<Itest_TypeKind>>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_ObjTypeArgObject input)
    => _itest_TypeRef.Encode(input)
      .AddEncoded("label", input.Label, _itest_Name);

  internal static test_ObjTypeArgEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_TypeParamEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_ObjAlternateEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_ObjAlternateEnumEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjAlternateEnumObject>
{
  private readonly IEncoder<Itest_TypeRefObject<Itest_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<Itest_TypeKind>>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_ObjAlternateEnumObject input)
    => _itest_TypeRef.Encode(input)
      .AddEncoded("label", input.Label, _itest_Name);

  internal static test_ObjAlternateEnumEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_ObjectForEncoder<TFor>(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjectForObject<TFor>>
{
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_ObjectForObject<TFor> input)
    => Structured.Empty()
      .AddEncoded("objectType", input.ObjectType, _itest_Name);
}

internal class test_ObjFieldEncoder<TType>(
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

  internal static test_ObjFieldTypeEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_ObjFieldEnumEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjFieldEnumObject>
{
  private readonly IEncoder<Itest_TypeRefObject<Itest_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<Itest_TypeKind>>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_ObjFieldEnumObject input)
    => _itest_TypeRef.Encode(input)
      .AddEncoded("label", input.Label, _itest_Name);

  internal static test_ObjFieldEnumEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_ForParamEncoder<TType> : IEncoder<Itest_ForParamObject<TType>>
{
  public Structured Encode(Itest_ForParamObject<TType> input)
    => Structured.Empty();
}

internal class test_DualFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DualFieldObject>
{
  private readonly IEncoder<Itest_ObjFieldObject<Itest_ObjFieldType>> _itest_ObjField = encoders.EncoderFor<Itest_ObjFieldObject<Itest_ObjFieldType>>();
  public Structured Encode(Itest_DualFieldObject input)
    => _itest_ObjField.Encode(input);

  internal static test_DualFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_InputFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_InputFieldObject>
{
  private readonly IEncoder<Itest_ObjFieldObject<Itest_InputFieldType>> _itest_ObjField = encoders.EncoderFor<Itest_ObjFieldObject<Itest_InputFieldType>>();
  public Structured Encode(Itest_InputFieldObject input)
    => _itest_ObjField.Encode(input);

  internal static test_InputFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_InputFieldTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_InputFieldTypeObject>
{
  private readonly IEncoder<Itest_ObjFieldTypeObject> _itest_ObjFieldType = encoders.EncoderFor<Itest_ObjFieldTypeObject>();
  private readonly IEncoder<GqlpValue> _gqlpValue = encoders.EncoderFor<GqlpValue>();
  public Structured Encode(Itest_InputFieldTypeObject input)
    => _itest_ObjFieldType.Encode(input)
      .AddEncoded("defaultValue", input.DefaultValue, _gqlpValue);

  internal static test_InputFieldTypeEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OutputFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OutputFieldObject>
{
  private readonly IEncoder<Itest_ObjFieldObject<Itest_ObjFieldType>> _itest_ObjField = encoders.EncoderFor<Itest_ObjFieldObject<Itest_ObjFieldType>>();
  public Structured Encode(Itest_OutputFieldObject input)
    => _itest_ObjField.Encode(input);

  internal static test_OutputFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OutputFieldTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OutputFieldTypeObject>
{
  private readonly IEncoder<Itest_ObjFieldTypeObject> _itest_ObjFieldType = encoders.EncoderFor<Itest_ObjFieldTypeObject>();
  private readonly IEncoder<Itest_InputFieldType> _itest_InputFieldType = encoders.EncoderFor<Itest_InputFieldType>();
  public Structured Encode(Itest_OutputFieldTypeObject input)
    => _itest_ObjFieldType.Encode(input)
      .AddEncoded("parameter", input.Parameter, _itest_InputFieldType);

  internal static test_OutputFieldTypeEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test__ObjectEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__ObjectEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_ObjectKind>(test_ObjectKindEncoder.Factory)
      .AddEncoder<Itest_ObjTypeParamObject>(test_ObjTypeParamEncoder.Factory)
      .AddEncoder<Itest_ObjBaseObject>(test_ObjBaseEncoder.Factory)
      .AddEncoder<Itest_ObjTypeArgObject>(test_ObjTypeArgEncoder.Factory)
      .AddEncoder<Itest_TypeParamObject>(test_TypeParamEncoder.Factory)
      .AddEncoder<Itest_ObjAlternateObject>(test_ObjAlternateEncoder.Factory)
      .AddEncoder<Itest_ObjAlternateEnumObject>(test_ObjAlternateEnumEncoder.Factory)
      .AddEncoder<Itest_ObjFieldTypeObject>(test_ObjFieldTypeEncoder.Factory)
      .AddEncoder<Itest_ObjFieldEnumObject>(test_ObjFieldEnumEncoder.Factory)
      .AddEncoder<Itest_DualFieldObject>(test_DualFieldEncoder.Factory)
      .AddEncoder<Itest_InputFieldObject>(test_InputFieldEncoder.Factory)
      .AddEncoder<Itest_InputFieldTypeObject>(test_InputFieldTypeEncoder.Factory)
      .AddEncoder<Itest_OutputFieldObject>(test_OutputFieldEncoder.Factory)
      .AddEncoder<Itest_OutputFieldTypeObject>(test_OutputFieldTypeEncoder.Factory);
}
