//HintName: test_input-field-null_Intf.gen.cs
// Generated from {CurrentDirectory}input-field-null.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_null;

public interface ItestInpFieldNull
  : IGqlpInterfaceBase
{
  ItestInpFieldNullObject? As_InpFieldNull { get; }
}

public interface ItestInpFieldNullObject
  : IGqlpInterfaceBase
{
  ItestFldInpFieldNull? Field { get; }
}

public interface ItestFldInpFieldNull
  : IGqlpInterfaceBase
{
  ItestFldInpFieldNullObject? As_FldInpFieldNull { get; }
}

public interface ItestFldInpFieldNullObject
  : IGqlpInterfaceBase
{
}
