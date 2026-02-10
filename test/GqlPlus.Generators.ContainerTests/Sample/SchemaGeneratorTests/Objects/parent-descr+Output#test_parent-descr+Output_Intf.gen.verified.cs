//HintName: test_parent-descr+Output_Intf.gen.cs
// Generated from parent-descr+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

public interface ItestPrntDescrOutp
  : ItestRefPrntDescrOutp
{
  public ItestPrntDescrOutpObject AsPrntDescrOutp { get; set; }
}

public interface ItestPrntDescrOutpObject
  : ItestRefPrntDescrOutpObject
{
}

public interface ItestRefPrntDescrOutp
{
  public string AsString { get; set; }
  public ItestRefPrntDescrOutpObject AsRefPrntDescrOutp { get; set; }
}

public interface ItestRefPrntDescrOutpObject
{
  public decimal Parent { get; set; }
}
