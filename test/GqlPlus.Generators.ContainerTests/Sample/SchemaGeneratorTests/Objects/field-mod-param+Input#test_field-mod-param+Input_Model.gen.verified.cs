//HintName: test_field-mod-param+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

public class testFieldModParamInp<TMod>
  : GqlpModelBase
  , ItestFieldModParamInp<TMod>
{
  public ItestFieldModParamInpObject<TMod>? As_FieldModParamInp { get; set; }
}

public class testFieldModParamInpObject<TMod>
  : GqlpModelBase
  , ItestFieldModParamInpObject<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamInp> Field { get; set; }

  public testFieldModParamInpObject
    ( IDictionary<TMod, ItestFldFieldModParamInp> pfield
    )
  {
    Field = pfield;
  }
}

public class testFldFieldModParamInp
  : GqlpModelBase
  , ItestFldFieldModParamInp
{
  public string? AsString { get; set; }
  public ItestFldFieldModParamInpObject? As_FldFieldModParamInp { get; set; }
}

public class testFldFieldModParamInpObject
  : GqlpModelBase
  , ItestFldFieldModParamInpObject
{
  public decimal Field { get; set; }

  public testFldFieldModParamInpObject
    ( decimal pfield
    )
  {
    Field = pfield;
  }
}
