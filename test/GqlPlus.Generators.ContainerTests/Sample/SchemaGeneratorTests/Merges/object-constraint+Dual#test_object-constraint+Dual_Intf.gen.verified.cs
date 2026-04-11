//HintName: test_object-constraint+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-constraint+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Dual;

public interface ItestObjCnstDual<TType>
  : IGqlpInterfaceBase
{
  ItestObjCnstDualObject<TType>? As_ObjCnstDual { get; }
}

public interface ItestObjCnstDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
  TType Str { get; }
}
