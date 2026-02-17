//HintName: test_field-mod-param+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

public class testFieldModParamDual<TMod>
  : ItestFieldModParamDual<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamDual> Field { get; set; }
}

public class testFldFieldModParamDual
  : ItestFldFieldModParamDual
{
  public decimal Field { get; set; }
}
