//HintName: test_input-field-Number-descr_Model.gen.cs
// Generated from {CurrentDirectory}input-field-Number-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Number_descr;

public class testInpFieldNmbrDescr
  : GqlpModelBase
  , ItestInpFieldNmbrDescr
{
  public ItestInpFieldNmbrDescrObject? As_InpFieldNmbrDescr { get; set; }
}

public class testInpFieldNmbrDescrObject
  : GqlpModelBase
  , ItestInpFieldNmbrDescrObject
{
  public decimal Field { get; set; }

  public testInpFieldNmbrDescrObject
    ( decimal field
    )
  {
    Field = field;
  }
}
