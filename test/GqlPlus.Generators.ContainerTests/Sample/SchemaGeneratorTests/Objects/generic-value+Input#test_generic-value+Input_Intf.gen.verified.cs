//HintName: test_generic-value+Input_Intf.gen.cs
// Generated from generic-value+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public interface ItestGnrcValueInp
{
  public ItestRefGnrcValueInp<testEnumGnrcValueInp> AsRefGnrcValueInp { get; set; }
  public ItestGnrcValueInpObject AsGnrcValueInp { get; set; }
}

public interface ItestGnrcValueInpObject
{
}

public interface ItestRefGnrcValueInp<Ttype>
{
  public ItestRefGnrcValueInpObject AsRefGnrcValueInp { get; set; }
}

public interface ItestRefGnrcValueInpObject<Ttype>
{
  public Ttype Field { get; set; }
}
