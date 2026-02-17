//HintName: test_object-param+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}object-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Dual;

public class testObjParamDual<TTest,TType>
  : ItestObjParamDual<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
}
