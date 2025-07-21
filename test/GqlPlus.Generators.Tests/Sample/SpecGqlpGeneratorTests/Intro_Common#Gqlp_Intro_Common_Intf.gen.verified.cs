//HintName: Gqlp_Intro_Common_Intf.gen.cs
// Generated from Intro_Common.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Common;

public interface I_Type
{
  _BaseType<_TypeKind> As_BaseType { get; }
  _BaseType<_TypeKind> As_BaseType { get; }
  _TypeDual As_TypeDual { get; }
  _TypeEnum As_TypeEnum { get; }
  _TypeInput As_TypeInput { get; }
  _TypeOutput As_TypeOutput { get; }
  _TypeDomain As_TypeDomain { get; }
  _TypeUnion As_TypeUnion { get; }
}

public interface I_BaseType<Tkind>
  : I_Aliased
{
  Tkind typeKind { get; }
}

public interface I_ChildType<Tkind,Tparent>
  : I_BaseType
{
  Tparent parent { get; }
}

public interface I_ParentType<Tkind,Titem,TallItem>
  : I_ChildType
{
  Titem items { get; }
  TallItem allItems { get; }
}

public interface I_TypeRef<Tkind>
  : I_Named
{
  Tkind typeKind { get; }
}

public interface I_TypeSimple
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
}
