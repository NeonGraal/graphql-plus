//HintName: Gqlp_parent+Output_Intf.gen.cs
// Generated from parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_Output;

public interface IPrntOutp
  : IRefPrntOutp
{
}

public interface IRefPrntOutp
{
  Number parent { get; }
  String AsString { get; }
}
