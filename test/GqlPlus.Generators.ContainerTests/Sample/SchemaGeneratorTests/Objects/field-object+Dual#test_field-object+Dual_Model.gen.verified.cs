//HintName: test_field-object+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field-object+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

public class testFieldObjDual
  : GqlpModelBase
  , ItestFieldObjDual
{
  public ItestFieldObjDualObject? As_FieldObjDual { get; set; }
}

public class testFieldObjDualObject
  : GqlpModelBase
  , ItestFieldObjDualObject
{
  public ItestFldFieldObjDual Field { get; set; }

  public testFieldObjDualObject
    ( ItestFldFieldObjDual field
    )
  {
    Field = field;
  }
}

public class testFldFieldObjDual
  : GqlpModelBase
  , ItestFldFieldObjDual
{
  public string? AsString { get; set; }
  public ItestFldFieldObjDualObject? As_FldFieldObjDual { get; set; }
}

public class testFldFieldObjDualObject
  : GqlpModelBase
  , ItestFldFieldObjDualObject
{
  public decimal Field { get; set; }

  public testFldFieldObjDualObject
    ( decimal field
    )
  {
    Field = field;
  }
}
