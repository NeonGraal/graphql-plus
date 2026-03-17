//HintName: test_input-field-null_Model.gen.cs
// Generated from {CurrentDirectory}input-field-null.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_null;

public class testInpFieldNull
  : GqlpModelImplementationBase
  , ItestInpFieldNull
{
  public ItestInpFieldNullObject? As_InpFieldNull { get; set; }
}

public class testInpFieldNullObject
  : GqlpModelImplementationBase
  , ItestInpFieldNullObject
{
  public ItestFldInpFieldNull? Field { get; set; }
}

public class testFldInpFieldNull
  : GqlpModelImplementationBase
  , ItestFldInpFieldNull
{
  public ItestFldInpFieldNullObject? As_FldInpFieldNull { get; set; }
}

public class testFldInpFieldNullObject
  : GqlpModelImplementationBase
  , ItestFldInpFieldNullObject
{
}
