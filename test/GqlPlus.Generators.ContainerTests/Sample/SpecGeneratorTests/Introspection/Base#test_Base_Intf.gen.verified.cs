//HintName: test_Base_Intf.gen.cs
// Generated from Base.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Base;

public interface Itest_ObjectKind
  : IDomainEnum
{
}

public interface Itest_TypeObject<Tkind,Tfield>
  : Itest_ChildType
{
  Itest_TypeObjectObject As_TypeObject { get; }
}

public interface Itest_TypeObjectObject<Tkind,Tfield>
  : Itest_ChildTypeObject
{
  ICollection<Itest_ObjTypeParam> TypeParams { get; }
  ICollection<Tfield> Fields { get; }
  ICollection<Itest_ObjAlternate> Alternates { get; }
  ICollection<Itest_ObjectFor<Tfield>> AllFields { get; }
  ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; }
}

public interface Itest_ObjTypeParam
  : Itest_Named
{
  Itest_ObjTypeParamObject As_ObjTypeParam { get; }
}

public interface Itest_ObjTypeParamObject
  : Itest_NamedObject
{
  Itest_TypeRef<Itest_TypeKind> Constraint { get; }
}

public interface Itest_ObjBase
  : Itest_Named
{
  Itest_TypeParam As_TypeParam { get; }
  Itest_ObjBaseObject As_ObjBase { get; }
}

public interface Itest_ObjBaseObject
  : Itest_NamedObject
{
  ICollection<Itest_ObjTypeArg> TypeArgs { get; }
}

public interface Itest_ObjTypeArg
  : Itest_TypeRef
{
  Itest_TypeParam As_TypeParam { get; }
  Itest_ObjTypeArgObject As_ObjTypeArg { get; }
}

public interface Itest_ObjTypeArgObject
  : Itest_TypeRefObject
{
  Itest_Name? Label { get; }
}

public interface Itest_TypeParam
  : Itest_Described
{
  Itest_TypeParamObject As_TypeParam { get; }
}

public interface Itest_TypeParamObject
  : Itest_DescribedObject
{
  Itest_Name TypeParam { get; }
}

public interface Itest_ObjAlternate
{
  Itest_ObjAlternateEnum As_ObjAlternateEnum { get; }
  Itest_ObjAlternateObject As_ObjAlternate { get; }
}

public interface Itest_ObjAlternateObject
{
  Itest_ObjBase Type { get; }
  ICollection<Itest_Collections> Collections { get; }
}

public interface Itest_ObjAlternateEnum
  : Itest_TypeRef
{
  Itest_ObjAlternateEnumObject As_ObjAlternateEnum { get; }
}

public interface Itest_ObjAlternateEnumObject
  : Itest_TypeRefObject
{
  Itest_Name Label { get; }
}

public interface Itest_ObjectFor<Tfor>
  : Itestfor
{
  Itest_ObjectForObject As_ObjectFor { get; }
}

public interface Itest_ObjectForObject<Tfor>
  : ItestforObject
{
  Itest_Name Object { get; }
}

public interface Itest_ObjField<Ttype>
  : Itest_Aliased
{
  Itest_ObjFieldObject As_ObjField { get; }
}

public interface Itest_ObjFieldObject<Ttype>
  : Itest_AliasedObject
{
  Ttype Type { get; }
}

public interface Itest_ObjFieldType
  : Itest_ObjBase
{
  Itest_ObjFieldEnum As_ObjFieldEnum { get; }
  Itest_ObjFieldTypeObject As_ObjFieldType { get; }
}

public interface Itest_ObjFieldTypeObject
  : Itest_ObjBaseObject
{
  ICollection<Itest_Modifiers> Modifiers { get; }
}

public interface Itest_ObjFieldEnum
  : Itest_TypeRef
{
  Itest_ObjFieldEnumObject As_ObjFieldEnum { get; }
}

public interface Itest_ObjFieldEnumObject
  : Itest_TypeRefObject
{
  Itest_Name Label { get; }
}

public interface Itest_ForParam<Ttype>
{
  Itest_ObjAlternate As_ObjAlternate { get; }
  Itest_ObjField<Ttype> As_ObjField { get; }
  Itest_ForParamObject As_ForParam { get; }
}

public interface Itest_ForParamObject<Ttype>
{
}
