//HintName: test_parent-alt+Output_Intf.gen.cs
// Generated from parent-alt+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

public interface ItestPrntAltOutp
  : ItestRefPrntAltOutp
{
  decimal AsNumber { get; }
  ItestPrntAltOutpObject AsPrntAltOutp { get; }
}

public interface ItestPrntAltOutpObject
  : ItestRefPrntAltOutpObject
{
}

public interface ItestRefPrntAltOutp
{
  string AsString { get; }
  ItestRefPrntAltOutpObject AsRefPrntAltOutp { get; }
}

public interface ItestRefPrntAltOutpObject
{
  decimal Parent { get; }
}
