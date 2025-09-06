//HintName: Gqlp_Union_Intf.gen.cs
// Generated from Union.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Union;

public interface I_TypeUnion
  : I_ParentType
{
}

public interface I_UnionRef
  : I_TypeRef
{
}

public interface I_UnionMember
  : I_UnionRef
{
  _Identifier union { get; }
}
