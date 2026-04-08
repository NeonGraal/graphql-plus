//HintName: test_parent-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Dual;

public interface ItestPrntDualDual
  : ItestRefPrntDualDual
{
  ItestPrntDualDualObject? As_PrntDualDual { get; }
}

public interface ItestPrntDualDualObject
  : ItestRefPrntDualDualObject
{
}

public interface ItestRefPrntDualDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntDualDualObject? As_RefPrntDualDual { get; }
}

public interface ItestRefPrntDualDualObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
