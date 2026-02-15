//HintName: test_parent+Output_Intf.gen.cs
// Generated from parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

public interface ItestPrntOutp
  : ItestRefPrntOutp
{
  ItestPrntOutpObject AsPrntOutp { get; }
}

public interface ItestPrntOutpObject
  : ItestRefPrntOutpObject
{
}

public interface ItestRefPrntOutp
{
  string AsString { get; }
  ItestRefPrntOutpObject AsRefPrntOutp { get; }
}

public interface ItestRefPrntOutpObject
{
  decimal Parent { get; }
}
