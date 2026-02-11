//HintName: test_alt-dual+Output_Intf.gen.cs
// Generated from alt-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Output;

public interface ItestAltDualOutp
{
  ItestObjDualAltDualOutp AsObjDualAltDualOutp { get; }
  ItestAltDualOutpObject AsAltDualOutp { get; }
}

public interface ItestAltDualOutpObject
{
}

public interface ItestObjDualAltDualOutp
{
  string AsString { get; }
  ItestObjDualAltDualOutpObject AsObjDualAltDualOutp { get; }
}

public interface ItestObjDualAltDualOutpObject
{
  decimal Alt { get; }
}
