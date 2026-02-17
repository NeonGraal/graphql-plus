//HintName: test_object-constraint+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-constraint+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Dual;

public interface ItestObjCnstDual<TType>
  : IGqlpModelImplementationBase
{
  ItestObjCnstDualObject<TType> AsObjCnstDual { get; }
}

public interface ItestObjCnstDualObject<TType>
{
  TType Field { get; }
  TType Str { get; }
}
