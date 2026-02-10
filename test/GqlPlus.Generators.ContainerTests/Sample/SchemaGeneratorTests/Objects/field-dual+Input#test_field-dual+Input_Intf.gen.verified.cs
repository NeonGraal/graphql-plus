//HintName: test_field-dual+Input_Intf.gen.cs
// Generated from field-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Input;

public interface ItestFieldDualInp
{
  public ItestFieldDualInpObject AsFieldDualInp { get; set; }
}

public interface ItestFieldDualInpObject
{
  public ItestFldFieldDualInp Field { get; set; }
}

public interface ItestFldFieldDualInp
{
  public string AsString { get; set; }
  public ItestFldFieldDualInpObject AsFldFieldDualInp { get; set; }
}

public interface ItestFldFieldDualInpObject
{
  public decimal Field { get; set; }
}
