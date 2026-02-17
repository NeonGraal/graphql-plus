//HintName: test_Base_Impl.gen.cs
// Generated from {CurrentDirectory}Base.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Base;

public class test_ObjectKind
  : GqlpDomainEnum
  , Itest_ObjectKind
{
}

public class test_TypeObject<TKind,TField>
  : test_ChildType<TKind, Itest_ObjBase>
  , Itest_TypeObject<TKind,TField>
{
  public Itest_TypeObjectObject<TKind,TField>? As__TypeObject { get; set; }
}

public class test_TypeObjectObject<TKind,TField>
  : test_ChildTypeObject<TKind, Itest_ObjBase>
  , Itest_TypeObjectObject<TKind,TField>
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<TField> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<TField>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }

  public test_TypeObjectObject(ICollection<Itest_ObjTypeParam> typeParams, ICollection<TField> fields, ICollection<Itest_ObjAlternate> alternates, ICollection<Itest_ObjectFor<TField>> allFields, ICollection<Itest_ObjectFor<Itest_ObjAlternate>> allAlternates)
  {
    TypeParams = typeParams;
    Fields = fields;
    Alternates = alternates;
    AllFields = allFields;
    AllAlternates = allAlternates;
  }
}

public class test_ObjTypeParam
  : test_Named
  , Itest_ObjTypeParam
{
  public Itest_ObjTypeParamObject? As__ObjTypeParam { get; set; }
}

public class test_ObjTypeParamObject
  : test_NamedObject
  , Itest_ObjTypeParamObject
{
  public Itest_TypeRef<Itest_TypeKind> Constraint { get; set; }

  public test_ObjTypeParamObject(Itest_TypeRef<Itest_TypeKind> constraint)
  {
    Constraint = constraint;
  }
}

public class test_ObjBase
  : test_Named
  , Itest_ObjBase
{
  public Itest_TypeParam? As_TypeParam { get; set; }
  public Itest_ObjBaseObject? As__ObjBase { get; set; }
}

public class test_ObjBaseObject
  : test_NamedObject
  , Itest_ObjBaseObject
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }

  public test_ObjBaseObject(ICollection<Itest_ObjTypeArg> typeArgs)
  {
    TypeArgs = typeArgs;
  }
}

public class test_ObjTypeArg
  : test_TypeRef<Itest_TypeKind>
  , Itest_ObjTypeArg
{
  public Itest_TypeParam? As_TypeParam { get; set; }
  public Itest_ObjTypeArgObject? As__ObjTypeArg { get; set; }
}

public class test_ObjTypeArgObject
  : test_TypeRefObject<Itest_TypeKind>
  , Itest_ObjTypeArgObject
{
  public Itest_Name? Label { get; set; }

  public test_ObjTypeArgObject()
  {
  }
}

public class test_TypeParam
  : test_Described
  , Itest_TypeParam
{
  public Itest_TypeParamObject? As__TypeParam { get; set; }
}

public class test_TypeParamObject
  : test_DescribedObject
  , Itest_TypeParamObject
{
  public Itest_Name TypeParam { get; set; }

  public test_TypeParamObject(Itest_Name typeParam)
  {
    TypeParam = typeParam;
  }
}

public class test_ObjAlternate
  : GqlpModelImplementationBase
  , Itest_ObjAlternate
{
  public Itest_ObjAlternateEnum? As_ObjAlternateEnum { get; set; }
  public Itest_ObjAlternateObject? As__ObjAlternate { get; set; }
}

public class test_ObjAlternateObject
  : GqlpModelImplementationBase
  , Itest_ObjAlternateObject
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }

  public test_ObjAlternateObject(Itest_ObjBase type, ICollection<Itest_Collections> collections)
  {
    Type = type;
    Collections = collections;
  }
}

public class test_ObjAlternateEnum
  : test_TypeRef<Itest_TypeKind>
  , Itest_ObjAlternateEnum
{
  public Itest_ObjAlternateEnumObject? As__ObjAlternateEnum { get; set; }
}

public class test_ObjAlternateEnumObject
  : test_TypeRefObject<Itest_TypeKind>
  , Itest_ObjAlternateEnumObject
{
  public Itest_Name Label { get; set; }

  public test_ObjAlternateEnumObject(Itest_Name label)
  {
    Label = label;
  }
}

public class test_ObjectFor<TFor>
  : GqlpModelImplementationBase
  , Itest_ObjectFor<TFor>
{
  public TFor? As_Parent { get; set; }
  public Itest_ObjectForObject<TFor>? As__ObjectFor { get; set; }
}

public class test_ObjectForObject<TFor>
  : GqlpModelImplementationBase
  , Itest_ObjectForObject<TFor>
{
  public Itest_Name ObjectType { get; set; }

  public test_ObjectForObject(Itest_Name objectType)
  {
    ObjectType = objectType;
  }
}

public class test_ObjField<TType>
  : test_Aliased
  , Itest_ObjField<TType>
{
  public Itest_ObjFieldObject<TType>? As__ObjField { get; set; }
}

public class test_ObjFieldObject<TType>
  : test_AliasedObject
  , Itest_ObjFieldObject<TType>
{
  public TType Type { get; set; }

  public test_ObjFieldObject(TType type)
  {
    Type = type;
  }
}

public class test_ObjFieldType
  : test_ObjBase
  , Itest_ObjFieldType
{
  public Itest_ObjFieldEnum? As_ObjFieldEnum { get; set; }
  public Itest_ObjFieldTypeObject? As__ObjFieldType { get; set; }
}

public class test_ObjFieldTypeObject
  : test_ObjBaseObject
  , Itest_ObjFieldTypeObject
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }

  public test_ObjFieldTypeObject(ICollection<Itest_ObjTypeArg> typeArgs, ICollection<Itest_Modifiers> modifiers)
    : base(typeArgs)
  {
    Modifiers = modifiers;
  }
}

public class test_ObjFieldEnum
  : test_TypeRef<Itest_TypeKind>
  , Itest_ObjFieldEnum
{
  public Itest_ObjFieldEnumObject? As__ObjFieldEnum { get; set; }
}

public class test_ObjFieldEnumObject
  : test_TypeRefObject<Itest_TypeKind>
  , Itest_ObjFieldEnumObject
{
  public Itest_Name Label { get; set; }

  public test_ObjFieldEnumObject(Itest_Name label)
  {
    Label = label;
  }
}

public class test_ForParam<TType>
  : GqlpModelImplementationBase
  , Itest_ForParam<TType>
{
  public Itest_ObjAlternate? As_ObjAlternate { get; set; }
  public Itest_ObjField<TType>? As_ObjField { get; set; }
  public Itest_ForParamObject<TType>? As__ForParam { get; set; }
}

public class test_ForParamObject<TType>
  : GqlpModelImplementationBase
  , Itest_ForParamObject<TType>
{

  public test_ForParamObject()
  {
  }
}
