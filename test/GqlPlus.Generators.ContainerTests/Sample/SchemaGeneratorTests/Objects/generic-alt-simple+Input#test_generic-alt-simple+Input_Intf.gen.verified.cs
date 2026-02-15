//HintName: test_generic-alt-simple+Input_Intf.gen.cs
// Generated from generic-alt-simple+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

public interface ItestGnrcAltSmplInp
{
  ItestRefGnrcAltSmplInp<string> AsRefGnrcAltSmplInp { get; }
  ItestGnrcAltSmplInpObject AsGnrcAltSmplInp { get; }
}

public interface ItestGnrcAltSmplInpObject
{
}

public interface ItestRefGnrcAltSmplInp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltSmplInpObject<TRef> AsRefGnrcAltSmplInp { get; }
}

public interface ItestRefGnrcAltSmplInpObject<TRef>
{
}
