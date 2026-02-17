//HintName: test_field-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Dual;

public interface ItestFieldDualDual
  : IGqlpModelImplementationBase
{
  ItestFieldDualDualObject AsFieldDualDual { get; }
}

public interface ItestFieldDualDualObject
{
  ItestFldFieldDualDual Field { get; }
}

public interface ItestFldFieldDualDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestFldFieldDualDualObject AsFldFieldDualDual { get; }
}

public interface ItestFldFieldDualDualObject
{
  decimal Field { get; }
}
