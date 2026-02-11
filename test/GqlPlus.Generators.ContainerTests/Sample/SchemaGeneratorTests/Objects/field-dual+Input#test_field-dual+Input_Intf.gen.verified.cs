//HintName: test_field-dual+Input_Intf.gen.cs
// Generated from field-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Input;

public interface ItestFieldDualInp
{
  ItestFieldDualInpObject AsFieldDualInp { get; }
}

public interface ItestFieldDualInpObject
{
  ItestFldFieldDualInp Field { get; }
}

public interface ItestFldFieldDualInp
{
  string AsString { get; }
  ItestFldFieldDualInpObject AsFldFieldDualInp { get; }
}

public interface ItestFldFieldDualInpObject
{
  decimal Field { get; }
}
