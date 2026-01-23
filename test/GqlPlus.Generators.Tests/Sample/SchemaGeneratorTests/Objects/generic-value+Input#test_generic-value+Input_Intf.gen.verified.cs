//HintName: test_generic-value+Input_Intf.gen.cs
// Generated from generic-value+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public interface ItestGnrcValueInp
{
  public testRefGnrcValueInp<testEnumGnrcValueInp> AsRefGnrcValueInp { get; set; }
  public testGnrcValueInp GnrcValueInp { get; set; }
}

public interface ItestGnrcValueInpObject
{
}

public interface ItestRefGnrcValueInp<Ttype>
{
  public testRefGnrcValueInp RefGnrcValueInp { get; set; }
}

public interface ItestRefGnrcValueInpObject<Ttype>
{
  public Ttype field { get; set; }
}
