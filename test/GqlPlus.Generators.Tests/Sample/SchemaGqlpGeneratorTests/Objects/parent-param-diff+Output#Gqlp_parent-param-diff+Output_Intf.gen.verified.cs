//HintName: Gqlp_parent-param-diff+Output_Intf.gen.cs
// Generated from parent-param-diff+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_param_diff_Output;

public interface IPrntParamDiffOutp<Ta>
  : IRefPrntParamDiffOutp
{
  Ta field { get; }
}

public interface IRefPrntParamDiffOutp<Tb>
{
  Tb Asb { get; }
}
