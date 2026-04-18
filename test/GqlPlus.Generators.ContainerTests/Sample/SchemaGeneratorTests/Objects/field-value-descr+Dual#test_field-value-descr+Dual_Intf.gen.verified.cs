//HintName: test_field-value-descr+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Dual;

public interface ItestFieldValueDescrDual
  : IGqlpInterfaceBase
{
  ItestFieldValueDescrDualObject? As_FieldValueDescrDual { get; }
}

public interface ItestFieldValueDescrDualObject
  : IGqlpInterfaceBase
{
  testEnumFieldValueDescrDual Field { get; }
}

public enum testEnumFieldValueDescrDual
{
  fieldValueDescrDual,
}
