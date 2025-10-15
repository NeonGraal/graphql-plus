//HintName: test_generic-value+Input_Intf.gen.cs
// Generated from generic-value+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public interface ItestGnrcValueInp
{
  RefGnrcValueInp<EnumGnrcValueInp> AsRefGnrcValueInp { get; }
}

public interface ItestRefGnrcValueInp<Ttype>
{
  Ttype field { get; }
}
