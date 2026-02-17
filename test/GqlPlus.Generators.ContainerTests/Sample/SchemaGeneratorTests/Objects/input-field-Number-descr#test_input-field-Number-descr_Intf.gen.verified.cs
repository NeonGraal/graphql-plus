//HintName: test_input-field-Number-descr_Intf.gen.cs
// Generated from {CurrentDirectory}input-field-Number-descr.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Number_descr;

public interface ItestInpFieldNmbrDescr
  : IGqlpModelImplementationBase
{
  ItestInpFieldNmbrDescrObject AsInpFieldNmbrDescr { get; }
}

public interface ItestInpFieldNmbrDescrObject
{
  decimal Field { get; }
}
