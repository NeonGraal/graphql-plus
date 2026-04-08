//HintName: test_parent-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

public interface ItestPrntDualOutp
  : ItestRefPrntDualOutp
{
  ItestPrntDualOutpObject? As_PrntDualOutp { get; }
}

public interface ItestPrntDualOutpObject
  : ItestRefPrntDualOutpObject
{
}

public interface ItestRefPrntDualOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntDualOutpObject? As_RefPrntDualOutp { get; }
}

public interface ItestRefPrntDualOutpObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
