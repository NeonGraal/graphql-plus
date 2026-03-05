//HintName: test_field-descr+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-descr+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Input;

public interface ItestFieldDescrInp
  : IGqlpModelImplementationBase
{
  ItestFieldDescrInpObject? As_FieldDescrInp { get; }
}

public interface ItestFieldDescrInpObject
  : IGqlpModelImplementationBase
{
  string Field { get; }
}
