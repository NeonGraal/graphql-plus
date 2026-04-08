//HintName: test_object-param-dup+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Dual;

public interface ItestObjParamDupDual<TTest>
  // No Base because it's Class
{
  ItestObjParamDupDualObject<TTest>? As_ObjParamDupDual { get; }
}

public interface ItestObjParamDupDualObject<TTest>
  // No Base because it's Class
{
  TTest Test { get; }
  TTest Type { get; }
}
