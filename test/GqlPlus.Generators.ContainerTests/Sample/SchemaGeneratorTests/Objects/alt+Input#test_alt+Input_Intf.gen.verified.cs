//HintName: test_alt+Input_Intf.gen.cs
// Generated from alt+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Input;

public interface ItestAltInp
{
  ItestAltAltInp AsAltAltInp { get; }
  ItestAltInpObject AsAltInp { get; }
}

public interface ItestAltInpObject
{
}

public interface ItestAltAltInp
{
  string AsString { get; }
  ItestAltAltInpObject AsAltAltInp { get; }
}

public interface ItestAltAltInpObject
{
  decimal Alt { get; }
}
