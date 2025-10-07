//HintName: Gqlp_generic-value+Output_Intf.gen.cs
// Generated from generic-value+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_value_Output;

public interface IGnrcValueOutp
{
  RefGnrcValueOutp<EnumGnrcValueOutp> AsRefGnrcValueOutp { get; }
}

public interface IRefGnrcValueOutp<Ttype>
{
  Ttype field { get; }
}
