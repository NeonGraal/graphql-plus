//HintName: Gqlp_output-generic-value_Intf.gen.cs
// Generated from output-generic-value.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_generic_value;

public interface IOutpGnrcValue
{
  RefOutpGnrcValue<outpGnrcValue> AsRefOutpGnrcValue { get; }
}

public interface IRefOutpGnrcValue<Ttype>
{
  Ttype field { get; }
}
