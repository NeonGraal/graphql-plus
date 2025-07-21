//HintName: Gqlp_Intro_Union_Impl.gen.cs
// Generated from Intro_Union.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Union;
public class Output_TypeUnion
  : Output_ParentType
  , I_TypeUnion
{
}
public class Output_UnionRef
  : Output_TypeRef
  , I_UnionRef
{
}
public class Output_UnionMember
  : Output_UnionRef
  , I_UnionMember
{
  public _Identifier union { get; set; }
}
