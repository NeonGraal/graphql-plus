//HintName: test_alt-mod-Boolean+Input_Intf.gen.cs
// Generated from alt-mod-Boolean+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Input;

public interface ItestAltModBoolInp
{
  IDictionary<bool, ItestAltAltModBoolInp> AsAltAltModBoolInp { get; }
  ItestAltModBoolInpObject AsAltModBoolInp { get; }
}

public interface ItestAltModBoolInpObject
{
}

public interface ItestAltAltModBoolInp
{
  string AsString { get; }
  ItestAltAltModBoolInpObject AsAltAltModBoolInp { get; }
}

public interface ItestAltAltModBoolInpObject
{
  decimal Alt { get; }
}
