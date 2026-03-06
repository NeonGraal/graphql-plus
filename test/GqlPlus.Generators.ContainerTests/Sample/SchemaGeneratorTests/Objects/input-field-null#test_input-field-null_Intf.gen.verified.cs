//HintName: test_input-field-null_Intf.gen.cs
// Generated from {CurrentDirectory}input-field-null.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_null;

public interface ItestInpFieldNull
  : IGqlpModelImplementationBase
{
  ItestInpFieldNullObject? As_InpFieldNull { get; }
}

public interface ItestInpFieldNullObject
  : IGqlpModelImplementationBase
{
  ItestFldInpFieldNull? Field { get; }
}

public interface ItestFldInpFieldNull
  : IGqlpModelImplementationBase
{
  ItestFldInpFieldNullObject? As_FldInpFieldNull { get; }
}

public interface ItestFldInpFieldNullObject
  : IGqlpModelImplementationBase
{
}
