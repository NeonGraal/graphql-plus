//HintName: test_generic-value+Input_Intf.gen.cs
// Generated from generic-value+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public interface ItestGnrcValueInp
{
  ItestRefGnrcValueInp<testEnumGnrcValueInp> AsRefGnrcValueInp { get; }
  ItestGnrcValueInpObject AsGnrcValueInp { get; }
}

public interface ItestGnrcValueInpObject
{
}

public interface ItestRefGnrcValueInp<TType>
{
  ItestRefGnrcValueInpObject AsRefGnrcValueInp { get; }
}

public interface ItestRefGnrcValueInpObject<TType>
{
  TType Field { get; }
}
