//HintName: test_input-field-null_Model.gen.cs
// Generated from {CurrentDirectory}input-field-null.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_null;

public class testInpFieldNull
  : GqlpModelBase
  , ItestInpFieldNull
{
  public ItestInpFieldNullObject? As_InpFieldNull { get; set; }
}

public class testInpFieldNullObject
  : GqlpModelBase
  , ItestInpFieldNullObject
{
  public ItestFldInpFieldNull? Field { get; set; }

  public testInpFieldNullObject
    ()
  {
  }
}

public class testFldInpFieldNull
  : GqlpModelBase
  , ItestFldInpFieldNull
{
  public ItestFldInpFieldNullObject? As_FldInpFieldNull { get; set; }
}

public class testFldInpFieldNullObject
  : GqlpModelBase
  , ItestFldInpFieldNullObject
{

  public testFldInpFieldNullObject
    ()
  {
  }
}
