//HintName: test_field-type-descr+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Dual;

public interface ItestFieldTypeDescrDual
  : IGqlpInterfaceBase
{
  ItestFieldTypeDescrDualObject? As_FieldTypeDescrDual { get; }
}

public interface ItestFieldTypeDescrDualObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
