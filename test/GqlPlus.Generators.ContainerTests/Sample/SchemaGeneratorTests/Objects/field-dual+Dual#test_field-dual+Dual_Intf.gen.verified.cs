//HintName: test_field-dual+Dual_Intf.gen.cs
// Generated from field-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Dual;

public interface ItestFieldDualDual
{
  ItestFieldDualDualObject AsFieldDualDual { get; }
}

public interface ItestFieldDualDualObject
{
  ItestFldFieldDualDual Field { get; }
}

public interface ItestFldFieldDualDual
{
  string AsString { get; }
  ItestFldFieldDualDualObject AsFldFieldDualDual { get; }
}

public interface ItestFldFieldDualDualObject
{
  decimal Field { get; }
}
