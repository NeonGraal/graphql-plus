//HintName: Gqlp_generic-value+Input_Impl.gen.cs
// Generated from generic-value+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_value_Input;

public class InputGnrcValueInp
  : IGnrcValueInp
{
  public RefGnrcValueInp<EnumGnrcValueInp> AsRefGnrcValueInp { get; set; }
}

public class InputRefGnrcValueInp<Ttype>
  : IRefGnrcValueInp<Ttype>
{
  public Ttype field { get; set; }
}
