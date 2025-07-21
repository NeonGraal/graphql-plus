//HintName: Gqlp_output-generic-value_Impl.gen.cs
// Generated from output-generic-value.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_generic_value;
public class OutputOutpGnrcValue
  : IOutpGnrcValue
{
  public RefOutpGnrcValue<outpGnrcValue> AsRefOutpGnrcValue { get; set; }
}
public class OutputRefOutpGnrcValue<Ttype>
  : IRefOutpGnrcValue<Ttype>
{
  public Ttype field { get; set; }
}
