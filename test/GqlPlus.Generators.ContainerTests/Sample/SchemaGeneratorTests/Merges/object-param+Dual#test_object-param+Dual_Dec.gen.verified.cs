//HintName: test_object-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Dual;

public interface ItestObjParamDual<TTest,TType>
  // No Base because it's Class
{
  ItestObjParamDualObject<TTest,TType>? As_ObjParamDual { get; }
}

public interface ItestObjParamDualObject<TTest,TType>
  // No Base because it's Class
{
  TTest Test { get; }
  TType Type { get; }
}
