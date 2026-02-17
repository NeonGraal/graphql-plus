//HintName: test_object-param+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-param+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Input;

public interface ItestObjParamInp<TTest,TType>
  : IGqlpModelImplementationBase
{
  ItestObjParamInpObject<TTest,TType> AsObjParamInp { get; }
}

public interface ItestObjParamInpObject<TTest,TType>
{
  TTest Test { get; }
  TType Type { get; }
}
