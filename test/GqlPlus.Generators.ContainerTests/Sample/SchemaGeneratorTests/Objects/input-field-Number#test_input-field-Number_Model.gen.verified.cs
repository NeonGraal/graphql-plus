//HintName: test_input-field-Number_Model.gen.cs
// Generated from {CurrentDirectory}input-field-Number.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Number;

public class testInpFieldNmbr
  : GqlpModelImplementationBase
  , ItestInpFieldNmbr
{
  public ItestInpFieldNmbrObject? As_InpFieldNmbr { get; set; }
}

public class testInpFieldNmbrObject
  : GqlpModelImplementationBase
  , ItestInpFieldNmbrObject
{
  public decimal Field { get; set; }

  public testInpFieldNmbrObject
    ( decimal field
    )
  {
    Field = field;
  }
}
