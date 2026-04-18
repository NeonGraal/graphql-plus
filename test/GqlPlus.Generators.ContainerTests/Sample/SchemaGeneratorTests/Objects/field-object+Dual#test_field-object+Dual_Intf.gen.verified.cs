//HintName: test_field-object+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-object+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

public interface ItestFieldObjDual
  : IGqlpInterfaceBase
{
  ItestFieldObjDualObject? As_FieldObjDual { get; }
}

public interface ItestFieldObjDualObject
  : IGqlpInterfaceBase
{
  ItestFldFieldObjDual Field { get; }
}

public interface ItestFldFieldObjDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldObjDualObject? As_FldFieldObjDual { get; }
}

public interface ItestFldFieldObjDualObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
