//HintName: test_object-param-dup+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Input;

public interface ItestObjParamDupInp<TTest>
  // No Base because it's Class
{
  ItestObjParamDupInpObject<TTest>? As_ObjParamDupInp { get; }
}

public interface ItestObjParamDupInpObject<TTest>
  // No Base because it's Class
{
  TTest Test { get; }
  TTest Type { get; }
}
