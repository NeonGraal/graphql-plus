//HintName: test_input-field-Number_Intf.gen.cs
// Generated from {CurrentDirectory}input-field-Number.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Number;

public interface ItestInpFieldNmbr
  : IGqlpModelImplementationBase
{
  ItestInpFieldNmbrObject AsInpFieldNmbr { get; }
}

public interface ItestInpFieldNmbrObject
{
  decimal Field { get; }
}
