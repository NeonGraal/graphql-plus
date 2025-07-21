//HintName: Gqlp_Intro_Union_Intf.gen.cs
// Generated from Intro_Union.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Union;

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
