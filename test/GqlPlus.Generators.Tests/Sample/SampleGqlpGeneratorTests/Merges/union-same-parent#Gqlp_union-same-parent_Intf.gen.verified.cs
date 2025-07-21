//HintName: Gqlp_union-same-parent_Intf.gen.cs
// Generated from union-same-parent.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_union_same_parent;

public interface IUnionSamePrnt
  : IPrntUnionSamePrnt
{
  Boolean AsBoolean { get; }
}

public interface IPrntUnionSamePrnt
{
  String AsString { get; }
}
