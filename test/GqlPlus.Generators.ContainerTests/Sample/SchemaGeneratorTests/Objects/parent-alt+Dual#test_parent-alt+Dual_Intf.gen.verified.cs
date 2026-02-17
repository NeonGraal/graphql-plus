//HintName: test_parent-alt+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}parent-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public interface ItestPrntAltDual
  : ItestRefPrntAltDual
{
  decimal AsNumber { get; }
  ItestPrntAltDualObject AsPrntAltDual { get; }
}

public interface ItestPrntAltDualObject
  : ItestRefPrntAltDualObject
{
}

public interface ItestRefPrntAltDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestRefPrntAltDualObject AsRefPrntAltDual { get; }
}

public interface ItestRefPrntAltDualObject
{
  decimal Parent { get; }
}
