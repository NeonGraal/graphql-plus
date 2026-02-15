//HintName: test_parent+Input_Intf.gen.cs
// Generated from parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public interface ItestPrntInp
  : ItestRefPrntInp
{
  ItestPrntInpObject AsPrntInp { get; }
}

public interface ItestPrntInpObject
  : ItestRefPrntInpObject
{
}

public interface ItestRefPrntInp
{
  string AsString { get; }
  ItestRefPrntInpObject AsRefPrntInp { get; }
}

public interface ItestRefPrntInpObject
{
  decimal Parent { get; }
}
