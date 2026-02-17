//HintName: test_object-alt+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Dual;

public interface ItestObjAltDual
  : IGqlpModelImplementationBase
{
  ItestObjAltDualType? AsObjAltDualType { get; }
  ItestObjAltDualObject? As_ObjAltDual { get; }
}

public interface ItestObjAltDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAltDualType
  : IGqlpModelImplementationBase
{
  ItestObjAltDualTypeObject? As_ObjAltDualType { get; }
}

public interface ItestObjAltDualTypeObject
  : IGqlpModelImplementationBase
{
}
