//HintName: test_parent-descr+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

public interface ItestPrntDescrDual
  : ItestRefPrntDescrDual
{
  ItestPrntDescrDualObject? As_PrntDescrDual { get; }
}

public interface ItestPrntDescrDualObject
  : ItestRefPrntDescrDualObject
{
}

public interface ItestRefPrntDescrDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntDescrDualObject? As_RefPrntDescrDual { get; }
}

public interface ItestRefPrntDescrDualObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
