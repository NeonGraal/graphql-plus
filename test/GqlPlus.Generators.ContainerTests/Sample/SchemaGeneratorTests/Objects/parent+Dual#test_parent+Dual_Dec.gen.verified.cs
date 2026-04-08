//HintName: test_parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

public interface ItestPrntDual
  : ItestRefPrntDual
{
  ItestPrntDualObject? As_PrntDual { get; }
}

public interface ItestPrntDualObject
  : ItestRefPrntDualObject
{
}

public interface ItestRefPrntDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntDualObject? As_RefPrntDual { get; }
}

public interface ItestRefPrntDualObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
