//HintName: test_field-object+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-object+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Output;

public class testFieldObjOutp
  : GqlpModelBase
  , ItestFieldObjOutp
{
  public ItestFieldObjOutpObject? As_FieldObjOutp { get; set; }
}

public class testFieldObjOutpObject
  : GqlpModelBase
  , ItestFieldObjOutpObject
{
  public ItestFldFieldObjOutp Field { get; set; }

  public testFieldObjOutpObject
    ( ItestFldFieldObjOutp pfield
    )
  {
    Field = pfield;
  }
}

public class testFldFieldObjOutp
  : GqlpModelBase
  , ItestFldFieldObjOutp
{
  public string? AsString { get; set; }
  public ItestFldFieldObjOutpObject? As_FldFieldObjOutp { get; set; }
}

public class testFldFieldObjOutpObject
  : GqlpModelBase
  , ItestFldFieldObjOutpObject
{
  public decimal Field { get; set; }

  public testFldFieldObjOutpObject
    ( decimal pfield
    )
  {
    Field = pfield;
  }
}
