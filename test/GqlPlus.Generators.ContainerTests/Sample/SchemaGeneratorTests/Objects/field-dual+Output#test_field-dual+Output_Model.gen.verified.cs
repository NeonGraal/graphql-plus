//HintName: test_field-dual+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Output;

public class testFieldDualOutp
  : GqlpModelImplementationBase
  , ItestFieldDualOutp
{
  public ItestFieldDualOutpObject? As_FieldDualOutp { get; set; }
}

public class testFieldDualOutpObject
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , ItestFldFieldDualOutp
{
  public string? AsString { get; set; }
  public ItestFldFieldDualOutpObject? As_FldFieldDualOutp { get; set; }
}

public class testFldFieldDualOutpObject
  : GqlpModelImplementationBase
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
