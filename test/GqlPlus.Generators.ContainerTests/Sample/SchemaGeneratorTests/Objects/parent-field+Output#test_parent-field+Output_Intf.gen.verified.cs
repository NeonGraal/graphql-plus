//HintName: test_parent-field+Output_Intf.gen.cs
// Generated from parent-field+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public interface ItestPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  ItestPrntFieldOutpObject AsPrntFieldOutp { get; }
}

public interface ItestPrntFieldOutpObject
  : ItestRefPrntFieldOutpObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldOutp
{
  string AsString { get; }
  ItestRefPrntFieldOutpObject AsRefPrntFieldOutp { get; }
}

public interface ItestRefPrntFieldOutpObject
{
  decimal Parent { get; }
}
