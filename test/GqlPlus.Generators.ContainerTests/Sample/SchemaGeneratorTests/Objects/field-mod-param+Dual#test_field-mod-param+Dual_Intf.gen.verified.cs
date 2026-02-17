//HintName: test_field-mod-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

public interface ItestFieldModParamDual<TMod>
  : IGqlpModelImplementationBase
{
  ItestFieldModParamDualObject<TMod> AsFieldModParamDual { get; }
}

public interface ItestFieldModParamDualObject<TMod>
{
  IDictionary<TMod, ItestFldFieldModParamDual> Field { get; }
}

public interface ItestFldFieldModParamDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestFldFieldModParamDualObject AsFldFieldModParamDual { get; }
}

public interface ItestFldFieldModParamDualObject
{
  decimal Field { get; }
}
