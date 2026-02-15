//HintName: test_parent-alt+Input_Intf.gen.cs
// Generated from parent-alt+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public interface ItestPrntAltInp
  : ItestRefPrntAltInp
{
  decimal AsNumber { get; }
  ItestPrntAltInpObject AsPrntAltInp { get; }
}

public interface ItestPrntAltInpObject
  : ItestRefPrntAltInpObject
{
}

public interface ItestRefPrntAltInp
{
  string AsString { get; }
  ItestRefPrntAltInpObject AsRefPrntAltInp { get; }
}

public interface ItestRefPrntAltInpObject
{
  decimal Parent { get; }
}
