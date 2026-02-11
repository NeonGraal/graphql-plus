//HintName: test_generic-alt-arg+Input_Intf.gen.cs
// Generated from generic-alt-arg+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

public interface ItestGnrcAltArgInp<TType>
{
  ItestRefGnrcAltArgInp<TType> AsRefGnrcAltArgInp { get; }
  ItestGnrcAltArgInpObject AsGnrcAltArgInp { get; }
}

public interface ItestGnrcAltArgInpObject<TType>
{
}

public interface ItestRefGnrcAltArgInp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltArgInpObject AsRefGnrcAltArgInp { get; }
}

public interface ItestRefGnrcAltArgInpObject<TRef>
{
}
