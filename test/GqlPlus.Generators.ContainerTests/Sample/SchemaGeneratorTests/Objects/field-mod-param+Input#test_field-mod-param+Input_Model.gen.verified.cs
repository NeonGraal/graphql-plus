//HintName: test_field-mod-param+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

public class testFieldModParamInp<TMod>
  : GqlpModelImplementationBase
  , ItestFieldModParamInp<TMod>
{
  public ItestFieldModParamInpObject<TMod>? As_FieldModParamInp { get; set; }
}

public class testFieldModParamInpObject<TMod>
  : GqlpModelImplementationBase
  , ItestFieldModParamInpObject<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamInp> Field { get; set; }

  public testFieldModParamInpObject
    ( IDictionary<TMod, ItestFldFieldModParamInp> field
    )
  {
    Field = field;
  }
}

public class testFldFieldModParamInp
  : GqlpModelImplementationBase
  , ItestFldFieldModParamInp
{
  public string? AsString { get; set; }
  public ItestFldFieldModParamInpObject? As_FldFieldModParamInp { get; set; }
}

public class testFldFieldModParamInpObject
  : GqlpModelImplementationBase
  , ItestFldFieldModParamInpObject
{
  public decimal Field { get; set; }

  public testFldFieldModParamInpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
