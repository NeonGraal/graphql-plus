//HintName: test_field-mod-param+Input_Impl.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

public class testFieldModParamInp<TMod>
  : ItestFieldModParamInp<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamInp> Field { get; set; }
}

public class testFldFieldModParamInp
  : ItestFldFieldModParamInp
{
  public decimal Field { get; set; }
}
