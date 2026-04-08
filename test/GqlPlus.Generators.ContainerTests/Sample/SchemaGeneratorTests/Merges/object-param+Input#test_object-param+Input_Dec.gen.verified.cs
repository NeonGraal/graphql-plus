//HintName: test_object-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Input;

public interface ItestObjParamInp<TTest,TType>
  // No Base because it's Class
{
  ItestObjParamInpObject<TTest,TType>? As_ObjParamInp { get; }
}

public interface ItestObjParamInpObject<TTest,TType>
  // No Base because it's Class
{
  TTest Test { get; }
  TType Type { get; }
}
