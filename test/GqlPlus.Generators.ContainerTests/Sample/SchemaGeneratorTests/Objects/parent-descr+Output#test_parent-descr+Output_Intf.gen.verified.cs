//HintName: test_parent-descr+Output_Intf.gen.cs
// Generated from parent-descr+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

public interface ItestPrntDescrOutp
  : ItestRefPrntDescrOutp
{
  ItestPrntDescrOutpObject AsPrntDescrOutp { get; }
}

public interface ItestPrntDescrOutpObject
  : ItestRefPrntDescrOutpObject
{
}

public interface ItestRefPrntDescrOutp
{
  string AsString { get; }
  ItestRefPrntDescrOutpObject AsRefPrntDescrOutp { get; }
}

public interface ItestRefPrntDescrOutpObject
{
  decimal Parent { get; }
}
