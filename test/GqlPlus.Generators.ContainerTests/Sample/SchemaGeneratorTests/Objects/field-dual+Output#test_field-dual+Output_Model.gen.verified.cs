//HintName: test_field-dual+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Output;

public class testFieldDualOutp
  : GqlpModelBase
  , ItestFieldDualOutp
{
  public ItestFieldDualOutpObject? As_FieldDualOutp { get; set; }
}

public class testFieldDualOutpObject
  : GqlpModelBase
  , ItestFieldDualOutpObject
{
  public ItestFldFieldDualOutp Field { get; set; }

  public testFieldDualOutpObject
    ( ItestFldFieldDualOutp field
    )
  {
    Field = field;
  }
}

public class testFldFieldDualOutp
  : GqlpModelBase
  , ItestFldFieldDualOutp
{
  public string? AsString { get; set; }
  public ItestFldFieldDualOutpObject? As_FldFieldDualOutp { get; set; }
}

public class testFldFieldDualOutpObject
  : GqlpModelBase
  , ItestFldFieldDualOutpObject
{
  public decimal Field { get; set; }

  public testFldFieldDualOutpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
