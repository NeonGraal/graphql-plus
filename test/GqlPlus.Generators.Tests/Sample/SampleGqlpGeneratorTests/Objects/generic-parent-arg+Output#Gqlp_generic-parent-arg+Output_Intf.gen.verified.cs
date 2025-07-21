//HintName: Gqlp_generic-parent-arg+Output_Intf.gen.cs
// Generated from generic-parent-arg+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_arg_Output;

public interface IGnrcPrntArgOutp<Ttype>
  : IRefGnrcPrntArgOutp
{
}

public interface IRefGnrcPrntArgOutp<Tref>
{
  Tref Asref { get; }
}
