//HintName: test_object-constraint+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-constraint+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Dual;

public interface ItestObjCnstDual<TType>
  // No Base because it's Class
{
  ItestObjCnstDualObject<TType>? As_ObjCnstDual { get; }
}

public interface ItestObjCnstDualObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
  TType Str { get; }
}
