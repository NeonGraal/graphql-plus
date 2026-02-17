//HintName: test_alt-mod-Boolean+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

public interface ItestAltModBoolDual
  : IGqlpModelImplementationBase
{
  IDictionary<bool, ItestAltAltModBoolDual> AsAltAltModBoolDual { get; }
  ItestAltModBoolDualObject AsAltModBoolDual { get; }
}

public interface ItestAltModBoolDualObject
{
}

public interface ItestAltAltModBoolDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltAltModBoolDualObject AsAltAltModBoolDual { get; }
}

public interface ItestAltAltModBoolDualObject
{
  decimal Alt { get; }
}
