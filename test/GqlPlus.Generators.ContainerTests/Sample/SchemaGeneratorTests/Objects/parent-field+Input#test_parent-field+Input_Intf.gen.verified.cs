//HintName: test_parent-field+Input_Intf.gen.cs
// Generated from parent-field+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

public interface ItestPrntFieldInp
  : ItestRefPrntFieldInp
{
  public ItestPrntFieldInpObject AsPrntFieldInp { get; set; }
}

public interface ItestPrntFieldInpObject
  : ItestRefPrntFieldInpObject
{
  public decimal Field { get; set; }
}

public interface ItestRefPrntFieldInp
{
  public string AsString { get; set; }
  public ItestRefPrntFieldInpObject AsRefPrntFieldInp { get; set; }
}

public interface ItestRefPrntFieldInpObject
{
  public decimal Parent { get; set; }
}
