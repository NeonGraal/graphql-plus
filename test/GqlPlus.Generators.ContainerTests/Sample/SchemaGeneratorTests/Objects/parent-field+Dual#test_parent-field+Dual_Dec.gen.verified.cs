//HintName: test_parent-field+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

public interface ItestPrntFieldDual
  : ItestRefPrntFieldDual
{
  ItestPrntFieldDualObject? As_PrntFieldDual { get; }
}

public interface ItestPrntFieldDualObject
  : ItestRefPrntFieldDualObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntFieldDualObject? As_RefPrntFieldDual { get; }
}

public interface ItestRefPrntFieldDualObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
