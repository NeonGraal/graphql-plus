//HintName: Gqlp_generic-value+Output_Impl.gen.cs
// Generated from generic-value+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_value_Output;

public class OutputGnrcValueOutp
  : IGnrcValueOutp
{
  public RefGnrcValueOutp<EnumGnrcValueOutp> AsRefGnrcValueOutp { get; set; }
}

public class OutputRefGnrcValueOutp<Ttype>
  : IRefGnrcValueOutp<Ttype>
{
  public Ttype field { get; set; }
}
