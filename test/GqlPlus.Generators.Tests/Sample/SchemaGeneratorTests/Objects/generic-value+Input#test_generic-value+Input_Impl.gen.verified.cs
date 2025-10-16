//HintName: test_generic-value+Input_Impl.gen.cs
// Generated from generic-value+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public class testGnrcValueInp
  : ItestGnrcValueInp
{
  public RefGnrcValueInp<EnumGnrcValueInp> AsRefGnrcValueInp { get; set; }
}

public class testRefGnrcValueInp<Ttype>
  : ItestRefGnrcValueInp<Ttype>
{
  public Ttype field { get; set; }
}
