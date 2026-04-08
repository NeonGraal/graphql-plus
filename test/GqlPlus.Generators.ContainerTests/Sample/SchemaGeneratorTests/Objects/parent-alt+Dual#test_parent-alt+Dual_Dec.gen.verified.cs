//HintName: test_parent-alt+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public interface ItestPrntAltDual
  : ItestRefPrntAltDual
{
  decimal? AsNumber { get; }
  ItestPrntAltDualObject? As_PrntAltDual { get; }
}

public interface ItestPrntAltDualObject
  : ItestRefPrntAltDualObject
{
}

public interface ItestRefPrntAltDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntAltDualObject? As_RefPrntAltDual { get; }
}

public interface ItestRefPrntAltDualObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
