//HintName: test_field-mod-param+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public class testFieldModParamOutp<TMod>
  : GqlpModelImplementationBase
  , ItestFieldModParamOutp<TMod>
{
  public ItestFieldModParamOutpObject<TMod>? As_FieldModParamOutp { get; set; }
}

public class testFieldModParamOutpObject<TMod>
  : GqlpModelImplementationBase
  , ItestFieldModParamOutpObject<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamOutp> Field { get; set; }

  public testFieldModParamOutpObject
    ( IDictionary<TMod, ItestFldFieldModParamOutp> field
    )
  {
    Field = field;
  }
}

public class testFldFieldModParamOutp
  : GqlpModelImplementationBase
  , ItestFldFieldModParamOutp
{
  public string? AsString { get; set; }
  public ItestFldFieldModParamOutpObject? As_FldFieldModParamOutp { get; set; }
}

public class testFldFieldModParamOutpObject
  : GqlpModelImplementationBase
  , ItestFldFieldModParamOutpObject
{
  public decimal Field { get; set; }

  public testFldFieldModParamOutpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
