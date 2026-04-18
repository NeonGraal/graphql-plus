//HintName: test_object-alt+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Dual;

public interface ItestObjAltDual
  : IGqlpInterfaceBase
{
  ItestObjAltDualType? AsObjAltDualType { get; }
  ItestObjAltDualObject? As_ObjAltDual { get; }
}

public interface ItestObjAltDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAltDualType
  : IGqlpInterfaceBase
{
  ItestObjAltDualTypeObject? As_ObjAltDualType { get; }
}

public interface ItestObjAltDualTypeObject
  : IGqlpInterfaceBase
{
}
