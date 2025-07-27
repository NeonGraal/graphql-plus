//HintName: Gqlp_union-parent_Intf.gen.cs
// Generated from union-parent.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_union_parent;

public interface IUnionPrnt
  : IPrntUnionPrnt
{
  String AsString { get; }
}

public interface IPrntUnionPrnt
{
  Number AsNumber { get; }
}
